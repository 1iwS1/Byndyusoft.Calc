using System.Globalization;

using Calc.Application.Abstractions;
using Calc.Application.Common;
using Calc.Core.Models.Common;
using Calc.Core.Models;


namespace Calc.Application.Services
{
  public class ParseSourceExpressionService : IParseProcess
  {
    private readonly OperatorsConfig _operatorsConfig;

    public ParseSourceExpressionService(OperatorsConfig operatorsConfig)
    {
      _operatorsConfig = operatorsConfig;
    }

    public Queue<IExpressionElement> GetInfixExpression(string sourceExpression)
    {
      Queue<IExpressionElement> infixForm = new();
      string tempNumber = string.Empty;
      bool isNegative = false;
      //OperatorsConfig operatorsConfig = new();

      for (int i = 0; i < sourceExpression.Length; i++)
      {
        char tempChar = sourceExpression[i];

        if (tempChar == '.' || char.IsDigit(tempChar))
        {
          tempNumber += tempChar;
        }

        else
        {
          if (!string.IsNullOrEmpty(tempNumber))
          {
            double numberValue = double.Parse(tempNumber, CultureInfo.InvariantCulture);
            infixForm.Enqueue(new Operand() { Value = isNegative ? -numberValue : numberValue });
            isNegative = false;
            tempNumber = string.Empty;
          }

          if (tempChar == '-' && (i == 0 || sourceExpression[i - 1] == '('))
          {
            isNegative = true;
          }

          else
          {
            infixForm.Enqueue(_operatorsConfig.Config[tempChar]);
          }
        }
      }

      if (!string.IsNullOrEmpty(tempNumber))
      {
        double numberValue = double.Parse(tempNumber, CultureInfo.InvariantCulture);
        infixForm.Enqueue(new Operand() { Value = isNegative ? -numberValue : numberValue });
      }

      return infixForm;
    }
  }
}
