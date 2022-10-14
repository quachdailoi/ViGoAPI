using API.Extensions;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Responses;
using API.Services.Constract;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class WalletTransactionService : IWalletTransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WalletTransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> GetTransactions(int userId, Response successResponse, PagingRequest? request = null)
        {
            var transactions = _unitOfWork.WalletTransactions.List(trans => trans.Wallet.UserId == userId);
        
            var paging = transactions.Paging(page: request?.Page, pageSize: request?.PageSize);

            var transactionVM = await paging.Items.MapTo<WalletTransactionViewModel>(_mapper).ToListAsync();

            return successResponse.SetData(new PagingViewModel<List<WalletTransactionViewModel>>()
            {
                Items = transactionVM,
                TotalItemsCount = paging.TotalItemsCount,
                Page = paging.Page,
                PageSize = paging.PageSize,
                TotalPagesCount = paging.TotalPagesCount
            });
        }
    }
}
