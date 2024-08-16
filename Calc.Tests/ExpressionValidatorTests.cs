using Calc.Application.Abstractions;
using Calc.Application.Services;


namespace Calc.Tests
{
  public class ExpressionValidatorTests
  {
    [Theory]
    [InlineData("5+7")]
    [InlineData("-8/4-(-6)")]
    [InlineData("(-88)-8+8*(-1)")]
    [InlineData("7/9*99*0")]
    public void Validate_CorrectExpressions_InputString_ReturnBool(string expression)
    {
      // Arrange
      IValidator validator = new ExpressionValidator();

      // Act
      var result = validator.Validate(expression);

      // Assert
      Assert.True(result);
    }

    [Theory]
    [InlineData("5+7..0")]
    [InlineData("-8/4--6)")]
    [InlineData("(-88-8+8*(-1)")]
    [InlineData("7./9*99*0")]
    public void Validate_InCorrectExpressions_InputString_ReturnBool(string expression)
    {
      // Arrange
      IValidator validator = new ExpressionValidator();

      // Act
      var result = validator.Validate(expression);

      // Assert
      Assert.True(result);
    }
  }
}
