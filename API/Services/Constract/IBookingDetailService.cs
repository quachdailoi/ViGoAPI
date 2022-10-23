using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IBookingDetailService
    {
        List<BookingDetail> GenerateBookingDetail(Booking booking, double feePerTrip);
        Task<Response> GetNextBookingDetail(int userId, Response successResponse);
        Task<Response> GetOnGoing(int userId, DateFilterRequest dateFilterRequest, PagingRequest pagingRequest, Response successResponse);
        Task<Response> GetHistory(int userId, DateFilterRequest dateFilterRequest, PagingRequest pagingRequest, Response successResponse);

        Task<Response> GetBookingsOfDriver(int driverId, PagingRequest pagingRequest, DateFilterRequest dateFilterRequest, Response success);
        Task<BookingDetail?> GetBookingDetailOfBookerByCode(string code, int bookerId);
        Task<Response> GetAll(int userId, Response successResponse);
        Task<BookingDetail?> GetById(int id);

        Task<bool> UpdateBookingDetail(BookingDetail bookingDetail);
        Task SetCompletedBookingDetail();
    }
}
