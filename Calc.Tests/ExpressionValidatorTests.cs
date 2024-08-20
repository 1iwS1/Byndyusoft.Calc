using Calc.Application.Abstractions;
using Calc.Application.Services;
using Calc.Core;


namespace Calc.Tests
{
  public class ExpressionValidatorTests
  {
    [Theory]
    [InlineData("5+7")]
    [InlineData("-8/4-(-6)")]
    [InlineData("-8.0/4.45-(-6)")]
    [InlineData("-8/4-(-6.05)")]
    [InlineData("(-88)-8+8*(-1)")]
    [InlineData("-(-88)-8+8*(-1)")]
    [InlineData("7/9*99*0")]
    [InlineData("8-(6*6/(-6))")]
    [InlineData("(89)-(6*6/(-6))")]
    [InlineData("(9)/1.5+(-8)")]
    [InlineData("-4/2+7-(-9)")]
    public void Validate_CorrectExpressions_InputString_ReturnBool(string expression)
    {
      // Arrange
      OperatorsConfig config = new();
      IValidator validator = new ExpressionValidator(config);

      // Act
      var result = validator.Validate(expression);

      // Assert
      Assert.True(result);
    }

    [Theory]
    [InlineData("5+7..0")]
    [InlineData("gh5+7.0")]
    [InlineData("5+7gh.0")]
    [InlineData("5+7.0g")]
    [InlineData("5+7.0?")]
    [InlineData("-8/4--6)")]
    [InlineData("(-88-8+8*(-1)")]
    [InlineData("7./9*99*0")]
    [InlineData("(77/7*)-3")]
    [InlineData("(77/7)-3.")]
    [InlineData("(77/7)-3+")]
    [InlineData("(100/8.)/42")]
    [InlineData("+(100/8.5)/42")]
    [InlineData("(+(100/8.5)/42)")]
    [InlineData("2*(.444/0.4)")]
    [InlineData("2*(+444/0.4)")]
    [InlineData("2*(444/4(9+9))")]
    [InlineData("2*(444/4.(9+9))")]
    [InlineData("2*(444/4-(.9+9))")]
    public void Validate_InCorrectExpressions_InputString_ReturnBool(string expression)
    {
      // Arrange
      OperatorsConfig config = new();
      IValidator validator = new ExpressionValidator(config);

      // Act
      var result = validator.Validate(expression);

      // Assert
      Assert.False(result);
    }
  }
}
