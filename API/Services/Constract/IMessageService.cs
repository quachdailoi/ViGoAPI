using API.Models;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IMessageService
    {
        Task<MessageViewModel> Create(string content, int roomId, int userId);
    }
}
