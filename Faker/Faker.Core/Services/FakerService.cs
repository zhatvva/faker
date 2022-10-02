using Faker.Core.Entities;
using Faker.Core.Interfaces;
using System.Reflection;

namespace Faker.Core.Services
{
    public class FakerService : IFaker
    {
        private readonly IFakerConfig _config;
        private readonly List<IGenerator> _generators;
        private readonly GeneratorContext _context;
        private readonly HashSet<Type> _generatedTypes;

        public FakerService()
        {
            _generators = LoadGeneratorsFromAssembly();
            _context = new(new Random(), this);
            _generatedTypes = new();
        }

        public FakerService(IFakerConfig config) : this()
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public TEntity Create<TEntity>()
        {
            var entity = (TEntity)Create(typeof(TEntity));
            return entity;
        }

        public object Create(Type type)
        {
            var generator = _generators.FirstOrDefault(g => g.CanGenerate(type));
            if (generator != null)
            {
                return generator.Generate(type, _context);
            }

            if (_generatedTypes.Contains(type))
            {
                return Default(type);
            }
            _generatedTypes.Add(type);

            if (!TryConstructObject(type, out var constructedObject))
            {
                return Result(constructedObject, type);
            }
            FillMembers(type, constructedObject);

            return Result(constructedObject, type);
        }

        private bool TryConstructObject(Type type, out object constructedObject)
        {
            constructedObject = Default(type);

            var constructors = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .ToList();
            
            foreach (var constructor in constructors)
            {
                try
                {
                    constructedObject = constructor.Invoke(
                        constructor.GetParameters()
                            .Select(p => GenerateMemberValue(type, p.ParameterType, p.Name))
                            .ToArray());
                    return true;
                }
                catch { }
            }

            return false;
        }

        private bool HasGenerator(Type type, string field) => _config != null && _config.HasGenerator(type, field);

        private object GenerateMemberValue(Type type, Type memberType, string memberName)
        {
            if (_config != null && _config.TryGetGenerator(type, memberName, out var generator))
            {
                return generator.Generate(memberType, _context) ?? Create(memberType);
            }

            return Create(memberType);
        }

        private static List<IGenerator> LoadGeneratorsFromAssembly()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var generators = assembly.DefinedTypes
                .Where(t => t.IsAssignableTo(typeof(IGenerator)) && t.IsClass)
                .Select(i => (IGenerator)Activator.CreateInstance(i))
                .ToList();

            return generators;
        }

        private void FillMembers(Type objectType, object constructedObject)
        {
            var fields = objectType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                var isDefault = Equal(field.GetValue(constructedObject), Default(field.FieldType));
                var hasGenerator = HasGenerator(objectType, field.Name);
                if (field.IsInitOnly || (!(isDefault || hasGenerator)))
                {
                    continue;
                }

                var value = GenerateMemberValue(objectType, field.FieldType, field.Name);
                field.SetValue(constructedObject, value);
            }

            var properties = objectType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var property in properties)
            {
                var isIndexer = property.GetIndexParameters().Any();
                var hasGenerator = HasGenerator(objectType, property.Name);
                if ((!property.CanWrite)
                    || isIndexer
                    || (!(Equal(property.GetValue(constructedObject), Default(property.PropertyType)) || hasGenerator)))
                {
                    continue;
                }

                var value = GenerateMemberValue(objectType, property.PropertyType, property.Name);
                property.SetValue(constructedObject, value);
            }
        }

        private static bool Equal(object obj1, object obj2) => obj1 != null ? obj1.Equals(obj2) : obj2 == null;

        private static object Default(Type type) => type.IsValueType ? Activator.CreateInstance(type) : null;

        private object Result(object obj, Type type)
        {
            _generatedTypes.Remove(type);
            return obj;
        }
    }
}
