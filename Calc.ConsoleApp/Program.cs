using Microsoft.Extensions.DependencyInjection;

using Calc.ConsoleApp.DependencyInjection;
using Calc.Application.Abstractions;


public class Program
{
  public static int Main(string[] args)
  {
    IServiceCollection services = new ServiceCollection();
    services.AddServices();

    var serviceProvider = services.BuildServiceProvider();

    string? sourceExpression = string.Empty;

    try
    {
      if (args.Length != 0)
      {
        sourceExpression = args[0];
      }

      else
      {
        var consoleProvider = serviceProvider.GetRequiredService<IProvider>();
        sourceExpression = consoleProvider.GetSourceExpression();
      }

      if (sourceExpression == null || sourceExpression == string.Empty)
      {
        throw new ArgumentException("Nothing to calculate...");
      }
    }

    catch (Exception ex)
    {
      Console.WriteLine(ex.ToString());
      return -1;
    }

    try
    {
      var parser = serviceProvider.GetRequiredService<IParseProcess>();
      var infixForm = parser.GetInfixExpression(sourceExpression);

      var converter = serviceProvider.GetRequiredService<IConverter>();
      var postfixForm = converter.GetPostfixExpression(infixForm);

      var calculater = serviceProvider.GetRequiredService<ICalculateService>();
      double result = calculater.GetResultOfExpression(postfixForm);

      Console.WriteLine("\n" + "The result is " + result);
    }

    catch (Exception ex)
    {
      Console.WriteLine(ex.ToString());
      return -1;
    }

    return 1;
  }
}
