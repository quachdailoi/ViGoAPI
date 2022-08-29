using API.Models;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IBookerService : IAccountService
    {
        Response? CheckNotExisted(SendOtpRequest request, Response errorResponse, bool? isVerified = null);
        Response? CheckExisted(SendOtpRequest request, Response errorResponse, bool? isVerified = null);

        Task<UserViewModel?> GetUserViewModel(SendOtpRequest request);

        IQueryable<Account>? GetAccount(string registration, RegistrationTypes registrationTypes);
        Task<UserViewModel?> GetUserViewModel();
        Task<UserViewModel?> GetUserViewModel(string registration, RegistrationTypes registrationTypes);

        Task<Response> UpdateBookerAccount(
            string userCode,
            UserInfoRequest request,
            Response successResponse,
            Response duplicateReponse,
            Response failedResponse,
            Response successButNotSendCodeResponse
        );

        Task<Response> CreateBookerAccount(
            UserRegisterRequest request,
            Response successResponse,
            Response duplicatedRegistrationResponse,
            Response failedResponse
        );
    }
}
