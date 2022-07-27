using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class LoginByEmailRequest
    {
        [Required]
        public string IdToken { get; set; }
    }
}
