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
    public void GetPostfixExpression_InputString6plus7_ReturnQueueOfIExpresions()
    {
      // Arrange
      IConverter parser = new ConvertFromInfixToPostfix();

      Queue<IExpressionElement> postfixForm = new();
      postfixForm.Enqueue(new Operand() { Value = 5 });
      postfixForm.Enqueue(new Operand() { Value = 6 });
      postfixForm.Enqueue(new PlusOperator());

      Queue<IExpressionElement> infixForm = new();
      infixForm.Enqueue(new Operand() { Value = 5 });
      infixForm.Enqueue(new PlusOperator());
      infixForm.Enqueue(new Operand() { Value = 6 });


      // Act
      var result = parser.GetPostfixExpression(infixForm);


      // Assert
      IExpressionElementComparer elementComparer = new();
      QueueComparer<IExpressionElement> queueComparer = new(elementComparer);

      Assert.Equal(postfixForm, result, queueComparer);
    }
  }
}
