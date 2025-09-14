using FizzBuzz.HPG.Abstractions;
using FizzBuzz.HPG.Attributes;

namespace FizzBuzz.HPG.UnitTests;

public class FizzBuzzRuleAttributeTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Ctor_WithNonPositiveDivisor_Throws(int divisor)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new FizzBuzzRuleAttribute(divisor, "X", 0));
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Ctor_WithInvalidToken_Throws(string token)
    {
        var exception = Assert.Throws<ArgumentException>(() => new FizzBuzzRuleAttribute(3, token, 0));
        Assert.Equal("Token required (Parameter 'token')", exception.Message);
    }
    
    [Fact]
    public void ToRule_ReturnsDivisibleRuleWithSameProperties()
    {
        // Arrange
        var attr = new FizzBuzzRuleAttribute(5, "Buzz", 20);

        // Act
        var method = typeof(FizzBuzzRuleAttribute)
            .GetMethod("ToRule", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var rule = method!.Invoke(attr, null) as ITokenRule;

        // Assert
        Assert.NotNull(rule);
        var divRule = Assert.IsType<DivisibleRule>(rule);
        Assert.Equal(5, divRule.Divisor);
        Assert.Equal("Buzz", divRule.Token);
        Assert.Equal(20, divRule.Order);
    }
}