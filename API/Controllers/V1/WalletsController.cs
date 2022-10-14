using API.Models.Requests;
using API.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    public class WalletsController : BaseController<WalletsController>
    {
        [HttpPut("top-up")]
        public async Task<IActionResult> TopUpWallet([FromBody] WalletTopUpRequest request)
        {
            var response = new Response();
            return ApiResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetWallet()
        {
            var response = new Response();
            return ApiResult(response);
        }
    }
}
