using FizzBuzz.HPG.Abstractions;

namespace FizzBuzz.HPG;

public sealed class DivisibleRule : ITokenRule
{
    public int Divisor { get; }
    public string Token { get; }
    public int Order { get; }

    public DivisibleRule(int divisor, string token, int order)
    {
        Divisor = divisor;
        Token = token;
        Order = order;
    }

    public string? GetToken(int number)
    {
        return number % Divisor == 0 ? Token : null;
    }
}