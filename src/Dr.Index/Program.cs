using Dr.Index.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;

const string EnvironmentVariablePrefix = "IDX_";
const string Version = "0.0.0-dev";

bool IsVerboseEnabled = args.Contains("--verbose");

var config = GetConfiguration();
var services = GetServices(config);

await GetApp(config, services).RunAsync(args);


IConfigurationRoot GetConfiguration() =>
    new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .AddJsonFile("appsettings.development.json", optional: true)
        .AddEnvironmentVariables(EnvironmentVariablePrefix)
        .Build();

ServiceCollection GetServices(IConfigurationRoot config) =>
    new ServiceCollection();

CommandApp GetApp(IConfigurationRoot config, ServiceCollection services)
{
    var registrar = new TypeRegistrar(services);
    var app = new CommandApp(registrar);
    app.Configure(appConfig =>
    {
        appConfig
            .CaseSensitivity(CaseSensitivity.None)
            .SetApplicationName("idx")
            .SetApplicationVersion(Version);

        if (IsVerboseEnabled)
        {
            appConfig
                .ValidateExamples()
                .PropagateExceptions();
        }



    });

    return app;
}
