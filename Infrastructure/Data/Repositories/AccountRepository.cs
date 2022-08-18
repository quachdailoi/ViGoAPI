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

        public IQueryable<Account> GetAccountByRegistration(string registration, RegistrationTypes registrationTypes)
        {
            return List(account =>
                account.Registration == registration &&
                account.RegistrationType == registrationTypes && 
                account.RoleId != null
            );
        }

        public IQueryable<Account> GetAccountByUserId(int userId)
        {
            return List(account => account.UserId == userId);
        }
    }
}
