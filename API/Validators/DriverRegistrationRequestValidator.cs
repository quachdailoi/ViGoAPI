using AgeCalculator;
using API.Models.Requests;
using API.Services;
using API.Services.Constract;
using Domain.Entities;
using Domain.Shares.Enums;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using Serilog.Sinks.File;

namespace API.Validators
{
    public static class DriverRegistrationRequestValidator
    {
        public static async Task<string?> Validate(DriverRegistrationRequest request, IAppServices appServices, bool isCreated)
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
            
            if (isCreated)
            {
                // check identification code
                appServices.CheckDuplicateLicenseCode(request.IdentificationCode, LicenseTypes.Identification, "Identification");

                // check driver's license code
                appServices.CheckDuplicateLicenseCode(request.DriverLicenseCode, LicenseTypes.DriverLicense, "Driver's license");

                // check vehicle registration certificate code
                appServices.CheckDuplicateLicenseCode(request.VehicleRegistrationCode, LicenseTypes.VehicleRegistration, "Vehicle registration certificate");

                // check size of avatar
                CheckFileSize(request.Avatar, "Avatar", fileSize);
                //check size of identification files
                CheckFileSize(request.IdentificationFrontSideImage, "Identification front side", fileSize);
                CheckFileSize(request.IdentificationBackSideImage, "Identification back side", fileSize);
                //check size of driver license files
                CheckFileSize(request.DriverLicenseFrontSideImage, "Driver license front side", fileSize);
                CheckFileSize(request.DriverLicenseBackSideImage, "Driver license back side", fileSize);
                //check size of vehicle registration files
                CheckFileSize(request.VehicleRegistrationFrontSideImage, "Vehicle registration certificate front side", fileSize);
                CheckFileSize(request.VehicleRegistrationBackSideImage, "Vehicle registration certificate back side", fileSize);

                //check license plate
                appServices.CheckDuplicateLicensePlate(request.LicensePlate);
            }

            return null; // everything is OK
        }

        private static void CheckFileSize(IFormFile? file, string fileName, int fileSize)
        {
            if (file == null) throw new ValidationException($"{fileName} is required.");
            else
            {
                var avatarSize = file.Length / 1000000; //MB
                if (avatarSize > fileSize) throw new ValidationException($"Avatar file's size exceeded {fileSize}MB.");
            }
        }

        public static void CheckDuplicateLicenseCode(this IAppServices appServices, string licenseCode, LicenseTypes type, string licenseName)
        {
            var license = appServices.UserLicense.GetLicenseByCodeAndType(licenseCode, type);
            if (!license.IsNullOrEmpty()) throw new ValidationException($"{licenseName} code already belongs to another driver.");
        }

        public static void CheckDuplicateLicensePlate(this IAppServices appServices, string licensePlate)
        {
            var vehicle = appServices.Vehicle.GetVehicleByLicensePlate(licensePlate);
            if (!vehicle.IsNullOrEmpty()) throw new ValidationException("License plate already belongs to another driver's vehicle.");
        }
    }
}
