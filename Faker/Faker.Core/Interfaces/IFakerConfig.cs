using System.Linq.Expressions;

namespace Faker.Core.Interfaces
{
    public interface IFakerConfig
    {
        public void Add<TType, TField, TGenerator>(Expression<Func<TType, TField>> expression) where TGenerator : IGenerator;
    }
}
