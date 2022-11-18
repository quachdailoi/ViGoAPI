using Domain.Entities;

namespace API.Services.Constract
{
    public interface IVehicleService
    {
        IQueryable<Vehicle> GetVehicleByLicensePlate(string licensePlate);
    }
}
