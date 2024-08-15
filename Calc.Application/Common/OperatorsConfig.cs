using Calc.Core.Models;
using Calc.Core.Models.Common;


namespace Calc.Application.Common
{
  public class OperatorsConfig
  {
    public static Dictionary<char, IExpressionElement> Config = new()
    {
      { '+', new PlusOperator() }
    };
  }
}
