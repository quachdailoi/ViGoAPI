using Domain.Entities;
using Domain.Shares.Enums;

namespace Domain.Interfaces.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        IQueryable<Account> GetAccountByRegistration(string registration, RegistrationTypes registrationTypes);
        IQueryable<Account> GetAccountByUserId(int userId);
    }
}
