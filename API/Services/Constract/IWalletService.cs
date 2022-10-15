using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IWalletService
    {
        Task<Wallet?> UpdateBalance(WalletTransactionDTO transactionDto);
        Task<Response> HandleWalletTopUpRequest(int userId, WalletTransactionDTO transactionDto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response notSupportResponse,Response errorResponse);
        Task<Response> GetWallet(int userId, Response successResponse, Response errorResponse);
        Task<Wallet?> GetWallet(int userId);
    }
}
