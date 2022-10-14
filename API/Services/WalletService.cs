using API.Models.DTO;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class WalletService : IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WalletService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool?> UpdateBalance(int userId, double amount, WalletTransactionDTO transactionDto)
        {
            var wallet = await _unitOfWork.Wallets.List(wallet => wallet.UserId == userId && wallet.Status == Wallets.Status.Active).FirstOrDefaultAsync();

            if (wallet == null) return null;

            var transaction = _mapper.Map<WalletTransaction>(transactionDto);

            wallet.WalletTransactions.Add(transaction);

            return _unitOfWork.Wallets.Update(wallet).Result;
        }
    }
}
