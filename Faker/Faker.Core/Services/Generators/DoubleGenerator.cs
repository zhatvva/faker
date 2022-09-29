using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class DoubleGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(double);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = context.Random.NextDouble();
            return value;
        }
    }
}
