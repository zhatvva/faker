using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class IntGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(int);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = context.Random.Next(sbyte.MaxValue - 1) + 1;
            return value;
        }
    }
}
