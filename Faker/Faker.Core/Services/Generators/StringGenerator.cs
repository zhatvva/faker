using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    public class StringGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(string);

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var length = context.Random.Next(99) + 2;
            var buffer = new byte[length];
            context.Random.NextBytes(buffer);
            var value = Convert.ToBase64String(buffer);
            return value;
        }
    }
}
