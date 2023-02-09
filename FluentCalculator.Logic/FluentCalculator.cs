using FluentCalculator.Logic.Helpers;
using FluentCalculator.Logic.Interfaces;
using FluentCalculator.Logic.Interfaces.Base;
using FluentCalculator.Logic.Models.Operand;
using FluentCalculator.Logic.Models.Operations;

namespace FluentCalculator.Logic;

public class FluentCalculator
{
    private readonly List<IExpressionToken> _reversePolishNotation = new();
    private readonly Stack<IOperation<double>> _operations = new();

    private bool _wasOperandEntered = false;
    private bool _isLastTokenIsOperation = true;
    
    public FluentCalculator Zero => Operate(new Operand<double> { Value = 0});
    public FluentCalculator One => Operate(new Operand<double> { Value = 1});
    public FluentCalculator Two => Operate(new Operand<double> { Value = 2});
    public FluentCalculator Three => Operate(new Operand<double> { Value = 3});
    public FluentCalculator Four => Operate(new Operand<double> { Value = 4});
    public FluentCalculator Five => Operate(new Operand<double> { Value = 5});
    public FluentCalculator Six => Operate(new Operand<double> { Value = 6});
    public FluentCalculator Seven => Operate(new Operand<double> { Value = 7});
    public FluentCalculator Eight => Operate(new Operand<double> { Value = 8});
    public FluentCalculator Nine => Operate(new Operand<double> { Value = 9});
    public FluentCalculator Ten => Operate(new Operand<double> { Value = 10});

    public FluentCalculator Plus => PerformOperation(new Addition<double>());
    public FluentCalculator Minus => PerformOperation(new Subtraction<double>());
    public FluentCalculator Times => PerformOperation(new Multiplication<double>());
    public FluentCalculator DivideBy => PerformOperation(new Division<double>());

    public static implicit operator double(FluentCalculator calculator)
    {
        if (calculator._isLastTokenIsOperation)
        {
            throw new InvalidOperationException("An expression should not end with operation.");
        }
        
        while (calculator._operations.Count > 0)
        {
            calculator._reversePolishNotation.Add(calculator._operations.Pop());
        }

        return ReversePolishNotation.Solve<double>(calculator._reversePolishNotation);
    }
    
    private FluentCalculator Operate(IOperand<double> value)
    {
        if (!_isLastTokenIsOperation)
        {
            throw new InvalidOperationException("A value can not be followed by another value.");
        }

        _wasOperandEntered = true;
        _isLastTokenIsOperation = false;
        _reversePolishNotation.Add(value);
        return this;
    }
    
    private FluentCalculator PerformOperation(IOperation<double> operation)
    {
        if (!_wasOperandEntered)
        {
            throw new InvalidOperationException("An expression should not start with operation.");
        }
        
        if (_isLastTokenIsOperation)
        {
            throw new InvalidOperationException("An operation can not be followed by another operation.");
        }

        _isLastTokenIsOperation = true;
        if (_operations.Count == 0)
        {
            _operations.Push(operation);
            return this;
        }
        
        if (operation.Priority > _operations.Peek().Priority)
        {
            _operations.Push(operation);
        }
        else
        {
            while (_operations.Count > 0 && operation.Priority <= _operations.Peek().Priority)
            {
                var poppedOperation = _operations.Pop();
                _reversePolishNotation.Add(poppedOperation);
            }
            
            _operations.Push(operation);
        }

        return this;
    }
}