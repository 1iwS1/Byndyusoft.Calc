using Calc.Core.Models.Operators;
using Calc.Core.Models.Common;


namespace Calc.Tests
{
  public class OperatorsPositiveTests
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

    [Theory]
    [InlineData(1, 2)]
    [InlineData(-4, 0)]
    [InlineData(-22, -45)]
    public void MinusOperator_Operation_DifferentValues_ReturnDifference(double a, double b)
    {
      // Act
      IOperator operation = new MinusOperator();
      var result = operation.Operation(a, b);

      // Assert
      Assert.Equal(a - b, result);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(-4, -9)]
    [InlineData(22, -45)]
    public void MultiplierOperator_Operation_DifferentValues_ReturnMultiplier(double a, double b)
    {
      // Act
      IOperator operation = new MultiplierOperator();
      var result = operation.Operation(a, b);

      // Assert
      Assert.Equal(a * b, result);
    }

    [Theory]
    [InlineData(0, 8)]
    [InlineData(-4, -8)]
    [InlineData(100, 300)]
    public void DivisionOperator_Operation_DifferentValues_ReturnDivision(double a, double b)
    {
      // Act
      IOperator operation = new DivisionOperator();
      var result = operation.Operation(a, b);

      // Assert
      Assert.Equal(a / b, result);
    }
  }
}