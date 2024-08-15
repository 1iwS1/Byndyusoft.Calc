using Calc.Core.Models.Operators;
using Calc.Core.Models.Common;


namespace Calc.Tests
{
  public class OperatorsNegaiveTests
  {
    [Theory]
    [InlineData(0, 0)]
    [InlineData(-4, 0)]
    [InlineData(100, 0)]
    public void DivisionOperator_Operation_DifferentValues_ReturnException(double a, double b)
    {
      // Act
      IOperator operation = new DivisionOperator();

      // Assert
      Assert.Throws<DivideByZeroException>(() => operation.Operation(a, b));
    }
  }
}