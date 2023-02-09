using FluentAssertions;

namespace FluentCalculator.Tests;

public class FluentCalculatorTests
{
    [Theory]
    [ClassData(typeof(FluentCalculatorTestData))]
    public void FluentCalculator_ValidInput_Ok(double actual, double expected)
    {
        actual.Should().Be(expected);
    }

    [Fact]
    public void FluentCalculator_InvalidInputValueAfterValue_ThrowsInvalidOperationException()
    {
        var calculator = new Calculator();
        var act = () => calculator.Five.Seven;
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("A value can not be followed by another value.");
    }

    [Fact]
    public void FluentCalculator_InvalidInputOperationAfterOperation_ThrowsInvalidOperationException()
    {
        var calculator = new Calculator();
        var act = () => calculator.Five.Minus.Plus;
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("An operation can not be followed by another operation.");
    }

    [Fact]
    public void FluentCalculator_InvalidInputExpressionStartsWithOperation_ThrowsInvalidOperationException()
    {
        var calculator = new Calculator();
        var act = () => calculator.Minus.Eight.Plus.Four;
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("An expression should not start with operation.");
    }
    
    [Fact]
    public void FluentCalculator_InvalidInputExpressionEndsWithOperation_ThrowsInvalidOperationException()
    {
        var calculator = new Calculator();
        var act = () =>
        {
            double a = calculator.Eight.Plus.Four.Minus;
        };
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("An expression should not end with operation.");
    }
}