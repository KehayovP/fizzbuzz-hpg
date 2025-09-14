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
}