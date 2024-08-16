using Calc.Application.Abstractions;
using Calc.Application.Services;
using Calc.Core.Models.Operators;
using Calc.Core.Models.Common;
using Calc.Core.Models;
using Calc.Tests.Comparers;


namespace Calc.Tests
{
  public class CalculateServiceTests
  {
    [Fact]
    public void GetResultOfExpression_InputString56plus_ReturnDouble()
    {
      // Arrange
      ICalculateService parser = new CalculatePostfixService();

      Queue<IExpressionElement> postfixForm = new();    // 5 6 +
      postfixForm.Enqueue(new Operand() { Value = 5.0 });
      postfixForm.Enqueue(new Operand() { Value = 6.0 });
      postfixForm.Enqueue(new PlusOperator());

      double checkWith = 5.0 + 6.0;


      // Act
      var result = parser.GetResultOfExpression(postfixForm);


      // Assert
      Assert.Equal(checkWith, result);
    }

    [Fact]
    public void GetResultOfExpression_InputStringWithParenthesis_ReturnDouble()
    {
      // Arrange
      ICalculateService parser = new CalculatePostfixService();

      Queue<IExpressionElement> postfixForm = new();    // -6 7 8 0 - / +
      postfixForm.Enqueue(new Operand() { Value = -6.0 });
      postfixForm.Enqueue(new Operand() { Value = 7.0 });
      postfixForm.Enqueue(new Operand() { Value = 8.0 });
      postfixForm.Enqueue(new Operand() { Value = 0.0 });
      postfixForm.Enqueue(new MinusOperator());
      postfixForm.Enqueue(new DivisionOperator());
      postfixForm.Enqueue(new PlusOperator());

      double checkWith = -6.0 + 7.0 / (8.0 - 0.0);


      // Act
      var result = parser.GetResultOfExpression(postfixForm);


      // Assert
      Assert.Equal(checkWith, result);
    }
  }
}
