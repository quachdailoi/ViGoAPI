namespace API.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T? Get<T>(this IConfiguration configuration, string configName)
        {
            var config = "";
            
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "production")
            {
                configName = configName.Replace(":", "_");
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
    }
}
