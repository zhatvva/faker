using Faker.Core.Interfaces;
using System.Linq.Expressions;
using Faker.Core.Extensions;

namespace Faker.Core.Entities
{
    public class FakerConfig : IFakerConfig
    {            
        private Dictionary<Type, Dictionary<string, IGenerator>> _configuredGenerators = new();

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

        public IGenerator GetGenerator(Type type, string field)
        {
            if (!_configuredGenerators.TryGetValue(type, out var generators))
            {
                return null;
            }

            if (!generators.TryGetValue(field, out var generator))
            {
                return null;
            }

            return generator;
        }
    }
}
