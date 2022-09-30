using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    public class DateTimeGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(DateTime);

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var year = context.Random.Next(1500) + 1000;
            var month = context.Random.Next(12) + 1;
            var day = context.Random.Next(28) + 1;

            var result = new DateTime(year, month, day);
            return result;
        }
    }
}
