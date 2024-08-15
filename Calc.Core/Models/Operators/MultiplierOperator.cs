using Calc.Core.Models.Common;


namespace Calc.Core.Models.Operators
{
  public class MultiplierOperator : IExpressionElement, IOperator
  {
    private int Precedence { get; } = 2;

    public int GetPrecedence()
    {
      return Precedence;
    }

    public double Operation(double a, double b)
    {
      return a * b;
    }
  }
}
