using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;

namespace API.Services
{
    public class RouteStationService : IRouteStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RouteStationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<RouteStation>> Create(List<RouteStation> routeStations)
        {
            return _unitOfWork.RouteStations.Add(routeStations);
        }
    }
}
