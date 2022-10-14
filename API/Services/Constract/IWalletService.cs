using API.Models.DTO;

namespace API.Services.Constract
{
    public interface IWalletService
    {
        Task<bool?> UpdateBalance(int userId, double amount, WalletTransactionDTO transactionDto);
    }
}
