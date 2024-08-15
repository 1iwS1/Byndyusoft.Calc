using Calc.Core.Models;
using Calc.Core.Models.Common;


namespace Calc.Tests
{
  public class OperatorsTest
  {
    [Theory]
    [InlineData(1, 2)]
    [InlineData(-4, 0)]
    [InlineData(34, 0.347)]
    public void PlusOperator_Operation_DifferentValues_ReturnSum(double a, double b)
    {
      // Act
      IOperator operation = new PlusOperator();
      var result = operation.Operation(a, b);

      // Assert
      Assert.Equal(a + b, result);
    }
  }
}