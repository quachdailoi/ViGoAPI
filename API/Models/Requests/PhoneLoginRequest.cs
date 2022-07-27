namespace API.Models.Requests
{
    public class PhoneLoginRequest
    {
        public string PhoneNumber { get; set; }
        public string OTP { get; set; }
    }
}
