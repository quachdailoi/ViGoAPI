using Domain.Entities;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IEventService
    {
        Task<Event?> GetById(Events.Types id);
    }
}
