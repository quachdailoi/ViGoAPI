using Domain.Entities;
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
        public Users.Status Status { get; set; }
        public string StatusName { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; } = null;
        public string? AvatarUrl { get; set; } = string.Empty;
        public Guid? AvatarCode { get; set; } = Guid.NewGuid();

        public string? Gmail { get; set; } = string.Empty ;
        public bool? HasVerifiedGmail { get; set; } = false;
        public string? PhoneNumber { get; set; } = string.Empty;
        public bool? HasVerifiedPhoneNumber { get; set; } = false;
        public string? RoleName { get; set; } = Roles.GUEST.GetName();
    }
    public class DriverViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string? AvatarUrl { get; set; } = string.Empty;
        public Guid AvatarCode { get; set; } = Guid.NewGuid();
        public string PhoneNumber { get; set; } = string.Empty;
        public VehicleViewModel Vehicle { get; set; }
    }

    public class ContactUserViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; }
        public string? AvatarUrl { get; set; } = string.Empty;
        public Guid AvatarCode { get; set; } = Guid.NewGuid();
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class ScheduleUserViewModel
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public Users.Genders Gender { get; set; }
        public Guid? ChattingRoomCode { get; set; }
        public Payments.PaymentMethods PaymentMethod { get; set; }
        public Bookings.Status PaymentStatus { get; set; }
    }

    public class MessageUserViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; }
        public string Name { get; set; }
        public string LastSeenTime { get; set; }
        public string? AvatarUrl { get; set; } = string.Empty;
        public Guid? AvatarCode { get; set; } = Guid.NewGuid();
    }
}
