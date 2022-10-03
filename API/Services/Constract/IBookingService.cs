using API.Models.DTO;
using API.Models.Response;
using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IBookingService
    {
        Task<Response> Create(BookingDTO dto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response invalidRouteResponse, Response duplicationResponse, Response invalidPromotionResponse, Response notAvailableResponse, Response errorReponse);
        Task<Response> GetProvision(BookingDTO dto, Response successResponse, Response invalidRouteResponse, Response invalidPromotionResponse);
        Task<Response> GetAll(int userId, Response successReponse);
        Task<bool> Update(Booking booking);
        Task<Booking?> GetByCode(Guid code);
        Task<bool> Mapping(Booking booking);
    }
}
