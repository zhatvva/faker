using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class FloatGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(float);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = context.Random.NextSingle();
            return value;
        }
    }
}
