namespace Calc.Core.Models.Common
{
  public interface IOperator
  {
    //char Symbol { get; }
    //int Precedence { get; }
    int GetPrecedence();
    double Operation(double a, double b);
  }
}
