namespace FizzBuzz.HPG.Attributes;

public class FizzBuzzRuleAttribute : Attribute
{
    public int Divisor { get; }
    public string Token { get; }
    public int Order { get; }

    public FizzBuzzRuleAttribute(int divisor, string token, int order)
    {
        if (divisor <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(divisor));
        }

        if (string.IsNullOrWhiteSpace(token))
        {
            throw new ArgumentException("Token required", nameof(token));
        }

        Divisor = divisor;
        Token = token;
        Order = order;
    }
}