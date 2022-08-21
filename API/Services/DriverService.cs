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
        public DriverService(IVerifiedCodeService verifiedCodeService, IUnitOfWork unitOfWork, IMapper mapper) : base(verifiedCodeService, unitOfWork, mapper)
        {
        }

        public IQueryable<Account>? GetAccount(string registration, RegistrationTypes registrationTypes)
        {
            return base.GetAccount(Roles.DRIVER, registration, registrationTypes);
        }

        public async Task<UserViewModel?> GetUserViewModel()
        {
            var account = _unitOfWork.Accounts.List(x => x.RoleId == Roles.DRIVER).Include(acc => acc.Role).FirstOrDefault();

            if (account == null) return null;

            var user = await _unitOfWork.Users.List(user => user.Id == account.UserId).Include(user => user.Accounts).FirstOrDefaultAsync();

            return _mapper.Map<UserViewModel>(user);
        }

        public Response? CheckExisted(SendOtpRequest request, string errorMessage, int errorCode, bool? isVerified = null)
        {
            return base.CheckExisted(Roles.DRIVER, request, errorMessage, errorCode);
        }

        public Response? CheckNotExisted(SendOtpRequest request, string errorMessage, int errorCode, bool? isVerified = null)
        {
            return base.CheckNotExisted(Roles.DRIVER, request, errorMessage, errorCode);
        }

        public async Task<UserViewModel?> GetUserViewModel(SendOtpRequest request)
        {
            return await base.GetUserViewModel(Roles.DRIVER, request.Registration, request.RegistrationTypes);
        }

        public async Task<UserViewModel?> GetUserViewModel(string registration, RegistrationTypes registrationTypes)
        {
            return await base.GetUserViewModel(Roles.DRIVER, registration, registrationTypes);
        }
    }
}
