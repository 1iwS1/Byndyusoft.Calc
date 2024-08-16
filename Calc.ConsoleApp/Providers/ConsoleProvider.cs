using Calc.Application.Abstractions;


namespace Calc.ConsoleApp.Providers
{
  public class ConsoleProvider : IProvider
  {
    public ConsoleProvider() { }

    public string? GetSourceExpression()
    {
      return Console.ReadLine();
    }
  }
}
