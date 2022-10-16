using API.Services.Constract;

namespace API.Services
{
    public class VehicleService : BaseService, IVehicleService
    {
        public VehicleService(IAppServices appServices) : base(appServices)
        {
        }
    }
}
