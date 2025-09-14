using FizzBuzz.HPG.Abstractions;

namespace FizzBuzz.HPG;

public class RuleEngine
{
    private readonly ITokenRule[] _rulesInOrder;
    private readonly IFizzBuzzConsoleOutput _output;

    public RuleEngine(IEnumerable<ITokenRule> rules, IFizzBuzzConsoleOutput output)
    {
        _rulesInOrder = rules.ToArray();
        _output = output;
    }

    public void RunRange(int start, int end)
    {
        for (int i = start; i <= end; i++)
        {
            _output.WriteToConsole(i.ToString());
        }
    }
}