using API.Services.Constract;
using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class EventService : BaseService, IEventService
    {
        public EventService(IAppServices appServices) : base(appServices)
        {
        }

        public Task<Event?> GetById(Events.Types id)
        {
            return UnitOfWork.Events.List(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
