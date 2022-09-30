﻿using Faker.Core.Entities;
using Faker.Core.Interfaces;

namespace Faker.Core.Services.Generators
{
    internal class ByteGenerator : IGenerator
    {
        public bool CanGenerate(Type type) => type == typeof(byte);

        public object Generate(Type _, GeneratorContext context)
        {
            var value = (byte)context.Random.Next(byte.MaxValue);
            return value;
        }
    }
}