using Calc.Core.Models.Common;


namespace Calc.Core.Models
{
  public class PlusOperator : IOperator
  {
    //public char Symbol { get; } = '+';
    public int Precedence { get; } = 1;

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
