using API.Models.DTO;
using API.Models.Requests;
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
        public async Task<IActionResult> CreateRoute([FromBody] CreateRouteRequest request)
        {
            var stationCodes = request.StationCodes;

            if (stationCodes.Distinct().Count() != stationCodes.Count())
            {
                return ApiResult(new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "List of station codes must have unique values."
                });
            }

            var stationDtos = await AppServices.Station.GetStationDTOsByCodes(stationCodes);

            var createRouteResponse = 
                await AppServices.RapidApi.CreateRoute(
                    stationDtos,
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
        /// Create route from list of stations.
        /// </summary>
        /// <response code="200">Get routes successfully</response>
        /// <response code="500">Fail to get routes</response>
        /// 
        [HttpPost("dump")]
        public async Task<IActionResult> DumpRoutes(int routeNumber)
        {
            var dumpsId = Utils.DumpRoutes.GetListStationIdsToDumpRoutes()[routeNumber - 1];

            Console.WriteLine($"{DateTimeOffset.Now} - Start creating.");
            var stationDtos = await AppServices.Station.GetStationDTOsByIds(dumpsId);
            var newRoute = await AppServices.RapidApi.CreateRoute(stationDtos, new(), new());
            Console.WriteLine($"{DateTimeOffset.Now} - End creating.");
            
            return Ok(newRoute);
        }
    }
}
