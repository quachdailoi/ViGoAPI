using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class SendPhoneOtpRequest
    {
        [Required]
        public string PhoneNumber { get; set; }
    }
}
