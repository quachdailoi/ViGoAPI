using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IVehicleTypeService
    {
        Task<Response> GetAll(Response successResponse);
        Task<VehicleType?> GetByCode(Guid Code);
        Task<List<VehicleType>> GetWithFare();
    }
}
