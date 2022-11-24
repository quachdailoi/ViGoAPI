using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IBookingDetailDriverService
    {
        Task<List<BookingDetailDriver>> Create(List<BookingDetailDriver> bookingDetailDrivers);

        Task<bool> UpdateTripStatus(BookingDetailDriver bookingDetailDriver, BookingDetailDrivers.TripStatus tripStatus, double? latitude, double? longitude);

        Task<BookingDetailDriver?> GetBookingDetailDriverByCode(string code);

        Task<bool> StartBookingDetailDrivers(string[] codes);
        Task<Response> CancelBookingDetailDrivers(string[] codes, string reason, Response invalidAllowedTimeResponse,
            Response invalidBookingDetailDriverResponse, Response successResponse, Response failResponse);
        List<User> GetUsers(string[] codes);
        Task<List<int>> GetNotYetBookingDetailId(int driverId);
    }
}
