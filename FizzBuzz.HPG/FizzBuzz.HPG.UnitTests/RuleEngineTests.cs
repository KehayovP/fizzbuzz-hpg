using FizzBuzz.HPG.Abstractions;
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
            consoleOutput.WriteToConsole("1");
            consoleOutput.WriteToConsole("2");
            consoleOutput.WriteToConsole("3");
        });
    }
    
    [Fact]
    public void RunRange_AppliesRulesInAscendingOrderAndConcatenatesTokens()
    {
        // Arrange
        var lateRule = Substitute.For<ITokenRule>();
        lateRule.Order.Returns(20);
        lateRule.GetToken(Arg.Any<int>()).Returns("B");

        var earlyRule = Substitute.For<ITokenRule>();
        earlyRule.Order.Returns(10);
        earlyRule.GetToken(Arg.Any<int>()).Returns("A");

        var output = Substitute.For<IFizzBuzzConsoleOutput>();
        var engine = new RuleEngine(new[] { lateRule, earlyRule }, output);

        // Act
        engine.RunRange(1, 1);

        // Assert: "A" should come before "B"
        output.Received(1).WriteToConsole("AB");
    }
}