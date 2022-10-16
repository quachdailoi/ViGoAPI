using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IBookingDetailService
    {
        List<BookingDetail> GenerateBookingDetail(Booking booking, double feePerTrip);
        Task<Response> GetNextBookingDetail(int userId, Response successResponse);
        Task<Response> Get(int userId, Response successResponse, PagingRequest? pagingRequest = null, DateFilterRequest? dateFilterRequest = null);

        Task<Response> GetBookingsOfDriver(int driverId, PagingRequest pagingRequest, DateFilterRequest dateFilterRequest, Response success);
    }
}
