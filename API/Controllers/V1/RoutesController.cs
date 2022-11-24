using API.Models.DTO;
using API.Models.Requests;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RoutesController : BaseController<RoutesController>
    {
        /// <summary>
        /// Get all available routes
        /// </summary>
        /// <response code="200">Get routes successfully</response>
        /// <response code="500">Fail to get routes</response>
        [HttpGet]
        //[Authorize(Roles = "DRIVER,ADMIN")]
        public async Task<IActionResult> GetRoutes([FromQuery] StartStationRequest request)
        {
            var response = await AppServices.Route.GetAll(
                                    request,
                                    successResponse: new()
                                    {
                                        Message = "Get routes successfully.",
                                        StatusCode = StatusCodes.Status200OK
                                    });

            return ApiResult(response);
        }

        /// <summary>
        /// Create route from list of stations.
        /// </summary>
        /// <response code="200">Get routes successfully</response>
        /// <response code="500">Fail to get routes</response>
        /// 
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> CreateRoute([FromBody] CreateRouteRequest request)
        {
            var admin = LoggedInUser;
            //if (stationCodes.Distinct().Count() != stationCodes.Count())
            //{
            //    return ApiResult(new()
            //    {
            //        StatusCode = StatusCodes.Status400BadRequest,
            //        Message = "List of station codes must have unique values."
            //    });
            //}

            var createRouteResponse =
                await AppServices.RapidApi.CreateRoute(
                    adminId: admin.Id,
                    request,
                    success: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Create route successfully."
                    },
                    failed: new()
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = "Create route failed."
                    }
                );

            return Ok(createRouteResponse);
        }

        /// <summary>
        /// Update route from list of stations.
        /// </summary>
        /// <response code="200">Get routes successfully</response>
        /// <response code="500">Fail to get routes</response>
        /// 
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateRoute([FromBody] UpdateRouteRequest request)
        {
            var stationCodes = request.StationCodes;

            var notExistStationCode = await AppServices.Station.NotExistedRouteCode(stationCodes);

            if (notExistStationCode != null) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = $"List of stations contains station code {notExistStationCode} does not belong to any station."
            });

            var route = await AppServices.Route.GetRouteByCode(request.RouteCode);
            route.Name = request.RouteName;

            if (route == null) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Not found any route with this code."
            });

            var routeWasBooked = AppServices.Route.CheckRouteWasBooked(route.Id);

            if (routeWasBooked) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "This route was booked by passenger, cannot update."
            });

            var stationDtos = await AppServices.Station.GetStationDTOsByCodes(stationCodes);

            var newRoute = await AppServices.Route.UpdateRoute(route, stationDtos);

            if (newRoute == null) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Failed to update route."
            });

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Update route successfully.",
                Data = newRoute
            });
        }

        /// <summary>
        /// Delete route from list of stations.
        /// </summary>
        /// <response code="200">Get routes successfully</response>
        /// <response code="500">Fail to get routes</response>
        /// 
        [HttpDelete("{code}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteRoute(string code)
        {
            var route = await AppServices.Route.GetRouteByCode(code);

            if (route == null) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Not found any route with this code."
            });

            var routeWasBooked = AppServices.Route.CheckRouteWasBooked(route.Id);

            if (routeWasBooked) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "This route was booked by passenger, cannot delete."
            });

            route.UpdatedBy = LoggedInUser.Id;

            var rs = await AppServices.Route.DeleteRoute(route);

            if (!rs) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Failed to delete route."
            });

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Deleted route successfully."
            });
        }

        /// <summary>
        /// Create route from list of stations.
        /// </summary>
        /// <response code="200">Get routes successfully</response>
        /// <response code="500">Fail to get routes</response>
        /// 
        [HttpPost("dump")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DumpRoutes(int routeNumber)
        {
            var dumpsId = Utils.DumpRoutes.GetListStationIdsToDumpRoutes()[routeNumber - 1];

            Console.WriteLine($"{DateTimeOffset.Now} - Start creating.");
            var stationDtos = await AppServices.Station.GetStationDTOsByIds(dumpsId);
            var newRoute = AppServices.RapidApi.CreateRouteByListOfStation(stationDtos, 9);
            Console.WriteLine($"{DateTimeOffset.Now} - End creating.");
            
            return Ok(newRoute);
        }
    }
}
