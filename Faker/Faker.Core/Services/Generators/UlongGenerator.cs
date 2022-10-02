using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class UlongGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(ulong);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = (ulong)context.Random.NextInt64(sbyte.MaxValue - 1) + 1;
            return value;
        }
    }
}
