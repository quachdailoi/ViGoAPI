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
using System.Dynamic;

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
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderInfo = "ViWallet - Top up";
                        ((MomoCollectionLinkRequestDTO)paymentDto).extraData = Encryption.EncodeBase64(Mapper.Map<WalletTransactionDTO>(walletTransaction));


                        var momoResponse = await AppServices.Payment.GenerateMomoPaymentUrl((MomoCollectionLinkRequestDTO)paymentDto);

                        if (momoResponse == null) throw new Exception();

                        dataResponse = new
                        {
                            PayUrl = momoResponse.deeplink,
                            WebUrl = momoResponse.payUrl
                        };
                        break;
                    case WalletTransactions.Types.ZaloPayIncome:
                        ((ZaloCollectionLinkRequestDTO)paymentDto).amount = (long)walletTransaction.Amount;
                        ((ZaloCollectionLinkRequestDTO)paymentDto).raw_item = new List<object> { Mapper.Map<WalletTransactionDTO>(walletTransaction) };
                        ((ZaloCollectionLinkRequestDTO)paymentDto).description = "ViWallet - Top up";

                        var zaloPayResponse = await AppServices.Payment.GenerateZaloPaymentUrl((ZaloCollectionLinkRequestDTO)paymentDto);

                        if (zaloPayResponse == null) throw new Exception();

                        dataResponse = new
                        {
                            PayUrl = zaloPayResponse.order_url,
                            ZpTransToken = zaloPayResponse.zp_trans_token
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

        public async Task<Wallet?> UpdateBalance(int userId, double amount)
        {
            var wallet = await GetWallet(userId);

            if (wallet == null) return null;

            wallet.Balance += amount;

            return UnitOfWork.Wallets.Update(wallet).Result ? wallet : null;
        }
        public async Task<Wallet?> UpdateBalance(WalletTransactionDTO transactionDto, bool saveTransaction = true)
        {
            var wallet = await UnitOfWork.Wallets
                .List(wallet => wallet.Id == transactionDto.WalletId && wallet.Status == Wallets.Status.Active)
                .Include(wallet => wallet.WalletTransactions)
                .Include(wallet => wallet.User)
                .FirstOrDefaultAsync();

            if (wallet == null) return null;

            if (saveTransaction)
            {
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
            }

            switch (transactionDto.Type)
            {
                case WalletTransactions.Types.MomoIncome:
                case WalletTransactions.Types.ZaloPayIncome:
                case WalletTransactions.Types.VnPayIncome:
                case WalletTransactions.Types.BookingRefund:
                    wallet.Balance += transactionDto.Amount;
                    break;
                case WalletTransactions.Types.TripIncome:
                    wallet.Balance += transactionDto.Amount;
                    transactionDto.Type = WalletTransactions.Types.PayForDriver;
                    break;
                case WalletTransactions.Types.BookingPaid:
                    wallet.Balance -= transactionDto.Amount;
                    break;
                default:
                    
                    break;
            }

            if (wallet.Balance < 0) return null;

            if(transactionDto.Status == WalletTransactions.Status.Success)
                await UpdateSystemWalletBalance(transactionDto);

            return UnitOfWork.Wallets.Update(wallet).Result ? wallet : null;
        }

        public async Task<bool?> UpdateSystemWalletBalance(WalletTransactionDTO transactionDto)
        {
            var wallet = await UnitOfWork.Wallets
                .List(wallet => wallet.Type == Wallets.Types.System)
                .Include(wallet => wallet.WalletTransactions)
                .FirstOrDefaultAsync();

            if (wallet == null) return null;

            var transaction = Mapper.Map<WalletTransaction>(transactionDto);

            transaction.TxnId = String.Empty;
            transaction.BookingId = null;
            transaction.Id = 0;
            transaction.Code = Guid.NewGuid();
            transaction.WalletId = wallet.Id;

            wallet.WalletTransactions.Add(transaction);

            switch (transactionDto.Type)
            {
                case WalletTransactions.Types.BookingPaid:
                case WalletTransactions.Types.BookingPaidByMomo:
                case WalletTransactions.Types.BookingPaidByZaloPay:
                case WalletTransactions.Types.BookingPaidByVnPay:
                    wallet.Balance += transactionDto.Amount;
                    break;
                case WalletTransactions.Types.BookingRefund:
                case WalletTransactions.Types.BookingRefundMomo:
                case WalletTransactions.Types.BookingRefundZaloPay:
                case WalletTransactions.Types.PayForDriver:
                    wallet.Balance -= transactionDto.Amount;
                    break;
                default:
                    return null;
            }

            return UnitOfWork.Wallets.Update(wallet).Result;
        }

        //public async Task<WalletViewModel?> GetSystemWallet()
        //{
        //    return await UnitOfWork.Wallets
        //        .List(wallet => wallet.Type == Wallets.Types.System)
        //        .MapTo<WalletViewModel>(Mapper)
        //        .FirstOrDefaultAsync();
        //}

        public async Task<Response> GetDashboardInfo(MonthFilterRequest monthFilterRequest, Response successReponse)
        {
            var budget = UnitOfWork.Wallets.List(x => x.Type == Wallets.Types.System).FirstOrDefault()?.Balance ?? 0;

            var transactionQueryable = UnitOfWork.WalletTransactions
                .List(x => x.Wallet.Type == Wallets.Types.System);

            var bookingDetailQueryable = UnitOfWork.BookingDetails.List().Include(x => x.BookingDetailDrivers);

            var reportQueryable = UnitOfWork.Reports.List().Include(x => x.User);

            if (!String.IsNullOrEmpty(monthFilterRequest.FromMonth))
            {
                var fromMonthParsed = monthFilterRequest.FromMonthParsed().Value.ToDateTime(TimeOnly.MinValue);
                transactionQueryable = transactionQueryable.Where(x => x.CreatedAt >= fromMonthParsed);
            }
            if (!String.IsNullOrEmpty(monthFilterRequest.ToMonth))
            {
                var toMonthParsed = monthFilterRequest.ToMonthParsed().Value.ToDateTime(TimeOnly.MaxValue);
                transactionQueryable = transactionQueryable.Where(x => x.CreatedAt <= toMonthParsed);
            }

            transactionQueryable = transactionQueryable.OrderBy(x => x.CreatedAt);

            var transactions = transactionQueryable.ToList(); 

            var fromDate = monthFilterRequest.FromMonth != null ? monthFilterRequest.FromMonthParsed().Value : transactions.FirstOrDefault()?.CreatedAt.ToDateOnly().FirstDateOfMonth();

            var toDate = monthFilterRequest.ToMonth != null ? monthFilterRequest.ToMonthParsed().Value : DateTimeExtensions.NowDateOnly.LastDateOfMonth();

            var data = new Dictionary<string, object>();

            var bookingDetails = new List<BookingDetail>();

            var reports = new List<Report>();

            if(fromDate.HasValue)
            {
                bookingDetails = bookingDetailQueryable.Where(x => x.Date >= fromDate.Value && x.Date <= toDate).ToList();

                var fromDateTime = fromDate.Value.ToDateTime(TimeOnly.MinValue);
                var toDateTime = toDate.ToDateTime(TimeOnly.MaxValue);

                reports = reportQueryable.Where(x => x.CreatedAt >= fromDateTime && x.CreatedAt <= toDateTime).ToList();

                for(var date = fromDate.Value; date <= toDate; date = date.AddMonths(1))
                {
                    var firstDateOfMonth = date.FirstDateOfMonth();
                    var lastDateOfMonth = date.LastDateOfMonth();

                    var transactionsInMonth = transactions.Where(x => x.CreatedAt.ToDateOnly() >= firstDateOfMonth && x.CreatedAt.ToDateOnly() <= lastDateOfMonth).ToList();
                    
                    var bookingDetailsInMonth = bookingDetails.Where(x => x.Date >= firstDateOfMonth && x.Date <= lastDateOfMonth).ToList();
                    
                    var reportsInMonth = reports.Where(x => x.CreatedAt.ToDateOnly() >= firstDateOfMonth && x.CreatedAt.ToDateOnly() <= lastDateOfMonth).ToList();
                    
                    var bookingDetailDriversInMonth = new List<BookingDetailDriver>();
                    bookingDetailsInMonth.ForEach(x => bookingDetailDriversInMonth.AddRange(x.BookingDetailDrivers));

                    var finance = GetFinanceInfo(transactionsInMonth);
                    var bookingDetailInfo = GetBookingDetailsInfo(bookingDetailsInMonth);
                    var bookingDetailDriverInfo = GetBookingDetailDriversInfo(bookingDetailDriversInMonth);
                    var reportInfo = GetReportsInfo(reportsInMonth);


                    dynamic item = new ExpandoObject();

                    item.Finance = finance;
                    item.BookingDetailInfo = bookingDetailInfo;
                    item.BookingDetailDrvierInfo = bookingDetailDriverInfo;
                    item.ReportInfo = reportInfo;

                    data.TryAdd(date.ToString("MM-yyyy"), item);
                }
            }

            return successReponse.SetData(new
            {
                Budget = budget,
                Items = data
            });
        }
        private dynamic GetReportsInfo(List<Report> reports)
        {
            var totalDriverReport = reports.Count(x => x.User.RoleName == Roles.DRIVER.GetName());
            var totalBookerReport = reports.Count(x => x.User.RoleName == Roles.BOOKER.GetName());

            return new
            {
                TotalDriverReport = totalDriverReport,
                TotalBookerReport = totalBookerReport
            };
        }
        private dynamic GetBookingDetailDriversInfo(List<BookingDetailDriver> bookingDetailDrivers)
        {
            var total = bookingDetailDrivers.Count;
            var totalCompleted = bookingDetailDrivers.Count(x => x.TripStatus == BookingDetailDrivers.TripStatus.Completed);
            var totalCancelled = bookingDetailDrivers.Count(x => x.TripStatus == BookingDetailDrivers.TripStatus.Cancelled);
            var totalPending = bookingDetailDrivers.Count(x => x.TripStatus != BookingDetailDrivers.TripStatus.Cancelled && x.TripStatus != BookingDetailDrivers.TripStatus.Completed);

            return new
            {
                Total = total,
                TotalCompleted = totalCompleted,
                TotalCancelled = totalCancelled,
                TotalPending = totalPending
            };
        }

        private dynamic GetBookingDetailsInfo(List<BookingDetail> bookingDetails)
        {
            var total = bookingDetails.Count;
            var totalCompleted = bookingDetails.Count(x => x.Status == BookingDetails.Status.Completed);
            var totalCancelled = bookingDetails.Count(x => x.Status == BookingDetails.Status.PendingRefund || x.Status == BookingDetails.Status.CompletedRefund || x.Status == BookingDetails.Status.Cancelled);
            var totalPending = bookingDetails.Count(x => x.Status == BookingDetails.Status.Pending || x.Status == BookingDetails.Status.Ready || x.Status == BookingDetails.Status.Started);

            return new
            {
                Total = total,
                TotalCompleted = totalCompleted,
                TotalCancelled = totalCancelled,
                TotalPending = totalPending
            };
        }

        private FinanceDTO GetFinanceInfo(List<WalletTransaction> transactions)
        {
            var financeDto = new FinanceDTO();

            foreach (var transaction in transactions)
            {
                switch (transaction.Type)
                {
                    case WalletTransactions.Types.BookingPaid:
                    case WalletTransactions.Types.BookingPaidByMomo:
                    case WalletTransactions.Types.BookingPaidByZaloPay:
                    case WalletTransactions.Types.BookingPaidByVnPay:
                        financeDto.TotalRevenue += transaction.Amount;
                        break;
                    case WalletTransactions.Types.BookingRefund:
                    case WalletTransactions.Types.BookingRefundMomo:
                    case WalletTransactions.Types.BookingRefundZaloPay:
                        financeDto.TotalRefund += transaction.Amount;
                        break;
                    case WalletTransactions.Types.PayForDriver:
                        financeDto.TotalPayForDriver += transaction.Amount;
                        break;
                }
            }

            return financeDto;
        }
    }
}
