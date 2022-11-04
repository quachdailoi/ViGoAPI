using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IWalletTransactionRepository : IGenericRepository<WalletTransaction>
    {
        Task<WalletTransaction?> GetByCode(Guid code);
    }
}
