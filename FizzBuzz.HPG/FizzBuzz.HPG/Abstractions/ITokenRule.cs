namespace FizzBuzz.HPG.Abstractions;

public interface ITokenRule
{
    int Order { get; }
    string? GetToken(int number);
}