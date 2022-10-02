using System;
using System.Collections.Generic;

namespace Faker.Core.Tests.Models
{
    public class Man
    {
        public const string NameToConfigure = "Maksik";
        public readonly static DateTime DefaultDateOfBirth = new(1990, 1, 1);
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; } = DefaultDateOfBirth;
        public List<Dog> Dogs { get; set; }
        public string Name { get; set; }

        public Man(string name)
        {
            Name = name;
        }
    }
}
