using Faker.Core.Entities;
using Faker.Core.Interfaces;
using Faker.Core.Services;

var config = new FakerConfig();
config.AddGenerator<Dog, string, DogNameGenerator>(d => d.Name);
config.AddGenerator<Man, string, ManNameGenerator>(m => m.Name);
config.AddGenerator<Dog, List<char>, DogCharsGenerator>(d => d.Chars);

var faker = new FakerService(config);
var int1 = faker.Create<int>();
var dateTime = faker.Create<DateTime>();
var list = faker.Create<List<int>>();
var dog = faker.Create<Dog>();
var man = faker.Create<Man>();

Console.ReadLine();

class DogNameGenerator : IGenerator
{
    public bool CanGenerate(Type type) => type == typeof(string);
    public object Generate(Type typeToGenerate, GeneratorContext context) => "Chembra";
}

class DogCharsGenerator : IGenerator
{
    public bool CanGenerate(Type type) => type == typeof(List<int>);

    public object Generate(Type typeToGenerate, GeneratorContext context) => new List<char>() { 'a', 'b', 'c' };
}

class ManNameGenerator : IGenerator
{
    public bool CanGenerate(Type type) => type == typeof(string);

    public object Generate(Type typeToGenerate, GeneratorContext context) => "Maksik";
}

struct Dog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Man Man { get; set; }
    public List<char> Chars { get; set; }
}

class Man
{
    public int Id { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Dog> Dogs { get; set; }
    public string Name { get; set; }

    public Man()
    {
        DateOfBirth = new DateTime(1990, 1, 1);
    }
}