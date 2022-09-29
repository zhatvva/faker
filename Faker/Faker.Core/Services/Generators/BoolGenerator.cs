using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class BoolGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(bool);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = context.Random.NextSingle() >= 0.5f;
            return value;
        }
    }
}
