using API.JwtFeatures;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AuthController<T> : ControllerBase where T : AuthController<T>
    {
        private IAppServices _appServices;
        private ILogger<T> _logger;

        protected ILogger<T> Logger => _logger ?? (_logger = HttpContext?.RequestServices.GetService<ILogger<T>>());
        protected IAppServices AppServices => _appServices ?? (_appServices = HttpContext.RequestServices.GetRequiredService<IAppServices>());

        public abstract Task<IActionResult> SendPhoneLoginOtp([FromBody] SendPhoneOtpRequest request);
        public abstract Task<IActionResult> SendGmailOtp();

    }
}
