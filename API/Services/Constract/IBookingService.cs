﻿using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IBookingService
    {
        Task<Response> Create(
            BookingDTO dto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response invalidStationResponse,
            Response invalidVehicleTypeResponse, Response invalidRouteResponse, Response duplicationResponse, Response invalidPromotionResponse, 
            Response notAvailableResponse, Response insufficientBalanceResponse, Response errorResponse, bool isDummy = false, int ? routeRoutineId = null);
        Task<Response> GetProvision(
            BookingDTO dto, Response successResponse, Response invalidStationResponse, Response invalidRouteResponse, 
            Response invalidVehicleTypeResponse, Response invalidPromotionResponse);
        Task<Response> Get(int userId, GetBookingRequest request, Response successReponse);
        Task<bool> Update(Booking booking);
        Task<Booking?> GetByCode(Guid code);
        Task<Booking?> MappingBooking(int bookingId, int? specificRouteRoutineId = null);
        Task<RouteRoutine?> MappingRouteRoutine(int routeRoutineId);
        Task<BookingDetail?> MappingBookingDetail(int bookingDetailId);
        Task<BookingDetail?> MappingBookingDetailSuddenly(Guid code);
        Task<bool> CheckIsConflictBooking(Booking booking);
        Task<bool?> Refund(Guid code);
        Task<Response> Cancel(Guid code, Response successResponse, Response notExistReponse, Response notAllowResponse, Response failResponse);
        Task MappingRouteRoutineAfterCancelBooking(int bookingId);
    }
}
