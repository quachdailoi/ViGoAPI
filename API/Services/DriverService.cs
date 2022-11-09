﻿using API.Extensions;
using API.Models;
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

        public TotalIncomeViewModel GetIncome(int driverId, string? fromDateStr, string? toDateStr)
        {
            var bookingDetails = UnitOfWork.BookingDetails.GetBookingDetailsByDriverId(driverId)
                    .Where(x => x.Status == BookingDetails.Status.Completed);

            if (toDateStr != null && fromDateStr != null)
            {
                var fromDate = DateTimeExtensions.ParseExactDateOnly(fromDateStr);
                var toDate = DateTimeExtensions.ParseExactDateOnly(toDateStr);
                
                bookingDetails = bookingDetails.Where(x => fromDate <= x.Date && x.Date <= toDate);
            }

            var incomes = bookingDetails.MapTo<IncomeViewModel>(Mapper);
                    //.Paging(page: request.Page, pageSize: request.PageSize);

            return new TotalIncomeViewModel
            {
                Incomes = incomes
            };
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
    }
}