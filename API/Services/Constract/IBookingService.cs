using API.Models.DTO;
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
            Response notAvailableResponse, Response insufficientBalanceResponse, Response errorResponse, bool isDummy = false);
        Task<Response> GetProvision(
            BookingDTO dto, Response successResponse, Response invalidStationResponse, Response invalidRouteResponse, 
            Response invalidVehicleTypeResponse, Response invalidPromotionResponse);
        Task<Response> Get(int userId, GetBookingRequest request, Response successReponse);
        Task<bool> Update(Booking booking);
        Task<Booking?> GetByCode(Guid code);
        Task<Booking?> MappingBooking(int bookingId);
        Task<RouteRoutine?> MappingRouteRoutine(int routeRoutineId);
        Task<bool> CheckIsConflictBooking(Booking booking);
        Task<bool?> Refund(Guid code);
    }
}
