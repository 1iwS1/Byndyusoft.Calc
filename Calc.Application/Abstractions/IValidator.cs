namespace Calc.Application.Abstractions
{
  public interface IValidator
  {
    bool Validate(string expression);
  }
}