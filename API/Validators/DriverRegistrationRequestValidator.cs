using AgeCalculator;
using API.Models.Requests;
using API.Services.Constract;
using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.IdentityModel.Tokens;

namespace API.Validators
{
    public static class DriverRegistrationRequestValidator
    {
        public static async Task<string?> Validate(DriverRegistrationRequest request, IAppServices appServices)
        {
            // check date of birth for higher 18 years old driver
            var age = new Age(request.DateOfBirth.DateTime, DateTime.Today);
            if (age.Years < 18) return "Driver must be over 18 years old.";

            //check exist account with phone number
            var existedPhone = await appServices.Driver.CheckExistRegistration(request.PhoneNumber, RegistrationTypes.Phone);
            if (existedPhone) return "This phone number already belongs to another driver.";

            //check exist account with email
            var existedEmail = await appServices.Driver.CheckExistRegistration(request.Email, RegistrationTypes.Gmail);
            if (existedEmail) return "This email already belongs to another driver.";

            var fileSize = await appServices.Setting.GetValue(Settings.DriverRegistrationFileSizeLimit, 20);
            // check size of avatar
            var avatarSize = request.Avatar.Length / 1000000; //MB
            if (avatarSize > fileSize) return $"Avatar file's size exceeded {fileSize}MB.";

            // check identification code
            var identification = appServices.UserLicense.GetLicenseByCodeAndType(request.IdentificationCode, LicenseTypes.Identification);
            if (!identification.IsNullOrEmpty()) return "Identification code already belongs to another driver.";

            // check driver's license code
            var driverLicense = appServices.UserLicense.GetLicenseByCodeAndType(request.DriverLicenseCode, LicenseTypes.DriverLicense);
            if (!driverLicense.IsNullOrEmpty()) return "Driver's license code already belongs to another driver.";

            // check vehicle registration certificate code
            var vehicleRegistraion = appServices.UserLicense.GetLicenseByCodeAndType(request.VehicleRegistrationCode, LicenseTypes.VehicleRegistration);
            if (!vehicleRegistraion.IsNullOrEmpty()) return "Vehicle registration certificate code already belongs to another driver.";

            //check size of identification files
            var identificationFSSize = request.IdentificationFrontSideImage.Length / 1000000; //MB
            if (identificationFSSize > fileSize) return $"Identification front side file's size exceeded {fileSize}MB.";

            var identificationBSSize = request.IdentificationBackSideImage.Length / 1000000; //MB
            if (identificationBSSize > fileSize) return $"Identification back side file's size exceeded {fileSize}MB.";

            //check size of driver license files
            var driverLicenseFSSize = request.DriverLicenseFrontSideImage.Length / 1000000; //MB
            if (driverLicenseFSSize > fileSize) return $"Driver license front side file's size exceeded {fileSize}MB.";

            var driverLicenseBSSize = request.DriverLicenseBackSideImage.Length / 1000000; //MB
            if (driverLicenseBSSize > fileSize) return $"Driver license back side file's size exceeded {fileSize}MB.";

            //check size of vehicle registration files
            var vehicleRegistrationFSSize = request.VehicleRegistrationFrontSideImage.Length / 1000000; //MB
            if (vehicleRegistrationFSSize > fileSize) return $"Vehicle registration certificate front side file's size exceeded {fileSize}MB.";

            var vehicleRegistrationBSSize = request.DriverLicenseBackSideImage.Length / 1000000; //MB
            if (vehicleRegistrationBSSize > fileSize) return $"Vehicle registration certificate back side file's size exceeded {fileSize}MB.";

            //check license plate
            var vehicle = appServices.Vehicle.GetVehicleByLicensePlate(request.LicensePlate);
            if (!vehicle.IsNullOrEmpty()) return "License plate already belongs to another driver's vehicle.";

            return null; // everything is OK
        }
    }
}
