using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class UintGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(uint);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = (uint)context.Random.NextInt64(sbyte.MaxValue - 1) + 1;
            return value;
        }
    }
}
