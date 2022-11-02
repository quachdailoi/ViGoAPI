using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class VehiclesController : BaseController<VehiclesController>
    {
        /// <summary>
        ///     Get all vehicle types
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/vehicles/types 
        /// ```
        /// </remarks>
        /// <response code = "200"> Get vehicle types successfully.</response>
        [HttpGet("types")]
        [Authorize]
        public async Task<IActionResult> GetTypes()
        {
            var response =
                await AppServices.VehicleType
                .Get(successResponse: new()
                {
                    Message = "Get vehicle types successfully.",
                    StatusCode = StatusCodes.Status200OK
                });

            return ApiResult(response);
        }

        /// <summary>
        ///     Get all fare belong to vehicle types
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/vehicles/types/fare 
        /// ```
        /// </remarks>
        /// <response code = "200"> Get vehicle types with fare successfully.</response>
        [HttpGet("types/fare")]
        [Authorize]
        public async Task<IActionResult> GetTypesWithFare()
        {
            var response =
                await AppServices.VehicleType
                .GetWithFare(successResponse: new()
                {
                    Message = "Get vehicle types with fare successfully.",
                    StatusCode = StatusCodes.Status200OK
                });

            return ApiResult(response);
        }
    }
}
