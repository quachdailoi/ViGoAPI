using API.JwtFeatures;
using API.Models.Requests;
using API.Models.Response;
using API.Quartz;
using API.Quartz.Jobs;
using API.SignalR;
using API.SignalR.Constract;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using Quartz;

namespace API.Controllers.Common
{
    [Route("api")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;
        private readonly ISignalRService _signalRService;
        private readonly IJobScheduler _jobScheduler;
        public CommonController(IJwtHandler jwtHandler, IMapper mapper, ISignalRService signalRService, IJobScheduler jobScheduler)
        {
            _jwtHandler = jwtHandler;
            _mapper = mapper;
            _signalRService = signalRService;
            _jobScheduler = jobScheduler;
        }

        [HttpPost("refresh-access-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            Response response = new();
            try
            {
                var tokenUser = await _jwtHandler.ValidateToken(request.Token, false);
                var refreshTokenUser = await _jwtHandler.ValidateToken(request.RefreshToken);
                if (tokenUser.Code == refreshTokenUser.Code)
                {
                    response = new(
                        StatusCode: StatusCodes.Status200OK,
                        Message: "Refresh token successfully",
                        Data: new
                        {
                            token = _jwtHandler.GenerateToken(tokenUser),
                            refreshToken = _jwtHandler.GenerateRefreshToken(refreshTokenUser)
                        }
                    );
                    return Ok(response);
                }
                else
                {
                    response = new(
                        StatusCode: StatusCodes.Status200OK,
                        Message: "Refresh token is invalid",
                        Data: new
                        {
                            token = _jwtHandler.GenerateToken(tokenUser),
                            refreshToken = _jwtHandler.GenerateRefreshToken(refreshTokenUser)
                        }
                    );
                    return BadRequest(response);
                }
            }
            catch (SecurityTokenExpiredException)
            {
                response = new(
                    StatusCode: StatusCodes.Status401Unauthorized,
                    Message: "Refresh token is expired"
                );
                return BadRequest(response);
            }
            catch (SecurityTokenException)
            {
                response = new(
                    StatusCode: StatusCodes.Status400BadRequest,
                    Message: "Token or Refresh token is invalid"
                );
                return BadRequest(response);
            }
        }

        // for test quartz
        [HttpPost("job/send-to-user")]
        public async Task<IActionResult> StartJob([FromBody] MessageRequest request)
        {
            await _jobScheduler.StartMessageJob<MessageJob>(request.UserCode, request.Message, "0 0-5 15 * * ?");
            // Fire every minute starting at 3:00 PM and ending at 3:05 PM, every day
            return Ok();
        }

        // for test signalr
        [HttpPost("hubs/send-to-user")]
        public async Task<IActionResult> SendToUser([FromBody] MessageRequest request)
        {
            await _signalRService.SendToUserAsync(request.UserCode, "Message", request.Message);
            return Ok();
        }
    }
    // for test signalr
    public class MessageRequest
    {
        public string Message { get; set; }
        public string UserCode { get; set; }
    }
}
