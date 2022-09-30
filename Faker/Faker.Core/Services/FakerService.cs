using Faker.Core.Interfaces;
using System.Reflection;

namespace Faker.Core.Services
{
    public class FakerService : IFaker
    {
        private readonly IFakerConfig _config;
        private readonly List<IGenerator> _generators;

        public FakerService()
        {
            _generators = LoadGeneratorsFromAssembly();
        }

        public FakerService(IFakerConfig config) : base()
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
            throw new NotImplementedException();
        }

        private static List<IGenerator> LoadGeneratorsFromAssembly()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var generators = assembly.DefinedTypes
                .Where(t => t.IsAssignableTo(typeof(IGenerator)) && t.IsClass)
                .ToList();
            
            var result = new List<IGenerator>(generators.Count);
            foreach (var generator in generators)
            {
                var instance = (IGenerator)Activator.CreateInstance(generator);
                result.Add(instance);
            }

            return result;
        }
    }
}
