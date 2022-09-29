using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class CharGenerator : IGenerator
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public bool CanGenerate(Type type) => type == typeof(char);

        public object Generate(Type _, GeneratorContext context)
        {
            var position = context.Random.Next(Chars.Length - 1);
            var value = Chars[position];
            return value;
        }
    }
}
