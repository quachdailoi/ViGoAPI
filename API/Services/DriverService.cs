using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using API.Models.Settings;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class DriverService : AccountService, IDriverService
    {
        public DriverService(IAppServices appServices) : base(appServices)
        {
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

            var totalCompleted = bookingDetailDrivers.Count();

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

        public async Task<UserViewModel?> SubmitDriverRegistration(DriverRegistrationRequest request)
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

            var avatarPath = $"{Configuration.Get(AwsSettings.UserAvatarFolder)}{newUser.Code}";
            var avatar = await AppServices.File.UploadFileAsync(avatarPath, request.Avatar);

            if (avatar == null)
            {
                await UnitOfWork.Rollback(); // rollback
                throw new Exception("Failed to upload user's avatar.");
            }

            newUser.FileId = avatar.Id;

            // identification
            var identificationPathFrontSide = $"{Configuration.Get(AwsSettings.IdentiticationFolder)}{newUser.Code}_front";
            var identificationPathBackSide = $"{Configuration.Get(AwsSettings.IdentiticationFolder)}{newUser.Code}_back";
            var idFrontSide = await AppServices.File.UploadFileAsync(identificationPathFrontSide, request.IdentificationFrontSideImage, FileTypes.IdentificationImageFront);
            var idBackSide = await AppServices.File.UploadFileAsync(identificationPathBackSide, request.IdentificationBackSideImage, FileTypes.IdentificationImageBack);

            if (idFrontSide == null || idBackSide == null)
            {
                await UnitOfWork.Rollback(); // rollback
                throw new Exception("Failed to upload identification.");
            }

            // driver's license
            var driverLicensePathFrontSide = $"{Configuration.Get(AwsSettings.DriverLicenseFolder)}{newUser.Code}_front";
            var driverLicensePathBackSide = $"{Configuration.Get(AwsSettings.DriverLicenseFolder)}{newUser.Code}_back";
            var driverLicenseFrontSide = await AppServices.File.UploadFileAsync(driverLicensePathFrontSide, request.DriverLicenseFrontSideImage, FileTypes.DriverLicenceFront);
            var driverLicenseBackSide = await AppServices.File.UploadFileAsync(driverLicensePathBackSide, request.DriverLicenseBackSideImage, FileTypes.DriverLicenceBack);

            if (driverLicenseFrontSide == null || driverLicenseBackSide == null)
            {
                await UnitOfWork.Rollback(); // rollback
                throw new Exception("Failed to upload driver license.");
            }

            //vehicle registration
            var vehicleRegistrationPathFrontSide = $"{Configuration.Get(AwsSettings.VehicleRegistrationFolder)}{newUser.Code}_front";
            var vehicleRegistrationPathBackSide = $"{Configuration.Get(AwsSettings.VehicleRegistrationFolder)}{newUser.Code}_back";
            var vehicleRegistrationFrontSide = await AppServices.File.UploadFileAsync(vehicleRegistrationPathFrontSide, request.VehicleRegistrationFrontSideImage, FileTypes.VehicleRegistrationFront);
            var vehicleRegistrationBackSide = await AppServices.File.UploadFileAsync(vehicleRegistrationPathBackSide, request.VehicleRegistrationBackSideImage, FileTypes.VehicleRegistrationBack);

            if (vehicleRegistrationFrontSide == null || vehicleRegistrationBackSide == null)
            {
                await UnitOfWork.Rollback(); // rollback
                throw new Exception("Failed to upload vehicle registration certificate.");
            }
                
            newUser.UserLicenses.Add(new()
            {
                Code = request.IdentificationCode,
                UserId = newUser.Id,
                FrontSideFileId = idFrontSide.Id,
                BackSideFileId = idBackSide.Id,
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
            return UnitOfWork.Users.GetUserById(newUser.Id).MapTo<UserViewModel>(Mapper, AppServices).FirstOrDefault();
        }

        public PagingViewModel<IQueryable<UserViewModel>>? GetPendingDriver(PagingRequest pagingRequest)
        {
            var pendingDriver = UnitOfWork.Users.List(x => x.Status == Users.Status.Pending).MapTo<UserViewModel>(Mapper, AppServices);

            var paging = pendingDriver.Paging(page: pagingRequest.Page, pageSize: pagingRequest.PageSize);

            return paging;
        }
    }
}