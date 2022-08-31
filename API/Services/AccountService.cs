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
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AccountService(
            IVerifiedCodeService verifiedCodeService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IConfiguration configuration,
            IUserService userService)
        {
            _verifiedCodeService = verifiedCodeService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _userService = userService;
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

        public async Task<Response> UpdateAccountRegistration(Account? account, SendOtpRequest request, bool isVerified, Response successResponse, Response errorResponse)
        {
            if (account == null || request.RegistrationTypes != account.RegistrationType)
            {
                return errorResponse;
            }

            account.Registration = request.Registration;
            account.Verified = isVerified;

            if (!await _unitOfWork.Accounts.Update(account)) return errorResponse;

            return successResponse;
        }

        public async Task<Response> VerifyAccount(Account? account, Response successResponse, Response errorResponse)
        {
            if (account == null) return errorResponse;
            account.Verified = true;
            if (await _unitOfWork.Accounts.Update(account)) return successResponse;
            else return errorResponse;
        }

        public Response? CheckNotExisted(Roles roles, SendOtpRequest request, Response existResponse, bool? isVerified = false)
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
                    StatusCode: existResponse.StatusCode,
                    Message: existResponse.Message
                );
            }

            return null;
        }

        public Response? CheckExisted(Roles roles, SendOtpRequest request, Response notExistResponse, bool? isVerified = null)
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
                    StatusCode: notExistResponse.StatusCode,
                    Message: notExistResponse.Message
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

        public async Task<Response> UpdateUserAccount(
            string userCode, Roles userRole,
            UserInfoRequest request,
            Response successResponse,
            Response duplicateReponse,
            Response failedResponse)
        {
            var existResponse = CheckNotExisted(userRole, request, duplicateReponse, isVerified: true);
            if (existResponse != null) return existResponse;

            var user = await _unitOfWork.Users.GetUserByCode(userCode).Include(acc => acc.Accounts).FirstOrDefaultAsync();
            var account = user?.Accounts.Where(acc => acc.RegistrationType == request.RegistrationTypes).FirstOrDefault();

            if (user == null) return failedResponse;

            // open transaction
            await _unitOfWork.CreateTransactionAsync();

            user.Name = request.Name;
            user.Gender = request.Gender;
            user.DateOfBirth = request.DateOfBirth;

            if (account != null && !string.IsNullOrEmpty(request.Registration))
            {
                account.Registration = request.Registration;
                account.Verified = false;

                if (!await _unitOfWork.Accounts.Update(account))
                {
                    await _unitOfWork.Rollback();
                    return failedResponse;
                }
            }

            //commit transaction
            await _unitOfWork.CommitAsync();

            // transaction for update avatar
            return await _userService.UpdateUserAvatar(userCode, request.Avatar, successResponse, failedResponse);
        }

        public async Task<Response> CreateUserAccount(
            Roles userRole, UserRegisterRequest request,
            Response successResponse,
            Response duplicatedRegistrationResponse,
            Response failedResponse)
        {
            var existResponse = CheckNotExisted(userRole, request, duplicatedRegistrationResponse, isVerified: true);
            if (existResponse != null) return existResponse;

            var authAccount = new Account()
            {
                Registration = request.Registration,
                RegistrationType = request.RegistrationTypes,
                RoleId = userRole,
                Verified = true
            };

            var accounts = new List<Account>() { authAccount };

            if (!string.IsNullOrEmpty(request.OptionalRegistration))
            {
                // email or phone base user role
                var optionalAccount = new Account()
                {
                    Registration = request.OptionalRegistration,
                    RegistrationType = request.OptionalRegistrationTypes,
                    RoleId = userRole,
                    Verified = false
                };

                accounts.Add(optionalAccount);
            }

            var defaultAvatar = new AppFile
            {
                Path = $"{_configuration.GetConfigByEnv("AwsSettings:UserAvatarFolder")}{_configuration.GetConfigByEnv("AwsSettings:DefaultAvatar")}",
                Type = FileTypes.Image,
            };

            var newUser = new User()
            {
                Name = request.Name,
                Accounts = accounts,
                File = defaultAvatar
            };

            // open transaction
            await _unitOfWork.CreateTransactionAsync();

            newUser = await _unitOfWork.Users.Add(newUser);

            if (newUser == null)
            {
                await _unitOfWork.Rollback();
                return failedResponse;
            }

            //commit transaction
            await _unitOfWork.CommitAsync();
            return successResponse;
        }
    }
}