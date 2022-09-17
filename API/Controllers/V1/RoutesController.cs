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
        [Authorize(Roles = "DRIVER,ADMIN")]
        public async Task<IActionResult> GetRoutes()
        {
            var response = await AppServices.Route.GetAll(
                                    successResponse: new()
                                    {
                                        Message = "Get routes successfully.",
                                        StatusCode = StatusCodes.Status200OK
                                    });

            return ApiResult(response);
        }
    }
}
