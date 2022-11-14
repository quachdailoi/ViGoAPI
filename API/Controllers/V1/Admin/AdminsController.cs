using API.Extensions;
using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Settings;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1.Admin
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AdminsController : BaseController<AdminsController>
    {
        private readonly IJwtHandler _jwtHandler;

        public AdminsController(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        /// <summary>
        ///     Login by admin gmail.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/admins/gmail/login
        ///     {
        ///         "IdToken": "..."
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Login successfully.</response>
        /// <response code = "400"> 
        ///     Login failed - Something went wrong. <br></br>
        ///     Not found email of admin account in our system.
        /// </response>
        [MapToApiVersion("1.0")]
        [HttpPost("gmail/login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailRequest request)
        {
            var authWithFireBaseResponse = await AppServices.User.GetEmailWithFireBaseAuthAsync(request);

            if (!authWithFireBaseResponse.Success) return ApiResult(authWithFireBaseResponse);

            var gmail = (string?)authWithFireBaseResponse.Data;

            if (string.IsNullOrEmpty(gmail)) throw new UnauthorizedAccessException();

            var user = await AppServices.Admin.GetUserViewModel(gmail, RegistrationTypes.Gmail);

            if (user == null)
            {
                return ApiResult(new()
                {
                    Message = "Not found email of admin account in our system.",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            string token = _jwtHandler.GenerateToken(user);
            string refreshToken = await _jwtHandler.GenerateRefreshToken(user.Code.ToString());

            return ApiResult(new()
            {
                Message = "Login successfully.",
                StatusCode = StatusCodes.Status200OK,
                Data = new LoginSuccessViewModel
                {
                    AccessToken = token,
                    AccessTokenExpiredTime = DateTimeOffset.Now.AddMinutes(Configuration.Get<double>(JwtSettings.AccessTokenTTLMinutes)),
                    RefreshToken = refreshToken,
                    RefreshTokenExpiredTime = DateTimeOffset.Now.AddDays(Configuration.Get<double>(JwtSettings.RefreshTokenTTLDays)),
                    User = user
                }
            });
        }

        [HttpGet("finance")]
        public async Task<IActionResult> GetFinance([FromQuery] DateFilterRequest request)
        {
            var finance = await AppServices.Wallet.GetFinance(request);

            return ApiResult(new Response
            {
                Data = finance,
                Message = "Get finance information successfully.",
                StatusCode = StatusCodes.Status200OK
            });
        }

        [HttpGet("test")]
        public IActionResult TestAuthen()
        {
            var user = LoggedInUser;
            return Ok(user);
        }
    }
}
