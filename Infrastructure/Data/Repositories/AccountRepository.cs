using Microsoft.Extensions.Logging;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext, ILogger<AccountRepository> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<Account> GetAccountByEmail(string email)
        {
            return GetAccountByRegistration(email, ((int)RegistrationTypes.Email));
        }

        public IQueryable<Account> GetAccountByPhoneNumber(string phoneNumber)
        {
            return GetAccountByRegistration(phoneNumber, ((int)RegistrationTypes.Phone));
        }

        private IQueryable<Account> GetAccountByRegistration(string registration, int registrationType)
        {
            return List(account =>
                account.Registration == registration &&
                account.RegistrationType == registrationType
            );
        }
    }
}
