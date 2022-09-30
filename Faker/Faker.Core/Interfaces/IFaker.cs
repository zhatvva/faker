namespace Faker.Core.Interfaces
{
    public interface IFaker
    {
        public TEntity Create<TEntity>();
        public object Create(Type type);
    }
}
