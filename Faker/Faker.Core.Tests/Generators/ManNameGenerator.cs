using Faker.Core.Entities;
using Faker.Core.Interfaces;
using System;
using Faker.Core.Tests.Models;

namespace Faker.Core.Tests.Generators
{
    class ManNameGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(string);

        public object Generate(Type typeToGenerate, GeneratorContext context) => Man.NameToConfigure;
    }
}
