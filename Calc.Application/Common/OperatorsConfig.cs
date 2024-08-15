using Calc.Core.Models.Operators;
using Calc.Core.Models.Common;
using Calc.Core.Models;


namespace Calc.Application.Common
{
  public class OperatorsConfig
  {
    public Dictionary<char, IExpressionElement> Config = new()
    {
      { '(', new LeftParenthesis() },
      { ')', new RightParenthesis() },
      { '+', new PlusOperator() },
      { '-', new MinusOperator() },
      { '*', new MultiplierOperator() },
      { '/', new DivisionOperator() }
    };
  }
}
