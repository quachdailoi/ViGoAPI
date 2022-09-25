using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : BaseController<VehiclesController>
    {
        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            var response = await AppServices.V
        }
    }
}
