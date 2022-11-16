using Domain.Shares.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Requests
{
    public class CreateDriverRequest
    {
        [Required]
        [MaxLength(30, ErrorMessage = "The Name field has max length is 30 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range((int)Users.Genders.Female, (int)Users.Genders.Male, ErrorMessage = "The Gender field has value 0 for female or 1 for male.")]
        public Users.Genders Gender { get; set; } = 0;

        [Required]
        public DateTimeOffset? DateOfBirth { get; set; } = null;
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public IFormFile Avatar { get; set; }
        [Required]
        public string IdentificationCode { get; set; }
        [Required]
        public IFormFile IdentificationFrontSideImage { get; set; }
        [Required]
        public IFormFile IdentificationBackSideImage { get; set; }
        [Required]
        public string DriverLicenseCode { get; set; }
        [Required]
        public IFormFile DriverLicenseFrontSideImage { get; set; }
        [Required]
        public IFormFile DriverLicenseBackSideImage { get; set; }
        [Required]
        public string VehicleRegistrationCode { get; set; }
        [Required]
        public IFormFile VehicleRegistrationFrontSideImage { get; set; }
        [Required]
        public IFormFile VehicleRegistrationBackSideImage { get; set; }
        [Required]
        public string VehicleName { get; set; }
        [Required]
        public string LicensePlate { get; set; }
        [Required]
        [DefaultValue(VehicleTypes.SpecificType.ViRide)]
        public VehicleTypes.SpecificType VehicleType { get; set; }

    }
}
