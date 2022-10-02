using Faker.Core.Services;
using System;
using Xunit;
using System.Collections.Generic;
using Faker.Core.Entities;
using Faker.Core.Tests.Generators;
using Faker.Core.Tests.Models;

namespace Faker.Core.Tests
{
    public class FakerTests
    {
        [Fact]
        public void PredefinedGenerators()
        {
            var faker = new FakerService();

            Assert.NotEqual(default, faker.Create<byte>());
            Assert.NotEqual(default, faker.Create<char>());
            Assert.NotEqual(default, faker.Create<DateTime>());
            Assert.NotEqual(default, faker.Create<decimal>());
            Assert.NotEqual(default, faker.Create<double>());
            Assert.NotEqual(default, faker.Create<float>());
            Assert.NotEqual(default, faker.Create<int>());
            Assert.NotEqual(default, faker.Create<List<int>>());
            Assert.NotEqual(default, faker.Create<long>());
            Assert.NotEqual(default, faker.Create<sbyte>());
            Assert.NotEqual(default, faker.Create<short>());
            Assert.NotEqual(default, faker.Create<string>());
            Assert.NotEqual(default, faker.Create<uint>());
            Assert.NotEqual(default, faker.Create<ulong>());
            Assert.NotEqual(default, faker.Create<ushort>());
        }

        [Fact]
        public void FakerConfig()
        {
            var config = new FakerConfig();
            config.AddGenerator<Man, string, ManNameGenerator>(m => m.Name);
            var faker = new FakerService(config);

            var man = faker.Create<Man>();

            Assert.Equal(Man.NameToConfigure, man.Name);
        }

        [Fact]
        public void ConstructorSettedValues()
        {
            var config = new FakerConfig();
            config.AddGenerator<Man, string, ManNameGenerator>(m => m.Name);
            var faker = new FakerService(config);

            var man = faker.Create<Man>();

            Assert.Equal(Man.DefaultDateOfBirth, man.DateOfBirth);
        }

        [Fact]
        public void ListBuilding()
        {
            var faker = new FakerService();

            var list = faker.Create<List<int>>();
            var listOfLists = faker.Create<List<List<int>>>();

            Assert.NotNull(list);
            Assert.NotEmpty(list);
            foreach (var item in list)
            {
                Assert.NotEqual(default, item);
            }

            Assert.NotNull(listOfLists);
            Assert.NotEmpty(listOfLists);
            foreach (var innerList in listOfLists)
            {
                Assert.NotNull(innerList);
                Assert.NotEmpty(innerList);
                foreach (var item in innerList)
                {
                    Assert.NotEqual(default, item);
                }
            }
        }

        [Fact]
        public void CycleDependency()
        {
            var faker = new FakerService();

            var man = faker.Create<Man>();

            Assert.NotNull(man);
            Assert.NotNull(man.Dogs);
            Assert.NotEmpty(man.Dogs);
            foreach (var dog in man.Dogs)
            {
                Assert.Null(dog.Man);
            }
        }

        [Fact]
        public void StructCreation()
        {
            var faker = new FakerService();

            var dog = faker.Create<Dog>();

            Assert.NotEqual(default, dog.Name);
            Assert.NotEqual(default, dog.Man);
            Assert.NotEqual(default, dog.Id);
            Assert.NotEqual(default, dog.Man);
            
            Assert.NotNull(dog.Chars);
            Assert.NotEmpty(dog.Chars);
            foreach (var item in dog.Chars)
            {
                Assert.NotEqual(default, item);
            }
        }
    }
}