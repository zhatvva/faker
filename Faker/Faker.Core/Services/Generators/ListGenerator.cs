using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    public class ListGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => 
            type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);

        public object Generate(Type typeToGenerate, GeneratorContext context)
        {
            var genericType = typeToGenerate.GetGenericArguments().First();
            var count = context.Random.Next(29) + 2;
            var values = Array.CreateInstance(genericType, count);
            for (var i = 0; i < count; i++)
            {
                var generatedValue = context.Faker.Create(genericType);
                values.SetValue(generatedValue, i);
            }

            var listType = typeof(List<>).MakeGenericType(genericType);
            var resltl = Activator.CreateInstance(listType, values); 

            return resltl;
        }
    }
}
