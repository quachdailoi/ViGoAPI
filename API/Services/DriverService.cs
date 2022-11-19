using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using API.Models.Settings;
using API.Services.Constract;
using API.Validators;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.File;

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
            var driver = AppServices.User.GetUserById(driverId)?.FirstOrDefault();
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
            } else if (cancelledTripRate >= await AppServices.Setting.GetValue(Settings.MaxCancelledTripRate, 0.1))
            {
                var notiDTO = new NotificationDTO()
                {
                    EventId = Events.Types.BanDriver,
                    Token = driver.FCMToken,
                    UserId = driverId
                };
                await AppServices.Notification.SendPushNotification(notiDTO);
            }

            await UnitOfWork.Users.Update(driver);
        }

        public Task<bool> CheckExistRegistration(string registration, RegistrationTypes registrationTypes)
        {
            return UnitOfWork.Accounts.GetAccountByRegistration(registration, registrationTypes)
                .Where(x => x.RoleId == Roles.DRIVER && x.Verified == true).AnyAsync();
        }

        public async Task<UserViewModel?> SubmitDriverRegistration(CreateDriverRegistrationRequest request)
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
            var newUser = new User()
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
            var identificationFrontSide = await UploadUserFile(
                $"{newUser.Code}_front",
                request.IdentificationFrontSideImage,
                _identificationFolder,
                FileTypes.IdentificationImageFront,
                "identification's front side image");

            var identificationBackSide = await UploadUserFile(
                $"{newUser.Code}_back",
                request.IdentificationBackSideImage,
                _identificationFolder,
                FileTypes.IdentificationImageBack,
                "identification's back side image");

            // driver's license
            var driverLicenseFrontSide = await UploadUserFile(
                $"{newUser.Code}_front",
                request.DriverLicenseFrontSideImage,
                _driverLicenseFolder,
                FileTypes.DriverLicenceFront,
                "driver license's front side image");

            var driverLicenseBackSide = await UploadUserFile(
                $"{newUser.Code}_back",
                request.DriverLicenseBackSideImage,
                _driverLicenseFolder,
                FileTypes.DriverLicenceBack,
                "driver license's back side image");

            //vehicle registration
            var vehicleRegistrationFrontSide = await UploadUserFile(
                $"{newUser.Code}_front",
                request.VehicleRegistrationFrontSideImage,
                _vehicleRegistrationFolder,
                FileTypes.VehicleRegistrationFront,
                "vehicle registration's front side image");

            var vehicleRegistrationBackSide = await UploadUserFile(
                $"{newUser.Code}_back",
                request.VehicleRegistrationBackSideImage,
                _vehicleRegistrationFolder,
                FileTypes.VehicleRegistrationBack,
                "vehicle registration's back side image");
                
            newUser.UserLicenses.Add(new()
            {
                Code = request.IdentificationCode,
                UserId = newUser.Id,
                FrontSideFileId = identificationFrontSide.Id,
                BackSideFileId = identificationBackSide.Id,
                LicenseTypeId = LicenseTypes.Identification
            });

            newUser.UserLicenses.Add(new()
            {
                Code = request.DriverLicenseCode,
                UserId = newUser.Id,
                FrontSideFileId = driverLicenseFrontSide.Id,
                BackSideFileId = driverLicenseBackSide.Id,
                LicenseTypeId = LicenseTypes.DriverLicense
            });

            newUser.UserLicenses.Add(new()
            {
                Code = request.VehicleRegistrationCode,
                UserId = newUser.Id,
                FrontSideFileId = vehicleRegistrationFrontSide.Id,
                BackSideFileId = vehicleRegistrationBackSide.Id,
                LicenseTypeId = LicenseTypes.VehicleRegistration
            });

            newUser.Vehicle = new()
            {
                Name = request.VehicleName,
                LicensePlate = request.LicensePlate,
                VehicleTypeId = request.VehicleType
            };

            newUser = await UnitOfWork.Users.Add(newUser);

            if (newUser == null)
            {
                await UnitOfWork.Rollback(); // rollback
                throw new Exception("Failed to create new user.");
            }

            await UnitOfWork.CommitAsync();

            //send mail to driver to verify email account
            var userVM = UnitOfWork.Users.GetUserById(newUser.Id).MapTo<UserViewModel>(Mapper, AppServices).FirstOrDefault();

            var token = AppServices.JwtHandler.GenerateToken(userVM, isExpired: false);
            AppServices.VerifiedCode.SendVerifiedAccountLink(userVM.Gmail, token, resend: false);

            return userVM;
        }

        public PagingViewModel<IQueryable<UserViewModel>>? GetPendingDriverPaging(PagingRequest pagingRequest)
        {
            var pendingDriver = UnitOfWork.Users.List(x => x.Status == Users.Status.Pending).MapTo<UserViewModel>(Mapper, AppServices);

            var paging = pendingDriver.Paging(page: pagingRequest.Page, pageSize: pagingRequest.PageSize);

            return paging;
        }

        public async Task<UserViewModel?> UpdateDriverRegistration(User pendingDriver, UpdateDriverRegistrationRequest request, Users.Status userStatus)
        {
            if (pendingDriver == null) throw new ValidationException("Not found pending driver with this code.");
            var fileSize = await AppServices.Setting.GetValue(Settings.DriverRegistrationFileSizeLimit, 20);
            var file = request.Avatar;
            if (file != null)
            {
                file.CheckFileSize("Avatar", fileSize); // check avatar size
                var path = pendingDriver.FilePath;

                if (!await AppServices.File.UpdateS3File(path, file))
                    throw new Exception("Failed to update avatar file.");
            }

            var identification = AppServices.UserLicense.GetLicenseByUserIdAndType(pendingDriver.Id, LicenseTypes.Identification).FirstOrDefault();
            file = request.IdentificationFrontSideImage;
            if (file != null)
            {
                file.CheckFileSize("Identification front side", fileSize); // check size
                var path = identification.FrontSideFile.Path;

                if (!await AppServices.File.UpdateS3File(path, file))
                    throw new Exception("Failed to update identification's front side file.");
            }

            file = request.IdentificationBackSideImage;
            if (file != null)
            {
                file.CheckFileSize("Identification back side", fileSize); // check size
                var path = identification.BackSideFile.Path;

                if (!await AppServices.File.UpdateS3File(path, file))
                    throw new Exception("Failed to update identification's front side file.");
            }

            var driverLicense = AppServices.UserLicense.GetLicenseByUserIdAndType(pendingDriver.Id, LicenseTypes.DriverLicense).FirstOrDefault();
            file = request.DriverLicenseFrontSideImage;
            if (file != null)
            {
                file.CheckFileSize("Driver license front side", fileSize);
                var path = driverLicense.FrontSideFile.Path;

                if (!await AppServices.File.UpdateS3File(path, file))
                    throw new Exception("Failed to update driver license's front side file.");
            }

            file = request.DriverLicenseBackSideImage;
            if (file != null)
            {
                file.CheckFileSize("Driver license back side", fileSize);
                var path = driverLicense.BackSideFile.Path;

                if (!await AppServices.File.UpdateS3File(path, file))
                    throw new Exception("Failed to update driver license's front side file.");
            }

            var vehicleRegistration = AppServices.UserLicense.GetLicenseByUserIdAndType(pendingDriver.Id, LicenseTypes.VehicleRegistration).FirstOrDefault();
            file = request.VehicleRegistrationFrontSideImage;
            if (file != null)
            {
                file.CheckFileSize("Vehicle registration certificate front side", fileSize);
                var path = vehicleRegistration.FrontSideFile.Path;

                if (!await AppServices.File.UpdateS3File(path, file))
                    throw new Exception("Failed to update vehicle registration's front side file.");
            }

            file = request.VehicleRegistrationBackSideImage;
            if (file != null)
            {
                file.CheckFileSize("Vehicle registration certificate back side", fileSize);
                var path = vehicleRegistration.BackSideFile.Path;

                if (!await AppServices.File.UpdateS3File(path, file))
                    throw new Exception("Failed to update vehicle registration's front side file.");
            }

            //update info
            pendingDriver.Name = request.Name;
            pendingDriver.Gender = request.Gender;
            pendingDriver.DateOfBirth = request.DateOfBirth;

            // check duplicate when change license code
            var identificationCodeOld = pendingDriver.UserLicenses.Where(x => x.LicenseTypeId == LicenseTypes.Identification).First().Code;
            var driverLicenseCodeOld = pendingDriver.UserLicenses.Where(x => x.LicenseTypeId == LicenseTypes.DriverLicense).First().Code;
            var vehicleRegistrationCodeOld = pendingDriver.UserLicenses.Where(x => x.LicenseTypeId == LicenseTypes.VehicleRegistration).First().Code;

            var identificationCodeNew = request.IdentificationCode;
            var driverLicenseCodeNew = request.DriverLicenseCode;
            var vehicleRegistrationCodeNew = request.VehicleRegistrationCode;

            identificationCodeOld = identificationCodeNew;
            driverLicenseCodeOld = driverLicenseCodeNew;
            vehicleRegistrationCodeOld = driverLicenseCodeNew;

            var licensePlateOld = pendingDriver.Vehicle.LicensePlate;
            var licensePlateNew = request.LicensePlate;

            licensePlateOld = licensePlateNew;

            pendingDriver.Vehicle.Name = request.VehicleName;
            pendingDriver.Vehicle.VehicleTypeId = request.VehicleType;

            pendingDriver.Status = userStatus;

            var rs = await UnitOfWork.Users.Update(pendingDriver);
            if (!rs) return null;
            var userVM = UnitOfWork.Users.GetUserById(pendingDriver.Id).MapTo<UserViewModel>(Mapper, AppServices).FirstOrDefault();

            if (userStatus == Users.Status.Rejected)
            {
                //send mail 
                AppServices.VerifiedCode.SendMail(pendingDriver.Gmail, "ViGo: Rejected Your Driver Registration", "You driver registration was rejected, please contact to admin for details and support.");
            }
            else if (userStatus == Users.Status.Active)
            {
                // if email account was not verified resend mail to user to verify account.
                if (!userVM.HasVerifiedGmail)
                {
                    //send mail
                    var token = AppServices.JwtHandler.GenerateToken(userVM, isExpired: false);
                    AppServices.VerifiedCode.SendVerifiedAccountLink(userVM.Gmail, token, resend: true);
                    throw new Exception("Driver's email was not verified, mail to remind driver to verify their mail was resent");
                } 
                else
                {
                    // send mail
                    AppServices.VerifiedCode.SendMail(pendingDriver.Gmail, "ViGo: Approve Your Driver Registration", "You driver registration was approved, now you can use email to login to ViGo.");
                }
            }

            return userVM;
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

        public Task<User?> GetPendingDriverByCode(string userCode)
        {
            return UnitOfWork.Users.List(x => x.Status == Users.Status.Pending && x.Code.ToString() == userCode)
                .Include(x => x.File)
                .Include(x => x.Vehicle)
                .Include(x => x.Accounts)
                .Include(x => x.UserLicenses)
                .FirstOrDefaultAsync();
        }
    }
}