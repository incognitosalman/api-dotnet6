namespace API.Extensions
{
    public static class ConfigureHostBuilderExtensions
    {
        public static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder host)
        {
            host.ConfigureAppConfiguration((context, builder) =>
            {
                var configurationsDirectory = "Configurations";
                var env = context.HostingEnvironment;
                builder
                    .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/logger.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"{configurationsDirectory}/logger.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
            });

            return host;
        }
    }
}
