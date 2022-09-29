using Faker.Core.Interfaces;
using System.Linq.Expressions;
using System.Reflection;

var config = new Config();
config.Add<Config, string, Generator>(c => c.Name);
var intType = typeof(int);
foreach (var constructor in intType.GetConstructors())
{
    Console.WriteLine(constructor.GetParameters().Select(p => p.Name).ToArray());
}
Console.ReadLine();


class Config : IFakerConfig
{
    public string Name { get; set; }
    
    public void Add<TEntity, TField, TGenerator>(Expression<Func<TEntity, TField>> expression) where TGenerator : IGenerator
    {
        var memberExpression = expression.Body as MemberExpression;
        if (memberExpression == null)
        {
            throw new ArgumentException("Invalid expression type. MemberExpression expected", nameof(expression));
        }

        var name = memberExpression.Member.Name;
        Console.WriteLine(name);
    }
}

class Generator : IGenerator
{

}
