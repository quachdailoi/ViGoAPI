using API.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BannersController : BaseController<BannersController>
    {
        [HttpGet]
        public async Task<IActionResult> GetHomeBanners()
        {
            var response =
                await AppServices.Banner.GetHomeBanners(
                    succeess: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Get home banners succeefully."
                    }
                );

            return ApiResult(response);
        }       
    }
}
