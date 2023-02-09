using FluentCalculator.Logic.Interfaces.Base;

namespace FluentCalculator.Logic.Interfaces;

public interface IOperation<T> : IExpressionToken
{
    int Priority { get; }

    T Compute(T first, T second);
}