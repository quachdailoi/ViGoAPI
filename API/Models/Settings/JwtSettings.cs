namespace API.Models.Settings
{
    public class JwtSettings
    {
        private static string Section => "JwtSettings:";

        public static string Key = $"{Section}Key";

        public static string Issuer = $"{Section}Issuer";

        public static string Audience = $"{Section}Audience";

        public static string RefreshTokenTTLDays = $"{Section}RefreshTokenTTLDays";

        public static string AccessTokenTTLMinutes = $"{Section}RefreshTokenTTLDays";
    }
}
