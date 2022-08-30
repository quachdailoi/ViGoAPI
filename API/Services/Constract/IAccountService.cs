using API.Models;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IAccountService
    {
        Task<int?> GetAccountIdBy(string userCode, RegistrationTypes registrationType);
        Task<Account?> GetAccountByUserCodeAsync(string userCode, RegistrationTypes registrationTypes);

        IQueryable<Account>? GetAccountByUserCode(string userCode, RegistrationTypes registrationTypes);
        Task<Response> UpdateAccountRegistration(Account? account, SendOtpRequest request, bool isVerified, Response successResponse, Response errorResponse);
        Task<Response> VerifyAccount(Account? account, Response successResponse, Response errorResponse);
        IQueryable<Account>? GetRoleAccountByRegistration(Roles roleId, string registration, RegistrationTypes registrationType);
        Task<UserViewModel?> GetUserViewModel(Roles roles, string registration, RegistrationTypes registrationTypes);
        Response? CheckNotExisted(Roles roles, SendOtpRequest request, Response existResponse, bool? isVerified = false);
        Response? CheckExisted(Roles roles, SendOtpRequest request, Response notExistResponse, bool? isVerified = false);
        Task<Response> UpdateUserAccount(
            string userCode, Roles userRole,
            UserInfoRequest request,
            Response successResponse,
            Response duplicateReponse,
            Response failedResponse
        );

        Task<Response> CreateUserAccount(
             Roles userRole, UserRegisterRequest request,
             Response successResponse,
             Response duplicatedRegistrationResponse,
             Response failedResponse
         );
    }
}
