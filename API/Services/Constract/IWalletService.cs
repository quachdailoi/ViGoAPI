﻿using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IWalletService
    {
        Task<Wallet?> UpdateBalance(WalletTransactionDTO transactionDto, bool saveTransaction = true);
        Task<Wallet?> UpdateBalance(int userId, double amount);
        Task<Response> HandleWalletTopUpRequest(int userId, WalletTransactionDTO transactionDto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response notSupportResponse,Response errorResponse);
        Task<Response> GetWallet(int userId, Response successResponse, Response errorResponse);
        Task<Wallet?> GetWallet(int userId);

        Task<bool?> UpdateSystemWalletBalance(WalletTransactionDTO transactionDto);
        Task<Response> GetDashboardInfo(MonthFilterRequest monthFilterRequest, Response successReponse);
    }
}
