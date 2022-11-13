using API.Models;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IBookingDetailService
    {
        List<BookingDetail> GenerateBookingDetail(Booking booking, FeeViewModel feePerTrip);
        Task<Response> GetNextBookingDetail(int userId, Response successResponse);
        Task<Response> GetOnGoing(int userId, DateFilterRequest dateFilterRequest, PagingRequest pagingRequest, BookingDetails.Status? status, Response successResponse, Response invalidStatusResponse);
        Task<Response> GetHistory(int userId, DateFilterRequest dateFilterRequest, PagingRequest pagingRequest, BookingDetails.Status? status, Response successResponse, Response invalidStatusResponse);

        Task<Response> GetBookingsOfDriver(int driverId, PagingRequest pagingRequest, DateFilterRequest dateFilterRequest, Response success);
        Task<BookingDetail?> GetBookingDetailOfBookerByCode(string code, int bookerId);
        Task<Response> GetAll(int userId, Response successResponse);
        Task<BookingDetail?> GetById(int id);

        Task<bool> UpdateBookingDetail(BookingDetail bookingDetail);
        Task<bool?> Refund(Guid code, double amount, BookingDetails.RefundTypes refundType = BookingDetails.RefundTypes.SharingTrip);
        Task SetCompletedBookingDetail();
        Task CheckingMappingStatus();
        Task CheckingExistTripInDay();
        BookingDetailDriver? GetBookingDetailDriverOfBookingDetail(string bookingDetailCode);
    }
}
