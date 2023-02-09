using FluentCalculator.Logic.Interfaces.Base;

namespace FluentCalculator.Logic.Interfaces;

public interface IOperand<T> : IExpressionToken
{
    T Value { get; set; }
}