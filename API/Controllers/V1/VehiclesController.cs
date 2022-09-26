using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VehiclesController : BaseController<VehiclesController>
    {
        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            var response =
                await AppServices.VehicleType
                .GetAll(successResponse: new()
                {
                    Message = "Get vehicle types successfully.",
                    StatusCode = StatusCodes.Status200OK
                });

            return ApiResult(response);
        }
    }
}
