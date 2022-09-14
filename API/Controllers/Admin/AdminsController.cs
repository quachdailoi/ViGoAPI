using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    [Route("api/[controller]")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    public class AdminsController : ControllerBase
    {

    }
}
