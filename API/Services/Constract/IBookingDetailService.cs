using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IBookingDetailService
    {
        List<BookingDetail> GenerateBookingDetail(Booking booking);
        Task<Response> GetNextBookingDetail(int userId, Response successResponse, Response notFoundResponse);
    }
}
