using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
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
    }
}