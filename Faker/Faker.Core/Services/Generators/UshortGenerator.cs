using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class UshortGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(ushort);
        
        public object Generate(Type _, GeneratorContext context)
        {
            var value = (ushort)context.Random.Next(sbyte.MaxValue - 1) + 1;
            return value;
        }
    }
}
