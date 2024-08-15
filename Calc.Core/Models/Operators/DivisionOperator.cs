using Calc.Core.Models.Common;


namespace Calc.Core.Models.Operators
{
  public class DivisionOperator : IExpressionElement, IOperator
  {
    //public char Symbol { get; } = '-';
    public int Precedence { get; } = 2;

    public int GetPrecedence()
    {
      return Precedence;
    }

    public double Operation(double a, double b)
    {
      throw new NotImplementedException();
    }
  }
}
