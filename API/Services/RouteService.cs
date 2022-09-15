using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RouteService : IRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RouteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<Domain.Entities.Route>> Create(List<Domain.Entities.Route> routes)
        {
            return _unitOfWork.Routes.Add(routes);
        }

        public async Task<Response> CreateRange(List<RouteDTO> routes, Response successResponse, Response dupplicateResponse, Response errorResponse)
        {
            var routeEntities = _mapper.Map<List<Domain.Entities.Route>>(routes);

            //check duplicate

            routeEntities = await Create(routeEntities);

            if(routeEntities == null) return errorResponse;

            return successResponse.SetData(routeEntities);
        }

        public async Task<Response> GetAll(Response successResponse)
        {
            //var _routes = await _unitOfWork.Routes.List(route => route.Status == StatusTypes.Route.Active).ToListAsync();
            var routes = await _unitOfWork.Routes.List(route => route.Status == StatusTypes.Route.Active).MapTo<RouteViewModel>(_mapper).ToListAsync();

            return successResponse.SetData(routes);
        }

        public Task<Response> GetSteps(Location startPoint, Location endPoint)
        {
            throw new NotImplementedException();
        }

        public Task<RouteViewModel> GetSteps(Station station, Location endPoint)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistData()
        {
            return _unitOfWork.Routes.List().AnyAsync();
        }
    }
}
