using Calc.Application.Abstractions;
using Calc.Core;


namespace Calc.Application.Services
{
  public class ExpressionValidator : IValidator
  {
    private readonly OperatorsConfig _operatorsConfig;

    public ExpressionValidator(OperatorsConfig operatorsConfig)
    {
      _operatorsConfig = operatorsConfig;
    }

    public bool Validate(string expression)
    {
      if (string.IsNullOrEmpty(expression)) 
        return false;

      int openParenthesis = 0;
      bool isLastOpenParenthesis = false;
      bool isLastWasPoint = false;
      bool isLastWasOperator = false;

      for (int i = 0; i < expression.Length; i++)
      {
        char tempChar = expression[i];

        if (tempChar == '(')
        {
          if ((!isLastWasOperator) && i != 0)
            return false;

          openParenthesis++;
          isLastWasOperator = false;
          isLastWasPoint = false;
          isLastOpenParenthesis = true;
        }

        else if (tempChar == ')')
        {
          if (isLastWasOperator || isLastWasPoint)
            return false;

          openParenthesis--;

          if (openParenthesis < 0)
            return false;

          isLastWasOperator = false;
          isLastWasPoint = false;
        }

        else if (_operatorsConfig.Config.ContainsKey(tempChar))
        {
          if (isLastWasOperator || isLastWasPoint)
            return false;

          if (isLastOpenParenthesis && tempChar != '-')
            return false;

          if (tempChar != '-' && i == 0)
            return false;

          isLastWasOperator = true;
          isLastWasPoint = false;
          isLastOpenParenthesis = false;
        }

        else if (char.IsDigit(tempChar) || tempChar == '.')
        {
          isLastWasOperator = false;

          if (tempChar == '.')
          {
            if (isLastWasPoint || isLastOpenParenthesis)
              return false;

            isLastWasPoint = true;
          }

          else
          {
            isLastWasPoint = false;
          }

          isLastOpenParenthesis = false;
        }

        else
        {
          return false;
        }
      }

      if (openParenthesis > 0)
        return false;

      if (isLastWasOperator || isLastWasPoint)
        return false;

      return true;
    }
  }
}
