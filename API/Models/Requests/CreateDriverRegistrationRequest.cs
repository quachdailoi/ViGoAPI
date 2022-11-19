using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class CreateDriverRegistrationRequest : UpdateDriverRegistrationRequest
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
