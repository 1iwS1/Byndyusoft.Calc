using Calc.Core.Models.Common;


namespace Calc.Core.Models
{
  public class Operator : IExpressionElement
  {
    public required char Symbol { get; set; }
    public required int Precedence { get; set; }
    public required Func<double, double, double> Operation { get; set; }
  }
}
