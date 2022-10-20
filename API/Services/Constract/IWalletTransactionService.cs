using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;

namespace API.Services.Constract
{
    public interface IWalletTransactionService
    {
        Task<Response> GetTransactions(int userId, Response successResponse, PagingRequest? request = null);
        Task<bool> Update(WalletTransactionDTO dto);
        Task<WalletTransactionDTO?> Create(WalletTransactionDTO dto);
    }
}
