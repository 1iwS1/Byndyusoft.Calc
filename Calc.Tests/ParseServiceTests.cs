using Calc.Application.Abstractions;
using Calc.Application.Services;
using Calc.Core.Models.Operators;
using Calc.Core.Models.Common;
using Calc.Core.Models;


namespace Calc.Tests
{
  public class ParseServiceTests
  {
    [Theory]
    [InlineData("6+7")]
    public void GetInfixExpression_InputString6plus7_ReturnQueueOfIExpresions(string value)
    {
      // Arrange
      IParseProcess parser = new ParseSourceExpressionService();

      Queue<IExpressionElement> elements = new();
      elements.Enqueue(new Operand() { Value = 6 });
      elements.Enqueue(new PlusOperator());
      elements.Enqueue(new Operand() { Value = 7 });

      // Act
      var result = parser.GetInfixExpression(value);

      // Assert
      Assert.StrictEqual(elements, result);
    }

    [Theory]
    [InlineData("6+7*9")]
    public void GetInfixExpression_InputString6plus7multiply9_ReturnQueueOfIExpresions(string value)
    {
      // Arrange
      IParseProcess parser = new ParseSourceExpressionService();

      Queue<IExpressionElement> elements = new();
      elements.Enqueue(new Operand() { Value = 6 });
      elements.Enqueue(new PlusOperator());
      elements.Enqueue(new Operand() { Value = 7 });
      elements.Enqueue(new MultiplierOperator());
      elements.Enqueue(new Operand() { Value = 9 });

      // Act
      var result = parser.GetInfixExpression(value);

      // Assert
      Assert.StrictEqual(elements, result);
    }

    [Theory]
    [InlineData("-4/2+7-(-9)")]
    public void GetInfixExpression_InputString_ReturnQueueOfIExpresions(string value)
    {
      // Arrange
      IParseProcess parser = new ParseSourceExpressionService();

      Queue<IExpressionElement> elements = new();
      elements.Enqueue(new Operand() { Value = -4 });
      elements.Enqueue(new DivisionOperator());
      elements.Enqueue(new Operand() { Value = 2 });
      elements.Enqueue(new PlusOperator());
      elements.Enqueue(new Operand() { Value = 7 });
      elements.Enqueue(new MinusOperator());
      elements.Enqueue(new LeftParenthesis());
      elements.Enqueue(new Operand() { Value = -9 });
      elements.Enqueue(new RightParenthesis());

      // Act
      var result = parser.GetInfixExpression(value);

      // Assert
      Assert.StrictEqual(elements, result);
    }
  }
}
