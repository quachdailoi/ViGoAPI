using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class SendGmailOtpRequest
    {
        [Required]
        public string Gmail { get; set; }
    }
}
