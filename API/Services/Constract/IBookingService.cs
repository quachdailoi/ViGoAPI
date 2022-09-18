using API.Models.DTO;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IBookingService
    {
        Task<Response> Create(BookingDTO dto, Response successResponse, Response duplicationResponse, Response invalidResponse, Response errorReponse);
        Task<Response> GetAll(int userId, Response successReponse);
    }
}
