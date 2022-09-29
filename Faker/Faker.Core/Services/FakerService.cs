using Faker.Core.Interfaces;

namespace Faker.Core.Services
{
    public class FakerService : IFaker
    {
        private readonly IFakerConfig _config;

        public FakerService()
        {

        }

        public FakerService(IFakerConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public TEntity Create<TEntity>()
        {
            var entity = (TEntity)Create(typeof(TEntity));
            return entity;
        }

        private object Create(Type type)
        {

        }
    }
}
