namespace Faker.Core.Tests.Models
{
    public struct Cat
    {
        public const string DefaultName = "Bagira";

        public string Name { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }

        public Cat(int age, string color)
        {
            Name = DefaultName;
            Age = age;
            Color = color;
        }
    }
}
