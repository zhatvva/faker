using System.Linq.Expressions;

namespace Faker.Core.Interfaces
{
    public interface IFakerConfig
    {
        public void AddGenerator<TType, TField, TGenerator>(Expression<Func<TType, TField>> expression) where TGenerator : IGenerator;
        public bool TryGetGenerator(Type type, string field, out IGenerator generator);
    }
}
