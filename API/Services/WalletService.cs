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
    public class WalletService : BaseService, IWalletService
    {
        public WalletService(IAppServices appServices) : base(appServices)
        {
        }

        private IQueryable<Wallet> GetWalletQueryable(int userId) => UnitOfWork.Wallets
            .List(wallet => wallet.UserId == userId && wallet.Status == Wallets.Status.Active);
        public Task<Wallet?> GetWallet(int userId) => GetWalletQueryable(userId).FirstOrDefaultAsync();
        public async Task<Response> GetWallet(int userId, Response successResponse, Response errorResponse)
        {
            var walletVM =
                await GetWalletQueryable(userId)
                .MapTo<WalletViewModel>(Mapper)
                .FirstOrDefaultAsync();

            if (walletVM == null) return errorResponse;
            
            return successResponse.SetData(walletVM);
        }

        public async Task<Response> HandleWalletTopUpRequest(int userId, WalletTransactionDTO transactionDto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response notSupportResponse,Response errorResponse)
        {
            var wallet = await UnitOfWork.Wallets.List(e => e.UserId == userId && e.Status == Wallets.Status.Active).FirstOrDefaultAsync();

            if (wallet == null) return notSupportResponse;

            transactionDto.WalletId = wallet.Id;

            dynamic dataResponse;

            await UnitOfWork.CreateTransactionAsync();

            var walletTransaction = Mapper.Map<WalletTransaction>(transactionDto);

            walletTransaction = await UnitOfWork.WalletTransactions.Add(walletTransaction);

            try
            {
                if (walletTransaction == null) throw new Exception();
                switch (transactionDto.Type)
                {
                    case WalletTransactions.Types.MomoIncome:

                        ((MomoCollectionLinkRequestDTO)paymentDto).amount = (long)walletTransaction.Amount;
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderId = walletTransaction.Code.ToString();
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderInfo = "Top up ViGo Wallet";
                        ((MomoCollectionLinkRequestDTO)paymentDto).extraData = Encryption.EncodeBase64(Mapper.Map<WalletTransactionDTO>(walletTransaction));


                        var response = await AppServices.Payment.GenerateMomoPaymentUrl((MomoCollectionLinkRequestDTO)paymentDto);

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
                await UnitOfWork.Rollback();
                return errorResponse.SetMessage(ex.Message);
            }

            await UnitOfWork.CommitAsync();

            return successResponse.SetData(dataResponse);
        }

        public async Task<Wallet?> UpdateBalance(WalletTransactionDTO transactionDto)
        {
            var wallet = await UnitOfWork.Wallets
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
                transaction = Mapper.Map<WalletTransaction>(transactionDto);
                wallet.WalletTransactions.Add(transaction);
            }

            switch (transactionDto.Type)
            {
                case WalletTransactions.Types.MomoIncome:
                case WalletTransactions.Types.ZaloPayIncome:
                case WalletTransactions.Types.VnPayIncome:
                    wallet.Balance += transactionDto.Amount;
                    break;
                default:
                    wallet.Balance -= transactionDto.Amount;
                    break;
            }

            if (wallet.Balance < 0) return null;

            return UnitOfWork.Wallets.Update(wallet).Result ? wallet : null;
        }
    }
}
