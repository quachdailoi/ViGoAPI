using API.Services.Constract;
using Domain.Entities;

namespace API.Services
{
    public class VehicleService : BaseService, IVehicleService
    {
        public VehicleService(IAppServices appServices) : base(appServices)
        {
        }

        public IQueryable<Vehicle> GetVehicleByLicensePlate(string licensePlate)
        {
            return UnitOfWork.Vehicles.List(x => x.LicensePlate == licensePlate);
        }
    }
}
