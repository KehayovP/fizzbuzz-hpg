using FizzBuzz.HPG.Abstractions;

namespace FizzBuzz.HPG;

public class RuleEngine
{
    private readonly ITokenRule[] _rulesInOrder;
    private readonly IFizzBuzzConsoleOutput _output;

    public RuleEngine(IEnumerable<ITokenRule> rules, IFizzBuzzConsoleOutput output)
    {
        _rulesInOrder = rules.OrderBy(r => r.Order).ToArray();
        _output = output;
    }

    public void RunRange(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            _output.WriteToConsole(Evaluate(i));
        }
    }
    
    private string Evaluate(int number)
    {
        var hadAny = false;
        var builder = new System.Text.StringBuilder();
        foreach (var rule in _rulesInOrder)
        {
            var token = rule.GetToken(number);
            if (!string.IsNullOrEmpty(token))
            {
                hadAny = true;
                builder.Append(token);
            }
        }

        return hadAny ? builder.ToString() : number.ToString();
    }
}