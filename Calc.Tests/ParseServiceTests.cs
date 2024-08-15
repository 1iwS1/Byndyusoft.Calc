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
    public void GetInfixExpression_InputString_ReturnQueueOfIExpresions(string value)
    {
      // Arrange
      IParseSourceExpressionService parser = new ParseSourceExpressionService();

      Queue<IExpressionElement> elements = new();
      elements.Enqueue(new Operand() { Value = 6 });
      elements.Enqueue(new PlusOperator());
      elements.Enqueue(new Operand() { Value = 7 });

      // Act
      var result = parser.GetInfixExpression(value);

      // Assert
      Assert.Equal(elements, result);
    }
  }
}
