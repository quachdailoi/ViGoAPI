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
        Task<bool> UpdateAccountRegistration(Account? account, string registration, RegistrationTypes registrationTypes, bool isVerified = false);
        Task<bool> VerifyAccount(Account? account);
        IQueryable<Account>? GetRoleAccountByRegistration(Roles roleId, string registration, RegistrationTypes registrationType);
        Task<UserViewModel?> GetUserViewModel(Roles roles, string registration, RegistrationTypes registrationTypes);
        Response? CheckNotExisted(Roles roles, SendOtpRequest request, string existMessage, int statusCode, bool? isVerified = false);
        Response? CheckExisted(Roles roles, SendOtpRequest request, string existMessage, int statusCode, bool? isVerified = false);
        Task<Response> UpdateUserAccount(string userCode, Roles userRole, UpdateUserInfoRequest request, string[] errorMessages, int[] errorCodes);
    }
}
