using FluentCalculator.Logic.Interfaces;

namespace FluentCalculator.Logic.Models.Operand;

public sealed class Operand<T> : IOperand<T>
{
    public T Value { get; set; }
}