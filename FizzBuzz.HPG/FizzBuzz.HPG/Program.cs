using System.Reflection;
using FizzBuzz.HPG.Attributes;

[assembly: FizzBuzzRule(3, "Fizz", order: 10)]
[assembly: FizzBuzzRule(5, "Buzz", order: 20)]

namespace FizzBuzz.HPG;

class Program
{
    static void Main(string[] args)
    {
        // Discover rule attributes on the assembly and turn them into runtime rules
        var rules = Assembly.GetExecutingAssembly()
            .GetCustomAttributes<FizzBuzzRuleAttribute>()
            .Select(attr => attr.ToRule());

        var output = new ConsoleOutput();
        var engine = new RuleEngine(rules, output);

        engine.RunRange(1, 100);
    }
}