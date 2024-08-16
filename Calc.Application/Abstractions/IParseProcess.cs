using Calc.Core.Models.Common;


namespace Calc.Application.Abstractions
{
  public interface IParseProcess
  {
    Queue<IExpressionElement> GetInfixExpression(string sourceExpression);
  }
}
