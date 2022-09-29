using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class ShortGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(short);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = (short)context.Random.Next(ushort.MaxValue - 1) - short.MaxValue;
            return value;
        }
    }
}
