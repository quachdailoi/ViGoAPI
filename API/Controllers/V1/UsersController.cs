using API.Models.Requests;
using API.Services;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class UsersController : BaseController<UsersController>
    {
        [HttpPost("profile")]
        public async Task<IActionResult> GetProfile([FromBody] FCMTokenRequest? request)
        {
            var userVM = LoggedInUser;

            var user = AppServices.User.GetUserById(userVM.Id).FirstOrDefault();

            user.FCMToken = request?.FCMToken;

            var rs = await AppServices.User.UpdateUser(user);
            if (!rs) Logger.LogError("Update FCM Token fail.");

            var profileResponse =
                await AppServices.Account.GetProfile(
                    userVM.Id,
                    successResponse: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Get user's profile successfully."
                    }
                );

            return ApiResult(profileResponse);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var user = AppServices.User.GetUserById(LoggedInUser.Id).FirstOrDefault();

            user.FCMToken = null;

            var rs = await AppServices.User.UpdateUser(user);

            if (rs) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "You logout successfully."
            });

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "You logout failed."
            });
        }
    }
}
