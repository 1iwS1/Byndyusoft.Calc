using Calc.Application.Abstractions;
using Calc.Core.Models.Common;
using Calc.Core.Models;


namespace Calc.Application.Services
{
  public class ConvertFromInfixToPostfix : IConverter
  {
    public Queue<IExpressionElement> GetPostfixExpression(Queue<IExpressionElement> infixForm)
    {
      Queue<IExpressionElement> postfixForm = new();
      Stack<IExpressionElement> stack = new();

      foreach (var element in infixForm)
      {
        switch (element)
        {
          case Operand number:
            postfixForm.Enqueue(number);
            break;

          case IOperator operation:
            while (stack.TryPeek(out var op)
              && op is IOperator topElement
              && (topElement.GetPrecedence() >= operation.GetPrecedence()))
            {
              postfixForm.Enqueue(stack.Pop());
            }

            stack.Push((IExpressionElement)operation);
            break;

          case LeftParenthesis:
            stack.Push(element);
            break;

          case RightParenthesis:
            while (stack.TryPeek(out var op) && op is not LeftParenthesis)
            {
              postfixForm.Enqueue(stack.Pop());
            }

            stack.Pop();
            break;
        }
      }

      while (stack.Count > 0)
      {
        postfixForm.Enqueue(stack.Pop());
      }

      return postfixForm;
    }
  }
}
