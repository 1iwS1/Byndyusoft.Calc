namespace Calc.Core.Models.Common
{
  public interface IOperator
  {
    int GetPrecedence();
    double Operation(double a, double b);
  }
}
