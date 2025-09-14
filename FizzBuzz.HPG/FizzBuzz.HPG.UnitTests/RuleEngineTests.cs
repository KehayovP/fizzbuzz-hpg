using NSubstitute;

namespace FizzBuzz.HPG.UnitTests;

public class RuleEngineTests
{
    [Fact]
    public void RunRange_WritesNumberWhenNoRuleMatches()
    {
        // Arrange
        var rule = Substitute.For<ITokenRule>();
        rule.Order.Returns(0);
        rule.GetToken(Arg.Any<int>()).Returns((string?)null);

        var consoleOutput = Substitute.For<IFizzBuzzConsoleOutput>();
        var engine = new RuleEngine(new[] { rule }, consoleOutput);

        // Act
        engine.RunRange(1, 3);

        // Assert
        Received.InOrder(() =>
        {
            consoleOutput.WriteToConsole(1);
            consoleOutput.WriteToConsole(2);
            consoleOutput.WriteToConsole(3);
        });
    }
}