using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class WalletTransactionService : BaseService, IWalletTransactionService
    {
        public WalletTransactionService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<Response> GetTransactions(int userId, Response successResponse, PagingRequest? request = null)
        {
            var transactions = UnitOfWork.WalletTransactions
                .List(trans => trans.Wallet.UserId == userId && trans.Status != WalletTransactions.Status.Pending)
                .OrderByDescending(trans => trans.UpdatedAt);
        
            var paging = transactions.Paging(page: request?.Page, pageSize: request?.PageSize);

            var transactionVM = await paging.Items.MapTo<WalletTransactionViewModel>(Mapper).ToListAsync();

            return successResponse.SetData(new PagingViewModel<List<WalletTransactionViewModel>>()
            {
                Items = transactionVM,
                TotalItemsCount = paging.TotalItemsCount,
                Page = paging.Page,
                PageSize = paging.PageSize,
                TotalPagesCount = paging.TotalPagesCount
            });
        }

        public async Task<bool> Update(WalletTransactionDTO dto)
        {
            var transaction = await UnitOfWork.WalletTransactions.GetByCode(dto.Code);

            if (transaction == null) return false;

            transaction.Status = dto.Status;
            transaction.TxnId = dto.TxnId;

            if (dto.Status == WalletTransactions.Status.Success)
                await AppServices.Wallet.UpdateSystemWalletBalance(dto);

            return await UnitOfWork.WalletTransactions.Update(transaction);
        }

        public async Task<WalletTransactionDTO?> Create(WalletTransactionDTO dto)
        {
            var transaction = Mapper.Map<WalletTransaction>(dto);

            transaction = await UnitOfWork.WalletTransactions.Add(transaction);

            if (transaction == null) return null;

            if (dto.Status == WalletTransactions.Status.Success)
                await AppServices.Wallet.UpdateSystemWalletBalance(dto);

            return Mapper.Map<WalletTransactionDTO>(transaction);
        }
    }
}
