using API.Models;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IPromotionService
    {
        Task<Response> GetAvailablePromotion(int userId, Response successResponse, Response emptyResponse);
    }
}
