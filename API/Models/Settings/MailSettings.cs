namespace API.Models.Settings
{
    public class MailSettings
    {
        private static string Section = "MailSettings:";

        public static string Mail = $"{Section}Mail";

        public static string DisplayName = $"{Section}DisplayName";
        public static string Password { get; set; } = $"{Section}Password";
        public static string Host { get; set; } = $"{Section}Host";
        public static string Port { get; set; } = $"{Section}Port";
        public static string VerifiedAccountHost { get; set; } = $"{Section}VerifiedAccountHost";
    }
}
