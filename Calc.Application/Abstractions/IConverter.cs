using Calc.Core.Models.Common;


namespace Calc.Application.Abstractions
{
  public interface IConverter
  {
    Queue<IExpressionElement> GetPostfixExpression(Queue<IExpressionElement> infix);
  }
}