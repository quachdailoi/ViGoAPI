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
        public static async Task<string?> Validate(this CreateDriverRegistrationRequest request, IAppServices appServices)
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

            // check identification code
            appServices.CheckDuplicateLicenseCode(request.IdentificationCode, LicenseTypes.Identification, "Identification");

            // check driver's license code
            appServices.CheckDuplicateLicenseCode(request.DriverLicenseCode, LicenseTypes.DriverLicense, "Driver's license");

            // check vehicle registration certificate code
            appServices.CheckDuplicateLicenseCode(request.VehicleRegistrationCode, LicenseTypes.VehicleRegistration, "Vehicle registration certificate");

            //check license plate
            appServices.CheckDuplicateLicensePlate(request.LicensePlate);

            // check all files size
            await appServices.CheckFileSize(request);

            return null;
        }

        public static string? Validate(this UpdateDriverRegistrationRequest request, IAppServices appServices, User pendingDriver)
        {
            // check date of birth for higher 18 years old driver
            var age = new Age(request.DateOfBirth.DateTime, DateTime.Today);
            if (age.Years < 18) return "Driver must be over 18 years old.";

            // check duplicate when change license code
            var identificationCodeOld = pendingDriver.UserLicenses.Where(x => x.LicenseTypeId == LicenseTypes.Identification).First().Code;
            var driverLicenseCodeOld = pendingDriver.UserLicenses.Where(x => x.LicenseTypeId == LicenseTypes.DriverLicense).First().Code;
            var vehicleRegistrationCodeOld = pendingDriver.UserLicenses.Where(x => x.LicenseTypeId == LicenseTypes.VehicleRegistration).First().Code;

            var identificationCodeNew = request.IdentificationCode;
            var driverLicenseCodeNew = request.DriverLicenseCode;
            var vehicleRegistrationCodeNew = request.VehicleRegistrationCode;

            if (identificationCodeOld != identificationCodeNew)
                appServices.CheckDuplicateLicenseCode(request.IdentificationCode, LicenseTypes.Identification, "Identification");
            if (driverLicenseCodeOld != driverLicenseCodeNew)
                appServices.CheckDuplicateLicenseCode(request.DriverLicenseCode, LicenseTypes.DriverLicense, "Driver's license");
            if (vehicleRegistrationCodeOld != vehicleRegistrationCodeNew)
                appServices.CheckDuplicateLicenseCode(request.VehicleRegistrationCode, LicenseTypes.VehicleRegistration, "Vehicle registration certificate");

            // check duplicate when change license plate
            var licensePlateOld = pendingDriver.Vehicle.LicensePlate;
            var licensePlateNew = request.LicensePlate;
            if (licensePlateOld != licensePlateNew)
                appServices.CheckDuplicateLicensePlate(licensePlateNew);

            //check all files size
            //await appServices.CheckFileSize(request); //File size checked in update method

            return null;
        }

        private static async Task CheckFileSize(this IAppServices appServices, UpdateDriverRegistrationRequest request)
        {
            var fileSize = await appServices.Setting.GetValue(Settings.DriverRegistrationFileSizeLimit, 20);

            // check size of avatar
            request.Avatar.CheckFileSize("Avatar", fileSize);
            //check size of identification files
            request.IdentificationFrontSideImage.CheckFileSize("Identification front side", fileSize);
            request.IdentificationBackSideImage.CheckFileSize( "Identification back side", fileSize);
            //check size of driver license files
            request.DriverLicenseFrontSideImage.CheckFileSize("Driver license front side", fileSize);
            request.DriverLicenseBackSideImage.CheckFileSize("Driver license back side", fileSize);
            //check size of vehicle registration files
            request.VehicleRegistrationFrontSideImage.CheckFileSize("Vehicle registration certificate front side", fileSize);
            request.VehicleRegistrationBackSideImage.CheckFileSize("Vehicle registration certificate back side", fileSize);
        }

        public static void CheckFileSize(this IFormFile? file, string fileName, int fileSize)
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
