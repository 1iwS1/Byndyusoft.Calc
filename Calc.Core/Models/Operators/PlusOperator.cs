using Calc.Core.Models.Common;


namespace Calc.Core.Models.Operators
{
  public class PlusOperator : IExpressionElement, IOperator
  {
    private int Precedence { get; } = 1;

    public int GetPrecedence()
    {
      return Precedence;
    }

    public double Operation(double a, double b)
    {
      return a + b;
    }
  }
}
