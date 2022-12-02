namespace API.Models.SettingConfigs
{
    public class TwilioSettings
    {
        private static string Section = "TwilioSettings:";

        public static string PhoneNumber = $"{Section}PhoneNumber";

        public static string AccountSID = $"{Section}AccountSID";
        public static string AuthToken { get; set; } = $"{Section}AuthToken";

        public static string TimeResend = $"{Section}TimeResend";

        public static string ExpiredTime = $"{Section}ExpiredTime";
        public static string VerifiedAccountHost { get; set; } = $"{Section}VerifiedAccountHost";
    }
}
