using API.Models;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IMessageService
    {
        Task<Response> Create(string content, Guid roomCode, int userId, Response successResponse, Response errorResponse);
        MessageViewModel GetViewModel(Message message);
    }
}
