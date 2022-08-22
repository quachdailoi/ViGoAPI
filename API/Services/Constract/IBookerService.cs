using API.Models;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IBookerService : IAccountService
    {
        Response? CheckNotExisted(SendOtpRequest request, string errorMessage, int errorCode, bool? isVerified = null);
        Response? CheckExisted(SendOtpRequest request, string errorMessage, int errorCode, bool? isVerified = null);

        Task<UserViewModel?> GetUserViewModel(SendOtpRequest request);

        IQueryable<Account>? GetAccount(string registration, RegistrationTypes registrationTypes);
        Task<UserViewModel?> GetUserViewModel();
        Task<UserViewModel?> GetUserViewModel(string registration, RegistrationTypes registrationTypes);

        /// <summary>
        /// Method for updating booker information.
        /// </summary>
        /// <param name="errorMessages">List of message when error occurs - this method have 2 case return error: duplicated and update failed</param>
        /// <param name="errorCodes">List of error code match with errorMessage orders</param>
        Task<Response?> UpdateBookerAccount(string userCode, UpdateUserInfoRequest request, string[] errorMessages, int[] errorCodes);
    }
}
