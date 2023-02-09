using FluentCalculator.Logic.Interfaces;
using FluentCalculator.Logic.Interfaces.Base;

namespace FluentCalculator.Logic.Helpers;

public static class ReversePolishNotation
{
    public static T Solve<T>(List<IExpressionToken> tokens)
    {
        var tempStack = new Stack<T>();
        foreach (var token in tokens)
        {
            if (token is IOperation<T> operation)
            {
                var secondOperand = tempStack.Pop();
                var firstOperand = tempStack.Pop();
                tempStack.Push(operation.Compute(firstOperand, secondOperand));
                continue;
            }
            
            tempStack.Push((token as IOperand<T>).Value);
        }

        return tempStack.Peek();
    }
}