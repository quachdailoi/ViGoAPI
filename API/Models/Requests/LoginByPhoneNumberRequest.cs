using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class LoginByPhoneNumberRequest
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Otp { get; set; }
    }
}
