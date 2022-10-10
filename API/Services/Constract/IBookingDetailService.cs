using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IBookingDetailService
    {
        List<BookingDetail> GenerateBookingDetail(Booking booking, double feePerTrip);
        Task<Response> GetNextBookingDetail(int userId, Response successResponse);

        Task<Response> GetBookingsOfDriver(int driverId, Response success, PagingRequest? request = null);
    }
}
