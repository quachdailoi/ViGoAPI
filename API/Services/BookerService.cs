using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using Twilio.Rest.Api.V2010.Account;

namespace API.Services
{
    public class BookerService : AccountService, IBookerService
    {
        public BookerService(IVerifiedCodeService verifiedCodeService, IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IUserService userService) 
            : base(verifiedCodeService, unitOfWork, mapper, configuration, userService)
        {
        }

        public Response? CheckNotExisted(SendOtpRequest request, Response errorResponse, bool? isVerified = null)
        {
            return base.CheckNotExisted(Roles.BOOKER, request, errorResponse, isVerified);
        }

        public Response? CheckExisted(SendOtpRequest request, Response errorResponse, bool? isVerified = null)
        {
            return base.CheckExisted(Roles.BOOKER, request, errorResponse, isVerified);
        }

        public Task<UserViewModel?> GetUserViewModel(SendOtpRequest request)
        {
            return base.GetUserViewModel(Roles.BOOKER, request.Registration, request.RegistrationTypes);
        }

        public async Task<UserViewModel?> GetUserViewModel()
        {
            var account = _unitOfWork.Accounts.List(x => x.RoleId == Roles.BOOKER).Include(acc => acc.Role).FirstOrDefault();

            if (account == null) return null;

            var user = await _unitOfWork.Users.List(user => user.Id == account.UserId).Include(user => user.Accounts).FirstOrDefaultAsync();

            return _mapper.Map<UserViewModel>(user);
        }

        public IQueryable<Account>? GetAccount(string registration, RegistrationTypes registrationTypes)
        {
            return base.GetAccount(Roles.BOOKER, registration, registrationTypes);
        }

        public Task<UserViewModel?> GetUserViewModel(string registration, RegistrationTypes registrationTypes)
        {
            return base.GetUserViewModel(Roles.BOOKER, registration, registrationTypes);
        }

        public Task<Response> UpdateBookerAccount(
            string userCode,
            UpdateUserInfoRequest request,
            Response successResponse,
            Response duplicateReponse,
            Response failedResponse)
        {
            return base.UpdateUserAccount(
                userCode, 
                Roles.BOOKER, 
                request, 
                successResponse, 
                duplicateReponse, 
                failedResponse
            );
        }

        public Task<Response> CreateBookerAccount(UserRegisterRequest request,
            Response successResponse,
            Response duplicatedRegistrationResponse,
            Response failedResponse)
        {
            return base.CreateUserAccount(
                Roles.BOOKER, 
                request, 
                successResponse, 
                duplicatedRegistrationResponse,
                failedResponse
            );
        }
    }
}
