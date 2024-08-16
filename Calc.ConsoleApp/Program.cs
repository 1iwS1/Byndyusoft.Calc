using Microsoft.Extensions.DependencyInjection;

using Calc.ConsoleApp.DependencyInjection;


public class Program
{
  public static int Main(string[] args)
  {
    IServiceCollection services = new ServiceCollection();
    services.AddServices();

    var serviceProvider = services.BuildServiceProvider();

    throw new NotImplementedException();
  }
}
