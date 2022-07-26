﻿using Amazon.S3;
using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using API.Models.SettingConfigs;
using API.Services.Constract;
using API.Utilities;
using API.Validators;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using FluentValidation;
using Infrastructure.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Serilog.Sinks.File;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Twilio.Rest.Api.V2010.Account;
using ValidationException = FluentValidation.ValidationException;

namespace API.Services
{
    public class DriverService : AccountService, IDriverService
    {
        private string? _avatarFolder;
        private string? _identificationFolder;
        private string? _driverLicenseFolder;
        private string? _vehicleRegistrationFolder;
        public DriverService(IAppServices appServices) : base(appServices)
        {
            _avatarFolder = Configuration.Get(AwsSettings.UserAvatarFolder);
            _identificationFolder = Configuration.Get(AwsSettings.IdentiticationFolder);
            _driverLicenseFolder = Configuration.Get(AwsSettings.DriverLicenseFolder);
            _vehicleRegistrationFolder = Configuration.Get(AwsSettings.VehicleRegistrationFolder);
        }

        public IQueryable<Account>? GetAccount(string registration, RegistrationTypes registrationTypes)
        {
            return base.GetAccount(Roles.DRIVER, registration, registrationTypes);
        }

        public async Task<UserViewModel?> GetUserViewModel()
        {
            var account = UnitOfWork.Accounts.List(x => x.RoleId == Roles.DRIVER).Include(acc => acc.Role).FirstOrDefault();

            if (account == null) return null;

            var user = await UnitOfWork.Users.List(user => user.Id == account.UserId).Include(user => user.Accounts).FirstOrDefaultAsync();

            return Mapper.Map<UserViewModel>(user);
        }

        public Response? CheckExisted(SendOtpRequest request, Response errorResponse, bool? isVerified = null)
        {
            return base.CheckExisted(Roles.DRIVER, request, errorResponse, isVerified);
        }

        public Response? CheckNotExisted(SendOtpRequest request, Response errorResponse, bool? isVerified = null)
        {
            return base.CheckNotExisted(Roles.DRIVER, request, errorResponse, isVerified);
        }

        public async Task<UserViewModel?> GetUserViewModel(SendOtpRequest request)
        {
            return await base.GetUserViewModel(Roles.DRIVER, request.Registration, request.RegistrationTypes);
        }

        public async Task<UserViewModel?> GetUserViewModel(string registration, RegistrationTypes registrationTypes)
        {
            return await base.GetUserViewModel(Roles.DRIVER, registration, registrationTypes);
        }

        public Task<Response> UpdateDriverAccount(
            string userCode,
            UpdateUserInfoRequest request,
            Response successResponse,
            Response duplicateReponse,
            Response failedResponse)
        {
            return base.UpdateUserAccount(
                userCode,
                Roles.DRIVER,
                request,
                successResponse,
                duplicateReponse,
                failedResponse
            );
        }

        public List<TotalIncomeViewModel> GetIncome(int driverId, string? fromDateStr, string? toDateStr)
        {
            var listTotalIncome = new List<TotalIncomeViewModel>();

            var walletId = UnitOfWork.Users.GetUserById(driverId).Select(x => x.Wallet.Id).FirstOrDefault();

            var transactions = UnitOfWork.WalletTransactions.List(x => x.WalletId == walletId)
                    .Where(x => x.Type == WalletTransactions.Types.TripIncome && x.Status == WalletTransactions.Status.Success);

            DateOnly? fromDate = null;
            DateOnly? toDate = null;
            if (toDateStr != null && fromDateStr != null)
            {
                fromDate = DateTimeExtensions.ParseExactDateOnly(fromDateStr);
                toDate = DateTimeExtensions.ParseExactDateOnly(toDateStr);
                    
                transactions = transactions.Where(x => fromDate <= DateOnly.FromDateTime(x.CreatedAt.DateTime) && 
                                                            DateOnly.FromDateTime(x.CreatedAt.DateTime) <= toDate);
            }

            var incomes = transactions.MapTo<IncomeViewModel>(Mapper);
            //.Paging(page: request.Page, pageSize: request.PageSize);

            var incomesByDate = incomes.OrderByDescending(x => x.Date).ToList().GroupBy(x => x.Date);
            if (!incomesByDate.Any() && (fromDate == null || toDate == null))
            {
                return listTotalIncome;
            }

            for (var index = 0; index < incomesByDate.Count(); index++)
            {
                var incomesInOneDate = incomesByDate.ElementAt(index).ToList();
                listTotalIncome.Add(new()
                {
                    Incomes = incomesInOneDate
                });
            }

            var minDate = (DateOnly)(fromDate != null ? fromDate : incomesByDate.MinBy(x => x.Key).Key);
            var maxDate = (DateOnly)(toDate != null ? toDate : incomesByDate.MaxBy(x => x.Key).Key);

            while(minDate <= maxDate)
            {
                var totalIncome = listTotalIncome.Where(x => x.Incomes.FirstOrDefault()?.Date == minDate).FirstOrDefault();
                if (totalIncome != null)
                {
                    totalIncome.Date = minDate;
                } 
                else
                {
                    listTotalIncome.Add(new()
                    {
                        Date = minDate
                    });
                }
                minDate = minDate.AddDays(1);
            }

            listTotalIncome = listTotalIncome.OrderBy(x => x.Date).ToList();

            return listTotalIncome;
        }

        public async Task UpdateDriverRatingAndCancelledTripRate()
        {
            var drivers = UnitOfWork.Users
                .List(u => u.Accounts.Any(account => account.RoleId == Roles.DRIVER) && u.Status == Users.Status.Active)
                .ToArray();

            foreach(var driver in drivers)
            {
                var bookingDetailDrivers = UnitOfWork.BookingDetailDrivers
                    .List(bdr => bdr.RouteRoutine.UserId == driver.Id);

                var ratingTrips = bookingDetailDrivers.Where(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.Completed && bdr.BookingDetail.Rating.HasValue);

                var totalRating = ratingTrips.Select(bdr => bdr.BookingDetail.Rating).Sum();
                var totalRatingTrip = ratingTrips.Count();
                var totalBookingDetailDriver = bookingDetailDrivers.Count();
                var totalCancelledBookingDetailDriver = bookingDetailDrivers.Count(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.Cancelled);

                driver.Rating = totalRating / totalRatingTrip;
                driver.CancelledTripRate = (totalCancelledBookingDetailDriver - driver.SuddenlyCancelledTrips) / totalBookingDetailDriver;
            }

            await UnitOfWork.Users.UpdateRange(drivers);
        }

        public async Task UpdateDriverRating(int driverId)
        {
            var driver = AppServices.User.GetUserById(driverId)?.FirstOrDefault();
            if (driver == null) throw new Exception("Not found driver.");

            var bookingDetailDrivers = UnitOfWork.BookingDetailDrivers.List(bdr => bdr.RouteRoutine.UserId == driver.Id);

            var ratingTrips = bookingDetailDrivers
                .OrderByDescending(x => x.StartTime)
                .Where(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.Completed && bdr.BookingDetail.Rating.HasValue)
                .Take(await AppServices.Setting.GetValue(Settings.TotalTripsCalculateRating, 100));

            var totalRating = ratingTrips.Select(bdr => bdr.BookingDetail.Rating).Sum() + 5;
            var totalRatingTrip = ratingTrips.Count() + 1;

            driver.Rating = totalRating / totalRatingTrip;

            await UnitOfWork.Users.Update(driver);
        }

        public async Task UpdateCancelledTripRate(int driverId)
        {
            var driver = AppServices.User.GetUserById(driverId)?.Include(x => x.Accounts).FirstOrDefault();
            if (driver == null) throw new Exception("Not found driver.");

            var bookingDetailDrivers = UnitOfWork.BookingDetailDrivers.List(bdr => bdr.RouteRoutine.UserId == driver.Id)
                .OrderByDescending(x => x.StartTime)
                .Where(x => x.TripStatus == BookingDetailDrivers.TripStatus.Completed || x.TripStatus == BookingDetailDrivers.TripStatus.Cancelled)
                .Take(await AppServices.Setting.GetValue(Settings.TotalTripsCalculateCancelledRate, 100));

            var totalCompleted = 100;

            var totalCancelled = bookingDetailDrivers.Where(x => x.TripStatus == BookingDetailDrivers.TripStatus.Cancelled).Count();

            var cancelledTripRate = totalCancelled * 1.0 / totalCompleted;
            driver.CancelledTripRate = cancelledTripRate;

            if (cancelledTripRate >= await AppServices.Setting.GetValue(Settings.NotifiedCancelledTripRate, 0.08) && 
                    cancelledTripRate < await AppServices.Setting.GetValue(Settings.MaxCancelledTripRate, 0.1))
            {
                //send notification to driver
                var notiDTO = new NotificationDTO()
                {
                    EventId = Events.Types.NearlyBan,
                    Token = driver.FCMToken,
                    UserId = driverId
                };
                await AppServices.Notification.SendPushNotification(notiDTO);
                //send email
                var nearlyBanEvent = await UnitOfWork.Events.List(x => x.Id == Events.Types.NearlyBan).FirstOrDefaultAsync();
                if (nearlyBanEvent != null)
                {
                    await AppServices.VerifiedCode.SendMail(
                        mail: driver.Gmail,
                        subject: $"ViGo: {nearlyBanEvent.Title}",
                        content: nearlyBanEvent.Content
                    );
                }
            } else if (cancelledTripRate >= await AppServices.Setting.GetValue(Settings.MaxCancelledTripRate, 0.1))
            {
                var notiDTO = new NotificationDTO()
                {
                    EventId = Events.Types.BanDriver,
                    Token = driver.FCMToken,
                    UserId = driverId
                };
                await AppServices.Notification.SendPushNotification(notiDTO);
                // send email
                var banEvent = await UnitOfWork.Events.List(x => x.Id == Events.Types.BanDriver).FirstOrDefaultAsync();
                if (banEvent != null)
                {
                    await AppServices.VerifiedCode.SendMail(
                        mail: driver.Gmail,
                        subject: $"ViGo: {banEvent.Title}",
                        content: banEvent.Content
                    );
                }
            }

            await UnitOfWork.Users.Update(driver);
        }

        public Task<bool> CheckExistRegistration(string registration, RegistrationTypes registrationTypes)
        {
            return UnitOfWork.Accounts.GetAccountByRegistration(registration, registrationTypes)
                .Where(x => x.RoleId == Roles.DRIVER && x.Verified == true).AnyAsync();
        }

        public async Task<UserViewModel?> SubmitDriverRegistration(DriverInformationRequest request)
        {
            await UnitOfWork.CreateTransactionAsync();

            var phoneAccount = new Account()
            {
                Registration = request.PhoneNumber,
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Roles.DRIVER,
                Verified = false
            };

            var emailAccount = new Account()
            {
                Registration = request.Email,
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Roles.DRIVER,
                Verified = false
            };

            //upload avatar
            User newUser = new()
            {
                Name = request.Name,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                Accounts = new() { phoneAccount, emailAccount },
                Status = Users.Status.Pending
            };

            var avatar = await UploadUserFile(
                newUser.Code.ToString(), 
                request.Avatar, 
                _avatarFolder, 
                FileTypes.AvatarImage,
                "avatar");

            newUser.FileId = avatar.Id;

            // identification
            var identification = await UploadLicense2Side(
                user: newUser,
                licenseCode: request.IdentificationCode,
                licenseType: LicenseTypes.Identification,
                fileF: request.IdentificationFrontSideImage,
                fileB: request.IdentificationBackSideImage
            );
            newUser.UserLicenses.Add(identification);

            // driver's license
            var driverLicense = await UploadLicense2Side(
                user: newUser,
                licenseCode: request.DriverLicenseCode,
                licenseType: LicenseTypes.DriverLicense,
                fileF: request.DriverLicenseFrontSideImage,
                fileB: request.DriverLicenseBackSideImage
            );
            newUser.UserLicenses.Add(driverLicense);

            //vehicle registration
            var vehicleRegistration = await UploadLicense2Side(
                user: newUser,
                licenseCode: request.VehicleRegistrationCode,
                licenseType: LicenseTypes.VehicleRegistration,
                fileF: request.VehicleRegistrationFrontSideImage,
                fileB: request.VehicleRegistrationBackSideImage
            );
            newUser.UserLicenses.Add(vehicleRegistration);

            newUser.Vehicle = new()
            {
                Name = request.VehicleName,
                LicensePlate = request.LicensePlate,
                VehicleTypeId = request.VehicleType
            };

            newUser.Wallet = new();

            newUser = await UnitOfWork.Users.Add(newUser);

            if (newUser == null)
            {
                await UnitOfWork.Rollback(); // rollback
                throw new Exception("Failed to create new user.");
            }

            var userVM = UnitOfWork.Users.GetUserById(newUser.Id).MapTo<UserViewModel>(Mapper, AppServices).FirstOrDefault();
            //send mail to driver to verify email account
            //await AppServices.VerifiedCode.SendMailOTPVerificationLink(userVM);
            //send sms to driver to verify phone number account
            //await AppServices.VerifiedCode.SendPhoneOTPVerificationLink(userVM);

            //send mail to notification submit registration successfully.
            var mail = await AppServices.Event.GetById(Events.Types.SubmitRegistrationSuccess);

            await AppServices.VerifiedCode.SendMail(userVM.Gmail, mail.Title, string.Format(mail.Content, userVM.Name));

            await UnitOfWork.CommitAsync();

            return userVM;
        }

        private async Task<UserLicense> UploadLicense2Side(User user, string licenseCode, LicenseTypes licenseType, IFormFile? fileF, IFormFile? fileB)
        {
            FileTypes front;
            FileTypes back;
            string folder; 
            string fileTypeName;

            switch (licenseType)
            {
                case LicenseTypes.Identification:
                    front = FileTypes.IdentificationImageFront;
                    back = FileTypes.IdentificationImageBack;
                    folder = _identificationFolder;
                    fileTypeName = "identification's {0} side image";
                    break;
                case LicenseTypes.DriverLicense:
                    front = FileTypes.DriverLicenceFront;
                    back = FileTypes.DriverLicenceBack;
                    folder = _driverLicenseFolder;
                    fileTypeName = "driver license's {0} side image";
                    break;
                default:
                    front = FileTypes.VehicleRegistrationFront;
                    back = FileTypes.VehicleRegistrationBack;
                    folder = _vehicleRegistrationFolder;
                    fileTypeName = "vehicle registration's {0} side image";
                    break;
            }

            if (fileF == null) throw new ValidationException(string.Format($"Not found {fileTypeName} to upload.", "front"));
            if (folder == null) throw new ValidationException("Not found folder to save file");
            var licenseFrontSide = await UploadUserFile(
                fileName: $"{user.Code}_front",
                file: fileF,
                folder: folder,
                fileType: front,
                fileTypeName: string.Format(fileTypeName, "front"));

            if (fileB == null) throw new ValidationException(string.Format($"Not found {fileTypeName} to upload.", "back"));
            if (folder == null) throw new ValidationException("Not found folder to save file");
            var licenseBackSide = await UploadUserFile(
                fileName: $"{user.Code}_back",
                file: fileB,
                folder: folder,
                fileType: back,
                fileTypeName: string.Format(fileTypeName, "back"));

            return new()
            {
                Code = licenseCode,
                UserId = user.Id,
                FrontSideFileId = licenseFrontSide.Id,
                BackSideFileId = licenseBackSide.Id,
                LicenseTypeId = licenseType
            };
        }

        public PagingViewModel<IQueryable<UserViewModel>>? GetPendingDriverPaging(PagingRequest pagingRequest)
        {
            var pendingDriver = UnitOfWork.Users.List(x => x.Status == Users.Status.Pending).MapTo<UserViewModel>(Mapper, AppServices);

            var paging = pendingDriver.Paging(page: pagingRequest.Page, pageSize: pagingRequest.PageSize);

            return paging;
        }

        public async Task<UserViewModel?> UpdateDriver(string driverCode, DriverInformationRequest request, Users.Status userStatus)
        {
            var driver = UnitOfWork.Users.List(x => x.Code.ToString() == driverCode).FirstOrDefault();

            var avatar = await UnitOfWork.Files.GetById(driver?.FileId);

            if (driver == null) throw new ValidationException("Not found driver with this code to update.");

            var isSuccess = true;

            await UnitOfWork.CreateTransactionAsync();
            // update avatar
            var newAvatar = request.Avatar;
            
            if (newAvatar != null)
            {
                if (avatar != null) // update avtar path
                {
                    var path = avatar.Path;

                    isSuccess = await AppServices.File.UpdateS3File(path, newAvatar);
                }
                else // create new avatar
                {
                    var path = $"{Configuration.Get(AwsSettings.UserAvatarFolder)}{driver.Code}";

                    var uploaded = await AppServices.File.UploadFileAsync(path, newAvatar);
                    
                    isSuccess = uploaded != null;
                    driver.FileId = uploaded.Id;
                }
            }
            if (!isSuccess) throw new Exception("Failed to update avatar file.");
            //-----------------

            var validator = new DriverInformationRequestValidator(AppServices, ValidateTypes.CREATE);

            var identificationCodeNew = request.IdentificationCode;
            var driverLicenseCodeNew = request.DriverLicenseCode;
            var vehicleRegistrationCodeNew = request.VehicleRegistrationCode;

            // update or insert identification
            await UpsertLicense(
                newLicenseCode: request.IdentificationCode,
                driver,
                newFrontFile: request.IdentificationFrontSideImage,
                newBackFile: request.IdentificationBackSideImage,
                folder: _identificationFolder,
                validator,
                licenseType: LicenseTypes.Identification,
                licenseName: "identification"
            );
            //-----------------

            // update driver license
            await UpsertLicense(
                newLicenseCode: request.DriverLicenseCode,
                driver,
                newFrontFile: request.DriverLicenseFrontSideImage,
                newBackFile: request.DriverLicenseBackSideImage,
                folder: _driverLicenseFolder,
                validator,
                licenseType: LicenseTypes.DriverLicense,
                licenseName: "driver license"
            );
            //-----------------

            // update vehicle registration
            await UpsertLicense(
                newLicenseCode: request.VehicleRegistrationCode,
                driver,
                newFrontFile: request.VehicleRegistrationFrontSideImage,
                newBackFile: request.VehicleRegistrationBackSideImage,
                folder: _vehicleRegistrationFolder,
                validator,
                licenseType: LicenseTypes.VehicleRegistration,
                licenseName: "vehicle registration"
            );
            //-----------------

            //update info
            driver.Name = request.Name;
            driver.Gender = request.Gender;
            driver.DateOfBirth = request.DateOfBirth;

            //check not found vehicle data of driver
            var licensePlateNew = request.LicensePlate;
            var vehicleNameNew = request.VehicleName;
            var vehicleTypeIdNew = request.VehicleType;

            var vehicle = UnitOfWork.Vehicles.List(x => x.UserId == driver.Id).FirstOrDefault();
            if (vehicle != null) // update
            {
                vehicle.LicensePlate = licensePlateNew;
                vehicle.Name = vehicleNameNew;
                vehicle.VehicleTypeId = vehicleTypeIdNew;

                if (!await UnitOfWork.Vehicles.Update(vehicle)) throw new Exception("Failed to update vehicle's license plate.");
            }
            else // create new
            {
                vehicle = new()
                {
                    Name = vehicleNameNew,
                    VehicleTypeId = vehicleTypeIdNew,
                    LicensePlate = licensePlateNew,
                    UserId = driver.Id
                };

                if (await UnitOfWork.Vehicles.Add(vehicle) != null) throw new Exception("Failed to add new vehicle for driver.");
            }

            var accounts = UnitOfWork.Accounts.GetAccountByUserId(driver.Id);
            var emailAcc = accounts.Where(x => x.RegistrationType == RegistrationTypes.Gmail).FirstOrDefault();
            var phoneAcc = accounts.Where(x => x.RegistrationType == RegistrationTypes.Phone).FirstOrDefault();

            //emailAcc.User = null; emailAcc.Role = null;
            //phoneAcc.User = null; phoneAcc.Role = null;
            var userVM = UnitOfWork.Users.GetUserById(driver.Id).MapTo<UserViewModel>(Mapper, AppServices).FirstOrDefault();

            Events.Types? eventTypeEmail = null;
            Events.Types? eventTypePhone = null;
            var result = true;

            if (driver.Status == Users.Status.Pending && userStatus == Users.Status.Rejected)
            {
                //send mail 
                eventTypeEmail = Events.Types.RejectDriverRegistration;
            }
            else if (driver.Status == Users.Status.Pending && userStatus == Users.Status.Active)
            {
                //send mail to driver to verify email account
                eventTypeEmail = Events.Types.VerifyEmailByLinkNewDriver;

                eventTypePhone = Events.Types.VerifyEmailByLinkNewDriver;
            }
            else if (driver.Status == Users.Status.Active && userStatus == Users.Status.Active)
            {
                if (emailAcc.Registration != request.Email)
                {
                    //send mail to driver to verify email account
                    eventTypeEmail = Events.Types.VerifyEmailByLinkOldDriver;
                }
                if (phoneAcc.Registration != request.PhoneNumber)
                {
                    //send phone to driver to verify phone account
                    eventTypePhone = Events.Types.VerifyEmailByLinkNewDriver;
                }
            }

            //update email account
            emailAcc.Registration = request.Email;
            emailAcc.Verified = false;
            if (!await UnitOfWork.Accounts.Update(emailAcc)) throw new Exception("Failed to update email.");
            userVM.Gmail = request.Email;

            //update phone account
            phoneAcc.Registration = request.PhoneNumber;
            phoneAcc.Verified = false;
            if (!await UnitOfWork.Accounts.Update(phoneAcc)) throw new Exception("Failed to update phone number.");
            userVM.PhoneNumber = request.PhoneNumber;

            driver.Status = userStatus;

            var rs = await UnitOfWork.Users.Update(driver);
            if (!rs) return null;

            await UnitOfWork.CommitAsync();

            // send mail
            if (eventTypeEmail.HasValue)
            {
                var mail = await AppServices.Event.GetById((Events.Types)eventTypeEmail);
                switch (eventTypeEmail)
                {
                    case Events.Types.RejectDriverRegistration:
                        await AppServices.VerifiedCode.SendMail(userVM.Gmail, mail.Title, string.Format(mail.Content, userVM.Name));
                    break;
                    case Events.Types.VerifyEmailByLinkNewDriver:
                    case Events.Types.VerifyEmailByLinkOldDriver:
                        await AppServices.VerifiedCode.SendMailOTPVerificationLink(userVM, mail.Title, string.Format(mail.Content, userVM.Name, "{0}"));
                        break;
                }
            }

            if (eventTypePhone.HasValue)
            {
                var phoneMessage = await AppServices.Event.GetById((Events.Types)eventTypePhone);
                switch (eventTypePhone)
                {
                    case Events.Types.VerifyPhoneByLink:
                        //send verification sms when change phone number
                        var phoneSMS = await AppServices.Event.GetById(Events.Types.VerifyPhoneByLink);
                        await AppServices.VerifiedCode.SendMailOTPVerificationLink(userVM, phoneSMS.Title, phoneSMS.Content);
                        break;
                }
            }

            userVM = UnitOfWork.Users.GetUserById(driver.Id).MapTo<UserViewModel>(Mapper, AppServices).FirstOrDefault();

            return userVM;
        }

        private async Task CheckUpsertLicense(UserLicense license, string licenseName, bool isUpdate = true)
        {
            var result = true;
            try
            {
                if (isUpdate)
                    result = await UnitOfWork.UserLicenses.Update(license);
                else
                    result = await UnitOfWork.UserLicenses.Add(license) != null;
            }
            catch (Exception ex)
            {
                Logger<DriverService>().LogError(ex.Message);
            }
            string action = isUpdate ? "update" : "add new";
            if (!result) throw new Exception($"Failed to {action} {licenseName}.");
            await Task.CompletedTask;
        }

        private async Task UpsertLicenseFileSide(Guid userCode, UserLicense license, AppFile? curFile, IFormFile? newFIle, string folder, string licenseName, string licenseSide)
        {
            if (newFIle != null)
            {
                if (curFile == null) // create new
                {
                    var newFile = await UploadUserFile($"{userCode}_{licenseSide}", newFIle, _identificationFolder, FileTypes.IdentificationImageFront, $"{licenseName} {licenseSide} side file");

                    license.FrontSideFileId = newFile.Id;
                }
                else //update
                {
                    var path = curFile.Path;

                    if (!await AppServices.File.UpdateS3File(path, newFIle))
                        throw new Exception($"Failed to update {licenseName}'s {licenseSide} side file.");
                }
            }
        }

        private async Task UpsertLicense(string newLicenseCode, User driver, IFormFile? newFrontFile, IFormFile? newBackFile, string folder, DriverInformationRequestValidator validator, LicenseTypes licenseType, string licenseName)
        {
            var newIdentificationCode = newLicenseCode;

            var license = UnitOfWork.UserLicenses.List(x => x.UserId == driver.Id && x.LicenseTypeId == licenseType).FirstOrDefault();

            var errorMsg = "";
            if (license == null)
            {
                // not found license -> create new
                // check 2 image not null
                errorMsg = $"Not found {licenseName}, we need 2 image file to update";

                validator.CheckFileSize(newFrontFile, errorMsg);
                validator.CheckFileSize(newBackFile, errorMsg);

                license = await UploadLicense2Side(driver, newIdentificationCode, LicenseTypes.Identification, newFrontFile, newBackFile);

                await CheckUpsertLicense(license, licenseName, isUpdate: false);
            }
            else // update
            {
                // FRONT SIDE
                var frontSideFileCur = await UnitOfWork.Files.GetById(license.FrontSideFileId);
                await UpsertLicenseFileSide(driver.Code, license, frontSideFileCur, newFrontFile, folder, licenseName, "front");

                // BACK SIDE
                var backSideFileCur = await UnitOfWork.Files.GetById(license.BackSideFileId);
                await UpsertLicenseFileSide(driver.Code, license, backSideFileCur, newBackFile, folder, licenseName, "back");

                license.Code = newIdentificationCode;

                await CheckUpsertLicense(license, licenseName);
            }
        }

        private async Task<AppFile> UploadUserFile(string fileName, IFormFile file, string folder, FileTypes fileType, string fileTypeName)
        {
            var filePath = $"{folder}{fileName}";
            var fileObj = await AppServices.File.UploadFileAsync(filePath, file, fileType);

            if (fileObj == null)
            {
                await UnitOfWork.Rollback(); // rollback
                throw new Exception($"Failed to upload {fileTypeName} of driver.");
            }

            return fileObj;
        }

        public Task<User?> GetDriverByCode(string userCode)
        {
            return UnitOfWork.Users.List(x => x.Status == Users.Status.Pending && x.Code.ToString() == userCode)
                .Include(x => x.File)
                .Include(x => x.Vehicle)
                .Include(x => x.Accounts)
                .Include(x => x.UserLicenses)
                .FirstOrDefaultAsync();
        }

        public PagingViewModel<IQueryable<DriverViewModel>>? GetDrivers(string searchValue, Users.Status status, PagingRequest paging)
        {
            searchValue = searchValue.Trim().ToLower();
            var drivers = UnitOfWork.Users.List(x => x.Status == status && x.Accounts.First().Role.Id == Roles.DRIVER)
                .Where(x => x.Code.ToString().Contains(searchValue) ||
                            x.Name.Trim().ToLower().Contains(searchValue) ||
                            x.Accounts.Any(acc => acc.RegistrationType == RegistrationTypes.Gmail && acc.Registration.Trim().ToLower().Contains(searchValue)) ||
                            x.Accounts.Any(acc => acc.RegistrationType == RegistrationTypes.Phone && acc.Registration.Trim().ToLower().Contains(searchValue))
                )
                .PagingMap<User, DriverViewModel>(Mapper, paging.Page, paging.PageSize, AppServices);

            return drivers;
        }

        public UserViewModel? GetDriverVMByCode(string code)
        {
            var driver = UnitOfWork.Users.GetUserByCode(code).MapTo<UserViewModel>(Mapper, AppServices).FirstOrDefault();

            return driver;
        }
    }
}