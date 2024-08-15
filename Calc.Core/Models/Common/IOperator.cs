namespace Calc.Core.Models.Common
{
  public interface IOperator : IExpressionElement
  {
    //char Symbol { get; }
    int Precedence { get; }
    double Operation(double a, double b);
  }
}
