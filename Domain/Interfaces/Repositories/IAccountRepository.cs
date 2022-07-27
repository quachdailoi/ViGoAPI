using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        IQueryable<Account> GetAccountByEmail(string email);
        IQueryable<Account> GetAccountByPhoneNumber(string phoneNumber);
    }
}
