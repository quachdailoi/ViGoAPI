using API.Extensions;
using API.Services.Constract;
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
            return await UnitOfWork.BookingDetailDrivers.List(x => x.Code.ToString() == code).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateTripStatus(BookingDetailDriver bookingDetailDriver, BookingDetailDrivers.TripStatus tripStatus)
        {
            bookingDetailDriver.TripStatus = tripStatus;

            switch (tripStatus)
            {
                case BookingDetailDrivers.TripStatus.PickingUp:
                    bookingDetailDriver.TripStatus = BookingDetailDrivers.TripStatus.PickingUp;
                    break;
                case BookingDetailDrivers.TripStatus.Completed:
                    bookingDetailDriver.TripStatus = BookingDetailDrivers.TripStatus.Completed;
                    break;
                default:
                    break;
            }

            var bookingDetail = await AppServices.BookingDetail.GetById(bookingDetailDriver.BookingDetailId);

            if(bookingDetail != null)
            {
                await AppServices.SignalR.SendToUserAsync(bookingDetail.Booking.User.Code.ToString(), "TripStatus", new
                {
                    BookingDetailCode = bookingDetail.Code,
                    TripStatus = tripStatus,
                    TripStatusName = tripStatus.DisplayName()
                });
            }

            return await UnitOfWork.BookingDetailDrivers.Update(bookingDetailDriver);
        }
    }
}
