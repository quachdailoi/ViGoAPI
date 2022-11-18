using Domain.Shares.Enums;

namespace API.Models
{
    public class DriverRegistrationViewModel
    {
        public string Name { get; set; }
        public Users.Genders Gender { get; set; } = 0;
        public DateTimeOffset DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public UserLicenseViewModel Identification { get; set; }
        public UserLicenseViewModel DriverLicense { get; set; }
        public UserLicenseViewModel VehicleRegistration { get; set; }
        public string VehicleName { get; set; }
        public string LicensePlate { get; set; }
        public VehicleTypes.SpecificType VehicleType { get; set; }
    }
}
