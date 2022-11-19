using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API.Models.Requests
{
    public class UpdateDriverRegistrationRequest
    {
        [Required]
        [MaxLength(30, ErrorMessage = "The Name field has max length is 30 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range((int)Users.Genders.Female, (int)Users.Genders.Male, ErrorMessage = "The Gender field has value 0 for female or 1 for male.")]
        public Users.Genders Gender { get; set; } = 0;

        [Required]
        public DateTimeOffset DateOfBirth { get; set; }

        public IFormFile? Avatar { get; set; }
        [Required]
        public string IdentificationCode { get; set; }
        public IFormFile? IdentificationFrontSideImage { get; set; }
        public IFormFile? IdentificationBackSideImage { get; set; }
        [Required]
        public string DriverLicenseCode { get; set; }
        public IFormFile? DriverLicenseFrontSideImage { get; set; }
        public IFormFile? DriverLicenseBackSideImage { get; set; }
        [Required]
        public string VehicleRegistrationCode { get; set; }
        public IFormFile? VehicleRegistrationFrontSideImage { get; set; }
        public IFormFile? VehicleRegistrationBackSideImage { get; set; }
        [Required]
        public string VehicleName { get; set; }
        [Required]
        public string LicensePlate { get; set; }

        [Required]
        [DefaultValue(VehicleTypes.SpecificType.ViRide)]
        public VehicleTypes.SpecificType VehicleType { get; set; }
    }
}
