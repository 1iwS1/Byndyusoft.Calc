using Calc.Core.Models.Operators;
using Calc.Core.Models.Common;
using Calc.Core.Models;


namespace Calc.Tests.Comparers
{
  public class IExpressionElementComparer : IEqualityComparer<IExpressionElement>
  {
    public bool Equals(IExpressionElement? x, IExpressionElement? y)
    {
      if (x == null && y == null)
        return true;

      if (x == null || y == null)
        return false;

      if (x is Operand numberX && y is Operand numberY)
        return numberX.Value == numberY.Value;

      if (x is LeftParenthesis && y is LeftParenthesis)
        return true;

      if (x is RightParenthesis && y is RightParenthesis)
        return true;

      if (x is PlusOperator && y is PlusOperator)
        return true;

      if (x is MinusOperator && y is MinusOperator)
        return true;

      if (x is MultiplierOperator && y is MultiplierOperator)
        return true;

      if (x is DivisionOperator && y is DivisionOperator)
        return true;

      return false;
    }

    public int GetHashCode(IExpressionElement obj)
    {
      if (obj == null)
        return 0;

      int hash = 17;
      
      if (obj is Operand number)
      {
        hash = 31 * hash + number.Value.GetHashCode();
      }

      if (obj is LeftParenthesis leftParenthesis)
      {
        hash = 31 * hash + leftParenthesis.GetHashCode();
      }

      if (obj is RightParenthesis rightParenthesis)
      {
        hash = 31 * hash + rightParenthesis.GetHashCode();
      }

      if (obj is PlusOperator plus)
      {
        hash = 31 * hash + plus.GetPrecedence().GetHashCode();
      }

      if (obj is MinusOperator minus)
      {
        hash = 31 * hash + minus.GetPrecedence().GetHashCode();
      }

      if (obj is MultiplierOperator multiplier)
      {
        hash = 31 * hash + multiplier.GetPrecedence().GetHashCode();
      }

      if (obj is DivisionOperator division)
      {
        hash = 31 * hash + division.GetPrecedence().GetHashCode();
      }

      return hash;
    }
  }
}
