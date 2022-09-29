using Faker.Core.Entities;

namespace Faker.Core.Interfaces
{
    public interface IGenerator
    {
        public object Generate(Type typeToGenerate, GeneratorContext context);
        public bool CanGenerate(Type type);
    }
}
