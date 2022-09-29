using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class DecimalGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(decimal);

        public object Generate(Type _, GeneratorContext context)
        {
            var scale = (byte)context.Random.Next(29);
            var sign = context.Random.Next(2) == 1;
            var value = new decimal(context.Random.Next(),
                context.Random.Next(),
                context.Random.Next(),
                sign,
                scale);
            return value;
        }
    }
}
