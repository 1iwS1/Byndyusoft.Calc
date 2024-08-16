using Calc.Application.Abstractions;
using Calc.Core.Models;
using Calc.Core.Models.Common;
using System.Net.Http.Headers;


namespace Calc.Application.Services
{
  public class CalculatePostfixService : ICalculateService
  {
    public double GetResultOfExpression(Queue<IExpressionElement> postfixForm)
    {
      Stack<double> stack = new();

      foreach (var element in postfixForm)
      {
        switch (element)
        {
          case Operand number:
            stack.Push(number.Value);
            break;

          case IOperator operation:
            var top = stack.Pop();
            var bottom = stack.Pop();

            stack.Push(operation.Operation(bottom, top));

            break;
        }
      }

      return stack.Pop();
    }
  }
}
