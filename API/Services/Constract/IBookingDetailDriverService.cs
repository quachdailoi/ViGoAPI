using Domain.Entities;

namespace API.Services.Constract
{
    public interface IBookingDetailDriverService
    {
        Task<List<BookingDetailDriver>> Create(List<BookingDetailDriver> bookingDetailDrivers);
    }
}
