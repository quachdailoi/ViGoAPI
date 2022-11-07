using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IBookingDetailDriverService
    {
        Task<List<BookingDetailDriver>> Create(List<BookingDetailDriver> bookingDetailDrivers);

        Task<bool> UpdateTripStatus(BookingDetailDriver bookingDetailDriver, BookingDetailDrivers.TripStatus tripStatus);

        Task<BookingDetailDriver?> GetBookingDetailDriverByCode(string code);

        Task<bool> StartBookingDetailDrivers(string[] codes);
        Task<bool?> CancelBookingDetailDrivers(string[] codes, string reason);
        List<User> GetUsers(string[] codes);
    }
}
