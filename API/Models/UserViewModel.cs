using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UserViewModel
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
    }
}
