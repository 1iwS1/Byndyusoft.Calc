﻿using Calc.Core.Models.Common;


namespace Calc.Core.Models.Operators
{
  public class DivisionOperator : IExpressionElement, IOperator
  {
    private int Precedence { get; } = 2;

    public int GetPrecedence()
    {
      return Precedence;
    }

    public double Operation(double a, double b)
    {
      if (b == 0)
      {
        throw new DivideByZeroException();
      }

      return a / b;
    }
  }
}
