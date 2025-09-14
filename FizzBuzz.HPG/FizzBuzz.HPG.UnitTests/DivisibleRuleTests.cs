namespace FizzBuzz.HPG.UnitTests;

public class DivisibleRuleTests
{
    [Fact]
    public void GetToken_WhenNumberIsDivisibleByDivisor_ReturnsToken()
    {
        // Arrange
        var rule = new DivisibleRule(divisor: 3, token: "Fizz", order: 10);

        // Act
        var result = rule.GetToken(6);

        // Assert
        Assert.Equal("Fizz", result);
    }
}