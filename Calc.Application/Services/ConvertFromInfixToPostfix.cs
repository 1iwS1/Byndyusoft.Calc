using Calc.Application.Abstractions;
using Calc.Core.Models.Common;


namespace Calc.Application.Services
{
  public class ConvertFromInfixToPostfix : IConverter
  {
    public Queue<IExpressionElement> GetPostfixExpression(Queue<IExpressionElement> infix)
    {
      throw new NotImplementedException();
    }
  }
}
