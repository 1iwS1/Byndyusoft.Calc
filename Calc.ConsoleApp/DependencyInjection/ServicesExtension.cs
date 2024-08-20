using Microsoft.Extensions.DependencyInjection;

using Calc.Application.Abstractions;
using Calc.Application.Services;
using Calc.ConsoleApp.Providers;
using Calc.Core;


namespace Calc.ConsoleApp.DependencyInjection
{
  public static class ServicesExtension
  {
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
      services.AddScoped<IParseProcess, ParseSourceExpressionService>();
      services.AddScoped<IConverter, ConvertFromInfixToPostfix>();
      services.AddScoped<ICalculateService, CalculatePostfixService>();
      services.AddScoped<IValidator, ExpressionValidator>();

      services.AddScoped<IProvider, ConsoleProvider>();

      services.AddTransient<OperatorsConfig>();
      services.AddTransient<Program>();

      return services;
    }
  }
}
