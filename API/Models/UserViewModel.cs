using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class UserViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public int Status { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; } = null;
        public string? AvatarUrl { get; set; } = string.Empty;
        public Guid AvatarCode { get; set; } = Guid.NewGuid();

        public string Gmail { get; set; } = string.Empty ;
        public bool HasVerifiedGmail { get; set; } = false;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool HasVerifiedPhoneNumber { get; set; } = false;
        public string RoleName { get; set; } = Roles.GUEST.GetName();
    }
    public class DriverViewModel : UserViewModel
    {

    }

    public class ContactUserViewModel
    {
        public Guid Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
