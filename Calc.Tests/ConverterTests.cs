using Calc.Application.Abstractions;
using Calc.Application.Services;
using Calc.Core.Models.Operators;
using Calc.Core.Models.Common;
using Calc.Core.Models;
using Calc.Tests.Comparers;


namespace Calc.Tests
{
  public class ConverterTests
  {
    [Fact]
    public void GetPostfixExpression_InputString5plus6_ReturnQueueOfIExpresions()
    {
      // Arrange
      IConverter parser = new ConvertFromInfixToPostfix();

      // 5 + 6
      Queue<IExpressionElement> infixForm = new();
      infixForm.Enqueue(new Operand() { Value = 5 });
      infixForm.Enqueue(new PlusOperator());
      infixForm.Enqueue(new Operand() { Value = 6 });
      
      // 5 6 +
      Queue<IExpressionElement> postfixForm = new();
      postfixForm.Enqueue(new Operand() { Value = 5 });
      postfixForm.Enqueue(new Operand() { Value = 6 });
      postfixForm.Enqueue(new PlusOperator());


      // Act
      var result = parser.GetPostfixExpression(infixForm);


      // Assert
      IExpressionElementComparer elementComparer = new();
      QueueComparer<IExpressionElement> queueComparer = new(elementComparer);

      Assert.Equal(postfixForm, result, queueComparer);
    }

    [Fact]
    public void GetPostfixExpression_InputStringWithParenthesis_ReturnQueueOfIExpresions()
    {
      // Arrange
      IConverter parser = new ConvertFromInfixToPostfix();

      // -6 + 7 / (8 - 0)
      Queue<IExpressionElement> infixForm = new();
      infixForm.Enqueue(new Operand() { Value = -6 });
      infixForm.Enqueue(new PlusOperator());
      infixForm.Enqueue(new Operand() { Value = 7 });
      infixForm.Enqueue(new DivisionOperator());
      infixForm.Enqueue(new LeftParenthesis());
      infixForm.Enqueue(new Operand() { Value = 8 });
      infixForm.Enqueue(new MinusOperator());
      infixForm.Enqueue(new Operand() { Value = 0 });
      infixForm.Enqueue(new RightParenthesis());

      // -6 7 8 0 - / +
      Queue<IExpressionElement> postfixForm = new();
      postfixForm.Enqueue(new Operand() { Value = -6 });
      postfixForm.Enqueue(new Operand() { Value = 7 });
      postfixForm.Enqueue(new Operand() { Value = 8 });
      postfixForm.Enqueue(new Operand() { Value = 0 });
      postfixForm.Enqueue(new MinusOperator());
      postfixForm.Enqueue(new DivisionOperator());
      postfixForm.Enqueue(new PlusOperator());


      // Act
      var result = parser.GetPostfixExpression(infixForm);


      // Assert
      IExpressionElementComparer elementComparer = new();
      QueueComparer<IExpressionElement> queueComparer = new(elementComparer);

      Assert.Equal(postfixForm, result, queueComparer);
    }

    [Fact]
    public void GetPostfixExpression_InputString_ReturnQueueOfIExpresions()
    {
      // Arrange
      IConverter parser = new ConvertFromInfixToPostfix();

      // 5 / 6 - (-8 * (-5))
      Queue<IExpressionElement> infixForm = new();
      infixForm.Enqueue(new Operand() { Value = 5 });
      infixForm.Enqueue(new DivisionOperator());
      infixForm.Enqueue(new Operand() { Value = 6 });
      infixForm.Enqueue(new MinusOperator());
      infixForm.Enqueue(new LeftParenthesis());
      infixForm.Enqueue(new Operand() { Value = -8 });
      infixForm.Enqueue(new MultiplierOperator());
      infixForm.Enqueue(new LeftParenthesis());
      infixForm.Enqueue(new Operand() { Value = -5 });
      infixForm.Enqueue(new RightParenthesis());
      infixForm.Enqueue(new RightParenthesis());

      // 5 6 / -8 -5 * -
      Queue<IExpressionElement> postfixForm = new();
      postfixForm.Enqueue(new Operand() { Value = 5 });
      postfixForm.Enqueue(new Operand() { Value = 6 });
      postfixForm.Enqueue(new DivisionOperator());
      postfixForm.Enqueue(new Operand() { Value = -8 });
      postfixForm.Enqueue(new Operand() { Value = -5 });
      postfixForm.Enqueue(new MultiplierOperator());
      postfixForm.Enqueue(new MinusOperator());


      // Act
      var result = parser.GetPostfixExpression(infixForm);


      // Assert
      IExpressionElementComparer elementComparer = new();
      QueueComparer<IExpressionElement> queueComparer = new(elementComparer);

      Assert.Equal(postfixForm, result, queueComparer);
    }
  }
}
