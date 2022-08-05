using API.Extensions;
using API.Models;
using API.Models.Requests;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Base;
using Domain.Interfaces.Services;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private static Random Random = new Random();

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetDriverUserViewModelByEmail(string email)
        {
            var driverAccount = await this.GetDriverAccountByEmail(email);

            if (driverAccount == null)
            {
                return null;
            }
 
            var driverUser = await this.GetUserOfAccount(driverAccount);

            return _mapper.Map<UserViewModel> (driverUser);
        }

        public async Task<Account> GetDriverAccountByEmail(string email)
        {
            return await GetRoleAccountByRegistration(email, RegistrationTypes.Email.GetInt(), Roles.DRIVER.GetString());
        }

        public async Task<Account> GetBookerAccountByPhoneNumber(string phoneNumber)
        {
            return await GetRoleAccountByRegistration(phoneNumber, RegistrationTypes.Phone.GetInt(), Roles.BOOKER.GetString());
        }

        private async Task<Account> GetRoleAccountByRegistration(string registration, int registrationType, string roleName)
        {
            var accounts = default(IQueryable<Account>);

            if (registrationType == RegistrationTypes.Email.GetInt())
            {
                accounts = _unitOfWork.Accounts.GetAccountByEmail(registration);
            }
            else if (registrationType == RegistrationTypes.Phone.GetInt())
            {
                accounts = _unitOfWork.Accounts.GetAccountByPhoneNumber(registration);
            }

            var roles = _unitOfWork.Roles.GetRoleByName(roleName);

            var roleAccount = await (from account in accounts
                                       join role in roles
                                       on account.RoleId equals role.Id
                                       select account)
                    //.Include(acc => acc.User)
                    .Include(acc => acc.Role)
                    .FirstOrDefaultAsync();

            return roleAccount;
        }

        private async Task<User> GetUserOfAccount(Account account)
        {
            //return account.User;
            return await _unitOfWork.Users.List(user => user.Id == account.UserId).Include(user => user.Accounts).FirstOrDefaultAsync();
        }

        public async Task<UserViewModel> GetBookerUserViewModelByPhoneNumber(string phoneNumber)
        {
            var bookerAccount = await this.GetBookerAccountByPhoneNumber(phoneNumber);

            if (bookerAccount == null)
            {
                return null;
            }

            var bookerUser = await this.GetUserOfAccount(bookerAccount);

            return _mapper.Map<UserViewModel>(bookerUser);
        }

        public async Task<Account> GetBookerAccountByEmail(string email)
        {
            return await GetRoleAccountByRegistration(email, RegistrationTypes.Email.GetInt(), Roles.BOOKER.GetString());
        }

        public async Task<Account> GetDriverAccountByPhoneNumber(string phoneNumber)
        {
            return await GetRoleAccountByRegistration(phoneNumber, RegistrationTypes.Phone.GetInt(), Roles.DRIVER.GetString());
        }

        public async Task<UserViewModel> GetUserViewModelByRole(Roles role)
        {
            var account = _unitOfWork.Accounts.List(x => x.RoleId == ((int)role)).Include(acc=>acc.Role).FirstOrDefault();

            var user = await _unitOfWork.Users.List(user => user.Id == account.UserId).Include(user=>user.Accounts).FirstOrDefaultAsync();

            //var _user = await user.MapTo<UserViewModel>(_mapper).FirstOrDefaultAsync();

            return  _mapper.Map<UserViewModel>(user);
        }
    }
}
