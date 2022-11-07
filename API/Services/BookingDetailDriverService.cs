using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Services.Constract;
using API.Utils;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BookingDetailDriverService : BaseService, IBookingDetailDriverService
    {
        public BookingDetailDriverService(IAppServices appServices) : base(appServices)
        {
        }

        public Task<List<BookingDetailDriver>> Create(List<BookingDetailDriver> bookingDetailDrivers) => UnitOfWork.BookingDetailDrivers.Add(bookingDetailDrivers);

        public async Task<BookingDetailDriver?> GetBookingDetailDriverByCode(string code)
        {
            return await UnitOfWork.BookingDetailDrivers
                .List(x => x.Code.ToString() == code)
                .Include(x => x.RouteRoutine)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateTripStatus(BookingDetailDriver bookingDetailDriver, BookingDetailDrivers.TripStatus tripStatus)
        {
            bookingDetailDriver.TripStatus = tripStatus;

            var bookingDetail = await AppServices.BookingDetail.GetById(bookingDetailDriver.BookingDetailId);

            if (bookingDetail != null)
            {
                if (tripStatus == BookingDetailDrivers.TripStatus.Completed)
                {
                    bookingDetail.Status = BookingDetails.Status.Completed;
                    bookingDetailDriver.BookingDetail = bookingDetail;

                    var wallet = await AppServices.Wallet.GetWallet(bookingDetailDriver.RouteRoutine.UserId);

                    if(wallet != null)
                    {
                        var transactionDto = new WalletTransactionDTO
                        {
                            Amount = Fee.FloorToHundreds((bookingDetail.Price + bookingDetail.DiscountPrice) * 0.2),
                            Status = WalletTransactions.Status.Success,
                            WalletId = wallet.Id,
                            Type = WalletTransactions.Types.TripIncome
                        };

                        if((wallet = AppServices.Wallet.UpdateBalance(transactionDto).Result) != null)
                            await AppServices.SignalR.SendToUserAsync(bookingDetailDriver.RouteRoutine.User.Code.ToString(), "WalletTransaction", new WalletTransactionViewModel
                            {
                                Amount = transactionDto.Amount,
                                Code = transactionDto.Code,
                                Status = transactionDto.Status,
                                Type = transactionDto.Type,
                                Time = wallet.WalletTransactions.Last().UpdatedAt.ToFormatString()
                            });

                    }
                }

                await AppServices.SignalR.SendToUserAsync(bookingDetail.Booking.User.Code.ToString(), "TripStatus", new
                {
                    BookingDetailCode = bookingDetail.Code,
                    TripStatus = tripStatus,
                    TripStatusName = tripStatus.DisplayName()
                });
            }
            else Logger<BookingDetailDriverService>().LogError("Error: Booking detail null -> cannot set complete or send signal");

            return await UnitOfWork.BookingDetailDrivers.Update(bookingDetailDriver);
        }
    }
}
