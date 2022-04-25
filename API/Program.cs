using API.Extensions;
using Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.AddConfigurations();

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();

    var app = builder.Build();
    app.UseInfrastructure(builder.Configuration);
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    //TODO: Runs when exception occurs
    Console.WriteLine(ex.Message);
}
finally
{
    //TODO: Always run
}