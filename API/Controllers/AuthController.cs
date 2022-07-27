using API.Models.Requests;
using API.Services.Constract;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

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
        public abstract IActionResult SendGmailOtp([FromBody] SendGmailOtpRequest request);
    }
}
