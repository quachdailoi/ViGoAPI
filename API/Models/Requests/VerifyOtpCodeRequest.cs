using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class VerifyOtpCodeRequest
    {
        [Required]
        public string UserCode { get; set; }
        [Required]
        public string OtpCode { get; set; }
        [Required]
        public int RegistrationType { get; set; }
    }
}
