using Calc.Core.Models.Common;


namespace Calc.Application.Abstractions
{
  public interface ICalculateService
  {
    double GetResultOfExpression(Queue<IExpressionElement> postfixForm);
  }
}