using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class ShortGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(short);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = (short)((short)context.Random.Next(short.MaxValue - 1) + 1);
            return value;
        }
    }
}
