using API.Models;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IMessageService
    {
        Task<Message> Create(string content, int roomId, int userId);
        MessageViewModel GetViewModel(Message message);
    }
}
