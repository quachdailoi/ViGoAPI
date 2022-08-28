namespace API.Models.Settings
{
    public class TwilioSettings
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string AccountSID { get; set; } = string.Empty;
        public string AuthToken { get; set; } = string.Empty;
        public int TimeResend { get; set; }
        public int ExpiredTime { get; set; }
    }
}
