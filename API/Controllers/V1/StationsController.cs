using API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StationsController : BaseController<StationsController>
    {
        [HttpGet("nearby")]
        public async Task<IActionResult> GetStationNearby([FromQuery] CoordinatesDTO request)
        {
            var stationResponse = 
                await AppServices.Station.GetNearByStationsByCoordinates(
                    request,
                    success: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Load nearby station successfully."
                    },
                    failed: new()
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = "Load nearby station failed."
                    }
                );

            return ApiResult(stationResponse);
        }
    }
}
