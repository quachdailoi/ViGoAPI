using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class UpdateRegistrationByOtpRequest : SendOtpRequest
    {
        [Required]
        public string OTP { get; set; }
    }
}
