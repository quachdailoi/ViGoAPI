﻿using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IBookingDetailService
    {
        List<BookingDetail> GenerateBookingDetail(Booking booking);
        Task<Response> GetNextBookingDetail(int userId, Response successResponse);

        Task<Response> GetBookingsOfDriver(int driverId, PagingRequest pagingRequest, DateFilterRequest dateFilterRequest, Response success);
    }
}
