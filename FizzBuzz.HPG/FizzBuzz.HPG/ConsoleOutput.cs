using FizzBuzz.HPG.Abstractions;

namespace FizzBuzz.HPG;

public class ConsoleOutput : IFizzBuzzConsoleOutput
{
    public void WriteToConsole(string value)
    {
        Console.WriteLine(value);
    }
}