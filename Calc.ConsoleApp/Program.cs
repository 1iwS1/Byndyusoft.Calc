using Microsoft.Extensions.DependencyInjection;

using Calc.ConsoleApp.DependencyInjection;


public class Program
{
  public static void Main(string[] args)
  {
    IServiceCollection services = new ServiceCollection();
    services.AddServices();

    var serviceProvider = services.BuildServiceProvider();


  }
}
