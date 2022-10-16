using API.Services.Constract;

namespace API.Services
{
    public class FareTimelineService : BaseService, IFareTimelineService
    {
        public FareTimelineService(IAppServices appServices) : base(appServices)
        {
        }
    }
}
