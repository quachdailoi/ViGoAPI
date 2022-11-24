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
    public class DriverInformationRequestValidator
    {
        private readonly IAppServices _appServices;
        private readonly bool _validateType;
        private readonly int _fileSize;

        public DriverInformationRequestValidator(IAppServices appServices, bool validateType = true)
        {
            _appServices = appServices;
            _validateType = validateType;
            _fileSize = appServices.Setting.GetValue(Settings.DriverRegistrationFileSizeLimit, 20).Result;
        }
        public async Task Validate(DriverInformationRequest request, User? driver = null)
        {
            if (!_validateType && driver == null) throw new Exception("Validate update driver with null object"); 
            // check exist registration
            if (driver != null && request.Email != driver.Gmail)
            {
               
                await CheckDuplicateDriverRegistration(request.Email, RegistrationTypes.Gmail, "Email");
            }    
            if (driver != null && request.PhoneNumber != driver.PhoneNumber)
            {
                await CheckDuplicateDriverRegistration(request.PhoneNumber, RegistrationTypes.Phone, "Phone Number");
            }
            
            // check date of birth for higher 18 years old driver
            var age = new Age(request.DateOfBirth.DateTime, DateTime.Today);
            if (age.Years < 18) throw new ValidationException("Driver must be over 18 years old.");

            // check duplicate when change license code in case update
            var identificationCodeNew = request.IdentificationCode;
            var driverLicenseCodeNew = request.DriverLicenseCode;
            var vehicleRegistrationCodeNew = request.VehicleRegistrationCode;

            var identificationCodeOld = driver?.UserLicenses.Where(x => x.LicenseTypeId == LicenseTypes.Identification).First().Code;
            if (driver == null || identificationCodeOld != identificationCodeNew)
            {
                CheckDuplicateLicenseCode(identificationCodeNew, LicenseTypes.Identification, "Identification");
            }

            var driverLicenseCodeOld = driver?.UserLicenses.Where(x => x.LicenseTypeId == LicenseTypes.DriverLicense).First().Code;
            if (driver == null || driverLicenseCodeOld != driverLicenseCodeNew)
            {
                CheckDuplicateLicenseCode(driverLicenseCodeNew, LicenseTypes.DriverLicense, "Driver's license");
            }

            var vehicleRegistrationCodeOld = driver?.UserLicenses.Where(x => x.LicenseTypeId == LicenseTypes.VehicleRegistration).First().Code;
            if (driver == null || vehicleRegistrationCodeOld != vehicleRegistrationCodeNew)
            {
                CheckDuplicateLicenseCode(vehicleRegistrationCodeNew, LicenseTypes.VehicleRegistration, "Vehicle registration certificate");
            }

            // check duplicate when change license plate
            var licensePlateNew = request.LicensePlate;
            var licensePlateOld = driver?.Vehicle?.LicensePlate;
            if (driver == null || licensePlateOld != licensePlateNew)
            {
                CheckDuplicateLicensePlate(licensePlateNew);
            }
                
            //check all files size
            
            CheckFileSize(request); //File size checked in update method
            await Task.CompletedTask;
        }

        private void CheckFileSize(DriverInformationRequest request)
        {
            // check size of avatar
            var avatar = request.Avatar;
            CheckFileSize(avatar, "Avatar");
            //----------------------------

            //check size of identification files
            var identificationF = request.IdentificationBackSideImage;
            CheckFileSize(identificationF,"Identification front side");

            var identificationB = request.IdentificationBackSideImage;
            CheckFileSize(identificationB, "Identification back side");
            //----------------------------

            //check size of driver license files
            var driverLicenseF = request.DriverLicenseFrontSideImage;
            CheckFileSize(driverLicenseF, "Driver license front side");

            var driverLicenseB = request.DriverLicenseBackSideImage;
            CheckFileSize(driverLicenseB, "Driver license back side");
            //----------------------------

            //check size of vehicle registration files
            var vehicleRegistrationF = request.VehicleRegistrationFrontSideImage;
            CheckFileSize(vehicleRegistrationF, "Vehicle registration certificate front side");

            var vehicleRegistrationB = request.VehicleRegistrationBackSideImage;
            CheckFileSize(vehicleRegistrationB, "Vehicle registration certificate back side");
        }

        public void CheckFileSize(IFormFile? file, string fileName, string? errorMsg = null)
        {
            if (file == null)
            {
                if (_validateType) throw new ValidationException(errorMsg != null ? errorMsg : $"{fileName} is required.");
            }
            else
            {
                var fileSize = file.Length / 1000000; //MB
                if (fileSize > _fileSize) throw new ValidationException($"{fileName} file's size exceeded {_fileSize}MB.");
            }
        }

        public void CheckDuplicateLicenseCode(string licenseCode, LicenseTypes type, string licenseName)
        {
            var license = _appServices.UserLicense.GetLicenseByCodeAndType(licenseCode, type);
            if (!license.IsNullOrEmpty()) throw new ValidationException($"{licenseName} code already belongs to another driver.");
        }

        public void CheckDuplicateLicensePlate(string licensePlate)
        {
            var vehicle = _appServices.Vehicle.GetVehicleByLicensePlate(licensePlate);
            if (!vehicle.IsNullOrEmpty()) throw new ValidationException("License plate already belongs to another driver's vehicle.");
        }

        public async Task CheckDuplicateDriverRegistration(string registration, RegistrationTypes registrationTypes, string registrationName)
        {
            var exist = await _appServices.Driver.CheckExistRegistration(registration, registrationTypes);
            if (exist) throw new ValidationException($"{registrationName} already belongs to another active driver.");
            await Task.CompletedTask;
        }
    }

    public class ValidateTypes
    {
        public static bool CREATE = true;
        public static bool UPDATE = false;
    }

    public static class ValidateExtensions
    {
        public static void ValideSize(this IFormFile? file, string fileName, int fileSizeLimit)
        {
            if (file == null)
            {
                throw new ValidationException($"{fileName} is required.");
            }
            else
            {
                var fileSize = file.Length / 1000000; //MB
                if (fileSize > fileSizeLimit) throw new ValidationException($"{fileName} file's size exceeded {fileSizeLimit}MB.");
            }
        }
    }
}
