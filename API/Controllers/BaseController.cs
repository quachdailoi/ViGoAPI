using API.Models;
using API.Models.Response;
using API.Services.Constract;
using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        private IAppServices? _appServices;
        private ILogger<T>? _logger;
        private IHttpContextAccessor? _httpContextAccessor;
        private IConfiguration? _config;

        protected ILogger<T> Logger => _logger ?? (_logger = HttpContext.RequestServices.GetRequiredService<ILogger<T>>());
        protected IAppServices AppServices => _appServices ?? (_appServices = HttpContext.RequestServices.GetRequiredService<IAppServices>());
        protected IHttpContextAccessor HttpContextAccessor => _httpContextAccessor ?? (_httpContextAccessor = HttpContext.RequestServices.GetRequiredService<IHttpContextAccessor>());
        protected IConfiguration Configuration => _config ?? (_config = HttpContext.RequestServices.GetRequiredService<IConfiguration>());

        protected UserViewModel? LoggedInUser => ((UserViewModel?)(HttpContextAccessor.HttpContext?.Items["User"]));

        protected Response? CheckLoggedInUserToGetAccount(RegistrationTypes accountType, out UserViewModel? loggedInUser, out Account? account)
        {
            loggedInUser = LoggedInUser;
            account = default(Account);

            if (loggedInUser == null)
                return new(
                    StatusCode: StatusCodes.Status401Unauthorized,
                    Message: "Please login again for this action."
                );

            account = AppServices.Account.GetAccountByUserCode(loggedInUser.Code.ToString(), accountType)?.FirstOrDefault();

            if (account == null)
            {
                return new(
                    StatusCode: StatusCodes.Status500InternalServerError,
                    Message: "Server error - Please try later."
                );
            };

            return null;
        }

        protected Response CheckRequest(object request)
        {
            Response response = new();

            if (request is null)
            {
                response
                    .SetStatusCode(StatusCodes.Status400BadRequest)
                    .SetMessage("Invalid client request");
                return response;
            }
            return response;
        }

        protected IActionResult ApiResult(Response response)
        {
            return StatusCode(response.StatusCode, response);
        }

        protected string? IpAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}
