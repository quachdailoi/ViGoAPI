using API.Models;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IPromotionService
    {
        Task<Response> GetAvailablePromotion(int userId, Response successResponse, Response emptyResponse);
        Task<Response> GetAvailablePromotion(int userId, double? totalPrice, int? totalTickets, Response successResponse, Response emptyResponse);
        Task<Promotion?> GetByCode(string code);
    }
}
