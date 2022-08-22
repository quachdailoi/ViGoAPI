using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        protected readonly IVerifiedCodeService _verifiedCodeService;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public AccountService(IVerifiedCodeService verifiedCodeService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _verifiedCodeService = verifiedCodeService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Account?> GetAccountByUserCodeAsync(string userCode, RegistrationTypes registrationTypes)
        {
            var user = await _unitOfWork.Users.GetUserByCode(userCode).Include(user => user.Accounts).FirstOrDefaultAsync();

            if (user == null) return null;

            var account = user.Accounts.Where(x => x.RegistrationType == registrationTypes).FirstOrDefault();

            return account;
        }

        public IQueryable<Account>? GetAccountByUserCode(string userCode, RegistrationTypes registrationTypes)
        {
            var user = _unitOfWork.Users.GetUserByCode(userCode).FirstOrDefault();

            if (user == null) return null;

            var account = _unitOfWork.Accounts
                .List(acc => acc.UserId == user.Id && acc.RegistrationType == registrationTypes);

            return account;
        }

        public async Task<int?> GetAccountIdBy(string userCode, RegistrationTypes registrationType)
        {
            var user = await _unitOfWork.Users.GetUserByCode(userCode).FirstOrDefaultAsync();

            if (user == null) return null;

            var account = user.Accounts.Where(x => x.RegistrationType == registrationType).FirstOrDefault();

            if (account == null) return null;

            return account.Id;
        }

        public IQueryable<Account>? GetRoleAccountByRegistration(Roles roleId, string registration, RegistrationTypes registrationType)
        {
            var accounts = _unitOfWork.Accounts.GetAccountByRegistration(registration, registrationType);

            var roles = _unitOfWork.Roles.GetRoleById(roleId);

            var roleAccount = from account in accounts
                              join role in roles on account.RoleId equals role.Id
                              select account;

            return roleAccount;
        }

        public async Task<bool> UpdateAccountRegistration(Account? account, string registration, RegistrationTypes registrationTypes, bool isVerified = false)
        {
            if (account == null || registrationTypes != account.RegistrationType)
            {
                return false;
            }

            account.Registration = registration;
            account.Verified = isVerified;
            return await _unitOfWork.Accounts.Update(account);
        }

        public async Task<bool> VerifyAccount(Account? account)
        {
            if (account == null) return false;
            account.Verified = true;
            return await _unitOfWork.Accounts.Update(account);
        }

        public Response? CheckNotExisted(Roles roles, SendOtpRequest request, string errorMessage, int errorCode, bool? isVerified = false)
        {
            var accounts = GetAccount(roles, request.Registration, request.RegistrationTypes);
            if (isVerified != null)
            {
                accounts = accounts?.Where(acc => acc.Verified == isVerified);
            }

            var account = accounts?.FirstOrDefault();

            if (account != null)
            {
                return new(
                    StatusCode: errorCode,
                    Message: errorMessage
                );
            }

            return null;
        }

        public Response? CheckExisted(Roles roles, SendOtpRequest request, string errorMessage, int errorCode, bool? isVerified = null)
        {
            var accounts = GetAccount(roles, request.Registration, request.RegistrationTypes);

            if (isVerified != null)
            {
                accounts = accounts?.Where(acc => acc.Verified == isVerified);
            }

            var account = accounts?.FirstOrDefault();

            if (account == null)
            {
                return new(
                    StatusCode: errorCode,
                    Message: errorMessage
                );
            }

            return null;
        }

        public IQueryable<Account>? GetAccount(Roles roles, string registration, RegistrationTypes registrationTypes)
        {
            return GetRoleAccountByRegistration(roles, registration, registrationTypes);
        }

        public async Task<UserViewModel?> GetUserViewModel(Roles roles, string registration, RegistrationTypes registrationTypes)
        {
            var account = await GetAccount(roles, registration, registrationTypes)?.FirstOrDefaultAsync() ?? null;

            if (account == null) return null;

            var user = _unitOfWork.Users.List(user => user.Id == account.UserId);

            if (user == null) return null;

            return await user.MapTo<UserViewModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<Response> UpdateUserAccount(string userCode, Roles userRole, UpdateUserInfoRequest request, string[] errorMessages, int[] errorCodes)
        {
            var existResponse = CheckNotExisted(userRole, request, errorMessages[0], errorCodes[0], isVerified: true);
            if (existResponse != null) return existResponse;

            var user = await _unitOfWork.Users.GetUserByCode(userCode).Include(acc => acc.Accounts).FirstOrDefaultAsync();
            var account = user?.Accounts.Where(acc => acc.RegistrationType == request.RegistrationTypes).FirstOrDefault();

            var errorResponse = new Response(
                   StatusCode: errorCodes[1],
                   Message: errorMessages[1]
               );

            if (user == null) return errorResponse;

            // open transaction
            await _unitOfWork.CreateTransactionAsync();
            user.Name = request.Name;
            user.Gender = request.Gender;
            user.DateOfBirth = request.DateOfBirth;

            var result = await _unitOfWork.Users.Update(user);
            if (!result)
            {
                await _unitOfWork.Rollback();
                return errorResponse;
            }

            if (account != null && !string.IsNullOrEmpty(request.Registration))
            {
                account.Registration = request.Registration;
                account.Verified = false;

                result = await _unitOfWork.Accounts.Update(account);
                if (!result)
                {
                    await _unitOfWork.Rollback();
                    return errorResponse;
                }
            }

            //commit transaction
            await _unitOfWork.CommitAsync();
            return await _verifiedCodeService.SendAndSaveOtp(request, errorMessages[1], errorCodes[1]);
        }
    }
}
