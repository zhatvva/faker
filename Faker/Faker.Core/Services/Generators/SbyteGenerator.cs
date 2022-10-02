using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class SbyteGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(sbyte);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = (sbyte)(context.Random.Next(sbyte.MaxValue - 1) + 1);
            return value;
        }
    }
}
