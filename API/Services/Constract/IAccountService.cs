using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IAccountService
    {
        Task<int?> GetAccountIdBy(string userCode, RegistrationTypes registrationType);
        Task<Account> GetAccountByUserCode(string userCode, RegistrationTypes registrationTypes);
        Task UpdateAccountVerification(Account account);

        Task UpdateAccountRegistration(Account account,string registration, RegistrationTypes registrationTypes);
        //Task<Account> GetAccountByRegistration(string registration, RegistrationTypes registrationTypes, );
    }
}
