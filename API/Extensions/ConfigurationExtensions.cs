using API.Models.SettingConfigs;

namespace API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T? Get<T>(this IConfiguration configuration, string configName)
        {
            var config = "";
            
            if (Environment.GetEnvironmentVariable(BaseSettings.ProjectEnvironment) == BaseSettings.ProductionEnvironment)
            {
                configName = configName.Replace(":", "_");
                //Console.WriteLine($"==> configName: " + configName);
                config = Environment.GetEnvironmentVariable(configName);
            } 
            else
            {
                config = configuration.GetSection(configName).Value;
            }

            return (T?)Convert.ChangeType(config, typeof(T));
        }

        public static string? Get(this IConfiguration configuration, string configName)
        {
            return configuration.Get<string>(configName);
        }

        public static string? GetConnectionString(this ConfigurationManager configuration, string configName, string? env)
        {
            if (env == BaseSettings.ProductionEnvironment)
            {
                //Console.WriteLine($"===> Here... {configName}");
                return Environment.GetEnvironmentVariable(configName);
            }    
            else
                return configuration.GetConnectionString(configName);
        }

        public static T? Get<T>(this ConfigurationManager configuration, string configName)
        {
            var config = "";

            if (Environment.GetEnvironmentVariable(BaseSettings.ProjectEnvironment) == BaseSettings.ProductionEnvironment)
            {
                configName = configName.Replace(":", "_");
                //Console.WriteLine($"==> configName: " + configName);
                config = Environment.GetEnvironmentVariable(configName);
            }
            else
            {
                config = configuration[configName];
            }

            return (T?)Convert.ChangeType(config, typeof(T));
        }

        public static string? Get(this ConfigurationManager configuration, string configName)
        {
            return configuration.Get<string>(configName);
        }
    }
}
