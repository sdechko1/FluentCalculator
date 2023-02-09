using System.Collections;

namespace FluentCalculator.Tests;

public class FluentCalculatorTestData: IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new Calculator().One,
            1
        };
        yield return new object[]
        {
            new Calculator().One.Plus.Nine,
            10
        };
        yield return new object[]
        {
            new Calculator().Six.Plus.One.Times.Two.Plus.Three.DivideBy.Three,
            9
        };
        yield return new object[]
        {
            new Calculator().One.Plus.Two.Plus.Three.Minus.Eight.Minus.Two.Minus.Four,
            -8
        };
        yield return new object[]
        {
            new Calculator().Two.Times.Three.Plus.Three.DivideBy.Two.Minus.Two.Minus.Two.Plus.One,
            4.5
        };
        yield return new object[]
        {
            new Calculator().Two.Times.Three.Plus.Three.DivideBy.Two.Minus.Two.Minus.Two,
            3.5
        };
        yield return new object[]
        {
            new Calculator().Two.Times.Three.Plus.Two.Minus.Two.Minus.Two,
            4
        };
        yield return new object[]
        {
            new Calculator().Ten.Minus.Seven.Minus.Three,
            0
        };
        yield return new object[]
        {
            new Calculator().Ten.DivideBy.Two.Times.Three,
            15
        };
        yield return new object[]
        {
            new Calculator().Zero.Minus.Zero.Minus.Five,
            -5
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}