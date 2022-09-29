using Faker.Core.Interfaces;

namespace Faker.Core.Entities
{
    public class GeneratorContext
    {
        public Random Random { get; }
        public IFaker Faker { get; }

        public GeneratorContext(Random random, IFaker faker)
        {
            Random = random ?? throw new ArgumentNullException(nameof(random));
            Faker = faker ?? throw new ArgumentNullException(nameof(faker));
        }
    }
}
