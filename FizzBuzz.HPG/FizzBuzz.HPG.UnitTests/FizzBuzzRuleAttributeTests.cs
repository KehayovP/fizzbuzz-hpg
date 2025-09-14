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
}