using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class LongGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(long);
        
        public object Generate(Type _, GeneratorContext context)
        {
            var value = context.Random.NextInt64(long.MaxValue - 1) + 1;
            return value;
        }
    }
}
