using API.Models.Settings;

namespace API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string? GetConfigByEnv(this IConfiguration configuration, string configName)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "production")
            {
                return Environment.GetEnvironmentVariable(configName);
            }

            return configuration.GetSection(configName).Value;
        }

        public static object? Get(this object settings, string configName)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "production")
            {
                return Environment.GetEnvironmentVariable(configName);
            }

            return settings.GetType().GetProperty(configName)?.GetValue(settings, null);
        }
    }
}
