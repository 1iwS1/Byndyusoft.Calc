namespace Calc.Core.Models.Common
{
  public interface IOperator
  {
    //char Symbol { get; }
    int Precedence { get; }
    double Operation(double a, double b);
  }
}
