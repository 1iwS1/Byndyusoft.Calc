using Calc.Core.Models.Common;

namespace Calc.Application.Abstractions
{
    public interface IParseSourceExpressionService
    {
        Queue<IExpressionElement> GetInfixExpression(string sourceExpression);
    }
}