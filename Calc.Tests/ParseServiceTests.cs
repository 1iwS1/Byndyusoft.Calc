using Calc.Application.Abstractions;
using Calc.Application.Services;
using Calc.Application.Common;
using Calc.Core.Models.Operators;
using Calc.Core.Models.Common;
using Calc.Core.Models;
using Calc.Tests.Comparers;


namespace Calc.Tests
{
  public class ParseServiceTests
  {


    public ParseServiceTests()
    {

    }

    [Theory]
    [InlineData("6+7")]
    public void GetInfixExpression_InputString6plus7_ReturnQueueOfIExpresions(string value)
    {
      // Arrange
      OperatorsConfig config = new();
      IParseProcess parser = new ParseSourceExpressionService(config);

      Queue<IExpressionElement> elements = new();
      elements.Enqueue(new Operand() { Value = 6 });
      elements.Enqueue(new PlusOperator());
      elements.Enqueue(new Operand() { Value = 7 });

      IExpressionElementComparer elementComparer = new();
      QueueComparer<IExpressionElement> queueComparer = new(elementComparer);

      // Act
      var result = parser.GetInfixExpression(value);

      // Assert
      Assert.Equal(elements, result, queueComparer);
    }

    [Theory]
    [InlineData("6+7*9")]
    public void GetInfixExpression_InputString6plus7multiply9_ReturnQueueOfIExpresions(string value)
    {
      // Arrange
      OperatorsConfig config = new();
      IParseProcess parser = new ParseSourceExpressionService(config);

      Queue<IExpressionElement> elements = new();
      elements.Enqueue(new Operand() { Value = 6 });
      elements.Enqueue(new PlusOperator());
      elements.Enqueue(new Operand() { Value = 7 });
      elements.Enqueue(new MultiplierOperator());
      elements.Enqueue(new Operand() { Value = 9 });

      IExpressionElementComparer elementComparer = new();
      QueueComparer<IExpressionElement> queueComparer = new(elementComparer);

      // Act
      var result = parser.GetInfixExpression(value);

      // Assert
      Assert.Equal(elements, result, queueComparer);
    }

    [Theory]
    [InlineData("-4/2+7-(-9)")]
    public void GetInfixExpression_InputString_ReturnQueueOfIExpresions(string value)
    {
      // Arrange
      OperatorsConfig config = new();
      IParseProcess parser = new ParseSourceExpressionService(config);

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

      IExpressionElementComparer elementComparer = new();
      QueueComparer<IExpressionElement> queueComparer = new(elementComparer);

      // Act
      var result = parser.GetInfixExpression(value);

      // Assert
      Assert.Equal(elements, result, queueComparer);
    }
  }
}
