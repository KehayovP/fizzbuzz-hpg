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
    
    [Fact]
    public void GetToken_WhenNumberIsNotDivisibleByDivisor_ReturnsNull()
    {
        // Arrange
        var rule = new DivisibleRule(divisor: 5, token: "Buzz", order: 20);

        // Act
        var result = rule.GetToken(6);

        // Assert
        Assert.Null(result);
    }
}