﻿using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IDriverService : IAccountService
    {
        Response? CheckExisted(SendOtpRequest request, Response errorResponse, bool? isVerified = null);
        Response? CheckNotExisted(SendOtpRequest request, Response errorResponse, bool? isVerified = null);

        Task<UserViewModel?> GetUserViewModel(SendOtpRequest request);

        IQueryable<Account>? GetAccount(string registration, RegistrationTypes registrationTypes);
        Task<UserViewModel?> GetUserViewModel();
        Task<UserViewModel?> GetUserViewModel(string registration, RegistrationTypes registrationTypes);
        Task<Response> UpdateDriverAccount(
            string userCode,
            UpdateUserInfoRequest request,
            Response successResponse,
            Response duplicateReponse,
            Response failedResponse
        );

        List<TotalIncomeViewModel> GetIncome(int driverId, string? fromDateStr, string? toDateStr);
        Task UpdateDriverRatingAndCancelledTripRate();

        Task UpdateDriverRating(int driverId);
        Task UpdateCancelledTripRate(int driverId);

        Task<bool> CheckExistRegistration(string registration, RegistrationTypes registrationTypes);
        Task<UserViewModel?> SubmitDriverRegistration(DriverInformationRequest request);
        PagingViewModel<IQueryable<UserViewModel>>? GetPendingDriverPaging(PagingRequest pagingRequest);
        Task<UserViewModel?> UpdateDriver(string driverCode, DriverInformationRequest request, Users.Status userStatus);
        Task<User?> GetDriverByCode(string userCode);
        PagingViewModel<IQueryable<DriverViewModel>>? GetDrivers(string searchValue, Users.Status status, PagingRequest paging);
        UserViewModel? GetDriverVMByCode(string code);
    }
}