using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using API.Utils;
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
        private readonly IPaymentService _paymentService;

        public WalletService(IUnitOfWork unitOfWork, IMapper mapper, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paymentService = paymentService;
        }
        private IQueryable<Wallet> GetWalletQueryable(int userId) => _unitOfWork.Wallets
            .List(wallet => wallet.UserId == userId && wallet.Status == Wallets.Status.Active);
        public Task<Wallet?> GetWallet(int userId) => GetWalletQueryable(userId).FirstOrDefaultAsync();
        public async Task<Response> GetWallet(int userId, Response successResponse, Response errorResponse)
        {
            var walletVM =
                await GetWalletQueryable(userId)
                .MapTo<WalletViewModel>(_mapper)
                .FirstOrDefaultAsync();

            if (walletVM == null) return errorResponse;
            
            return successResponse.SetData(walletVM);
        }

        public async Task<Response> HandleWalletTopUpRequest(int userId, WalletTransactionDTO transactionDto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response notSupportResponse,Response errorResponse)
        {
            var wallet = await _unitOfWork.Wallets.List(e => e.UserId == userId && e.Status == Wallets.Status.Active).FirstOrDefaultAsync();

            if (wallet == null) return notSupportResponse;

            transactionDto.WalletId = wallet.Id;

            dynamic dataResponse;

            await _unitOfWork.CreateTransactionAsync();

            var walletTransaction = _mapper.Map<WalletTransaction>(transactionDto);

            walletTransaction = await _unitOfWork.WalletTransactions.Add(walletTransaction);

            try
            {
                if (walletTransaction == null) throw new Exception();
                switch (transactionDto.Type)
                {
                    case WalletTransactions.Types.MomoIncome:

                        ((MomoCollectionLinkRequestDTO)paymentDto).amount = (long)walletTransaction.Amount;
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderId = walletTransaction.Code.ToString();
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderInfo = "Top up ViGo Wallet";
                        ((MomoCollectionLinkRequestDTO)paymentDto).extraData = Encryption.EncodeBase64(_mapper.Map<WalletTransactionDTO>(walletTransaction));


                        var response = await _paymentService.GenerateMomoPaymentUrl((MomoCollectionLinkRequestDTO)paymentDto);

                        if (response == null) throw new Exception();

                        dataResponse = new
                        {
                            PayUrl = response.deeplink,
                            WebUrl = response.payUrl
                        };
                        break;
                    default:
                        return notSupportResponse;
                }
            }
            catch(Exception ex)
            {
                await _unitOfWork.Rollback();
                return errorResponse.SetMessage(ex.Message);
            }

            await _unitOfWork.CommitAsync();

            return successResponse.SetData(dataResponse);
        }

        public async Task<Wallet?> UpdateBalance(WalletTransactionDTO transactionDto)
        {
            var wallet = await _unitOfWork.Wallets
                .List(wallet => wallet.Id == transactionDto.WalletId && wallet.Status == Wallets.Status.Active)
                .Include(wallet => wallet.WalletTransactions)
                .Include(wallet => wallet.User)
                .FirstOrDefaultAsync();

            if (wallet == null) return null;

            var transaction = wallet.WalletTransactions.Find(trans => trans.Id == transactionDto.Id);

            if (transaction != null)
            {
                transaction.Status = transactionDto.Status;
            }
            else 
            {
                transaction = _mapper.Map<WalletTransaction>(transactionDto);
                wallet.WalletTransactions.Add(transaction);
            }

            wallet.Balance += transactionDto.Amount;

            if (wallet.Balance < 0) return null;

            return _unitOfWork.Wallets.Update(wallet).Result ? wallet : null;
        }
    }
}
