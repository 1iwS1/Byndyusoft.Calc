using Calc.Core.Models.Common;


namespace Calc.Core.Models
{
  public class Operator : IExpressionElement
  {
    public char Symbol { get; set; }
    public int Precedence { get; set; }
  }
}
