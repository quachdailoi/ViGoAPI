using API.Services.Constract;

namespace API.Services
{
    public class LocationService : BaseService, ILocationService
    {
        public LocationService(IAppServices appServices) : base(appServices)
        {
        }
    }
}
