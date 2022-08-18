using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class VerifyOtpRequest : SendOtpRequest
    {
        [Required]
        public string OTP { get; set; }
    }
}
