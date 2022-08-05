using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Account> GetAccountByUserCode(string userCode, RegistrationTypes registrationTypes)
        {
            var user = await _unitOfWork.Users.GetUserByCode(userCode).Include(user=>user.Accounts).FirstOrDefaultAsync();
            
            var account = user.Accounts.Where(x => x.RegistrationType == registrationTypes.GetInt()).FirstOrDefault();

            return account;
        }

        public async Task<int?> GetAccountIdBy(string userCode, RegistrationTypes registrationType)
        {
            var user = await _unitOfWork.Users.GetUserByCode(userCode).FirstOrDefaultAsync();

            var account = user.Accounts.Where(x => x.RegistrationType == ((int) registrationType)).FirstOrDefault();

            return account.Id;
        }
        //public async Task<Account> GetAccountByRegistration(string registration, RegistrationTypes registrationTypes, Roles role)
        //{
        //    switch (registrationTypes)
        //    {
        //        case RegistrationTypes.Email:
        //            return await _unitOfWork.Accounts.GetAccountByEmail(registration).FirstOrDefaultAsync();
        //        case RegistrationTypes.Phone:
        //            return await _unitOfWork.Accounts.GetAccountByPhoneNumber(registration).FirstOrDefaultAsync();
        //        default:
        //            return null;
        //    }           
        //}
        public async Task UpdateAccountRegistration(Account account, string registration, RegistrationTypes registrationTypes)
        {
                account.Registration = registration;
                account.Verified = false;
                await _unitOfWork.Accounts.Update(account);
        }

        public async Task UpdateAccountVerification(Account account)
        {
            account.Verified = true;
            await _unitOfWork.Accounts.Update(account);
        }
    }
}
