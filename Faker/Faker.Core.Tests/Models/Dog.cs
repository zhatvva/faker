using System.Collections.Generic;

namespace Faker.Core.Tests.Models
{
    public struct Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Man Man { get; set; }
        public List<char> Chars { get; set; }
    }
}
