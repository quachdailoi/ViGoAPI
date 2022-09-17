using API.Models.DTO;
using API.Models.Response;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IStationService
    {
        Task<Response> GetNearByStationsByCoordinates(CoordinatesDTO coordinates, Response success, Response failed);
    }
}
