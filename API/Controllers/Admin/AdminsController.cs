using API.Helpers.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    [Route("api/[controller]")]
    [CustomAuthorize("ADMIN")]
    [ApiController]
    public class AdminsController : ControllerBase
    {

    }
}
