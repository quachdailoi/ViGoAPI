using API.Models.Response;

namespace API.Services.Constract
{
    public interface IVehicleTypeService
    {
        Task<Response> GetAll(Response successResponse);
    }
}
