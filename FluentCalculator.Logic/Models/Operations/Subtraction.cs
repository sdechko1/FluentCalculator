using System.Numerics;
using FluentCalculator.Logic.Interfaces;

namespace FluentCalculator.Logic.Models.Operations;

public sealed class Subtraction<T> : IOperation<T> where T : INumber<T>
{
    public int Priority => 1;
    
    public T Compute(T first, T second) => first - second;
}