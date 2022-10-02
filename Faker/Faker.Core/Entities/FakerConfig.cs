using Faker.Core.Interfaces;
using System.Linq.Expressions;
using Faker.Core.Extensions;

namespace Faker.Core.Entities
{
    public class FakerConfig : IFakerConfig
    {            
        private readonly Dictionary<Type, Dictionary<string, IGenerator>> _configuredGenerators = new();

        public void AddGenerator<TType, TField, TGenerator>(Expression<Func<TType, TField>> expression) where TGenerator : IGenerator
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Invalid expression type. MemberExpression expected", nameof(expression));
            }
            
            var fieldName = memberExpression.Member.Name;
            var type = typeof(TType);
            var generator = (IGenerator)Activator.CreateInstance(typeof(TGenerator));

            var generators = _configuredGenerators.GetOrAdd(type, new());
            generators.AddOrUpdate(fieldName, generator);
        }

        public bool TryGetGenerator(Type type, string field, out IGenerator generator)
        {
            generator = null;
            if (!_configuredGenerators.TryGetValue(type, out var generators))
            {
                return false;
            }

            if (!generators.TryGetValue(field, out generator))
            {
                return false;
            }

            return true;
        }

        public bool HasGenerator(Type type, string field)
        {
            if (!_configuredGenerators.TryGetValue(type, out var generators))
            {
                return false;
            }

            return generators.ContainsKey(field);
        }
    }
}
