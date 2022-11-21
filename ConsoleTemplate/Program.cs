using ConsoleTemplate.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

var host = AppStartup();
var service = ActivatorUtilities.CreateInstance<DatabaseService>(host.Services);

service.Connect();




static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();
}

static IHost AppStartup()
{
    var builder = new ConfigurationBuilder();
    BuildConfig(builder);

    Log.Logger = new LoggerConfiguration() 
                    .ReadFrom.Configuration(builder.Build())
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

    Log.Logger.Information("Application Starting");

    var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => { 

                })
                .UseSerilog() 
                .Build();

    return host;
}