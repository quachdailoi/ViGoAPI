using API.JwtFeatures;
using API.Models.Requests;
using API.Models.Response;
using API.Quartz;
using API.Quartz.Jobs;
using API.Services.Constract;
using API.SignalR.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<AccountsController>
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly ISignalRService _signalRService;
        private readonly IJobScheduler _jobScheduler;

        public AccountsController(IJwtHandler jwtHandler, ISignalRService signalRService, IJobScheduler jobScheduler)
        {
            _jwtHandler = jwtHandler;
            _signalRService = signalRService;
            _jobScheduler = jobScheduler;
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var response = CheckRequest(request);

            string accessToken = request.AccessToken;
            string refreshToken = request.RefreshToken;

            try
            {
                var isRevokedToken = await AppServices.Token.IsRevokedRefreshTokenAsync(refreshToken);
                if (isRevokedToken)
                    throw new SecurityTokenExpiredException();

                // generate new access token
                var userViewModel = await _jwtHandler.GetUserViewModelByToken(accessToken);

                if (userViewModel == null)
                {
                    throw new SecurityTokenException();
                }
                // check exist refresh token with user code
                var userCodeFromRefreshToken = await AppServices.Token.ValueOfActiveRefreshToken(refreshToken);
                if (userCodeFromRefreshToken != userViewModel.Code.ToString())
                    throw new SecurityTokenExpiredException();

                var newAccessToken = _jwtHandler.GenerateToken(userViewModel);

                // replace old refresh token with a new one (rotate token)
                var newRefreshToken = await RotateRefreshToken(refreshToken, userViewModel.Code.ToString());

                response = new(
                        StatusCode: StatusCodes.Status200OK,
                        Message: "Refresh token successfully",
                        Data: new
                        {
                            token = newAccessToken,
                            refreshToken = newRefreshToken
                        }
                    );
                return Ok(response);
            }
            catch (SecurityTokenExpiredException)
            {
                response = new(
                    StatusCode: StatusCodes.Status401Unauthorized,
                    Message: "Refresh token is expired or invalid"
                );
                return BadRequest(response);
            }
            catch (SecurityTokenException)
            {
                response = new(
                    StatusCode: StatusCodes.Status400BadRequest,
                    Message: "Expired Access Token is invalid"
                );
                return BadRequest(response);
            }
        }

        private async void RevokeRefreshToken(string token)
        {
            await AppServices.Token.RevokeRefreshTokenAsync(token);
        }

        private async Task<string> RotateRefreshToken(string refreshToken, string userCode)
        {
            var newRefreshToken = await _jwtHandler.GenerateRefreshToken(userCode);
            RevokeRefreshToken(refreshToken);
            return newRefreshToken;
        }

        [HttpPost("revoke-token/token")]
        public async Task<IActionResult> RevokeToken([FromQuery] string token)
        {
            await AppServices.Token.RevokeRefreshTokenAsync(token);

            return Ok(new Response(StatusCode: 200, Message: "Token revoked successfully."));
        }

        ///// <summary>
        ///// Test api - Send message to specific user every minute starting at 5:10 PM and ending at 5:15 PM, every day
        ///// </summary>
        ///// /// <remarks>Cron job</remarks>
        ///// <param name="request" example="{Message: 'Cron job is excuting...' ,UserCode: '613de7b4-db59-4a6c-b9a1-2b1e176460d3'}">Message schema</param>
        ///// <response code="200">Job is excuting...</response>
        ///// <response code="500">Failure</response>
        //[HttpPost("test/cron-job/send-to-user")]
        //public async Task<IActionResult> StartMessageJob([FromBody] MessageRequest request)
        //{
        //    await _jobScheduler.StartMessageJob<MessageJob>(request.UserCode, request.Message, "0 10-15 17 * * ?");
        //    // Fire every minute starting at 5:10 PM and ending at 5:15 PM, every day
        //    return Ok();
        //}

        ///// <summary>
        ///// Test api - Send message to specific user
        ///// </summary>
        ///// /// <remarks>Websocket</remarks>
        ///// <param name="request" example="{Message: 'Hello world!' ,UserCode: '613de7b4-db59-4a6c-b9a1-2b1e176460d3'}">Message schema</param>
        ///// <response code="200">Send successfully</response>
        ///// <response code="500">Failure</response>
        //[HttpPost("test/websocket/send-to-user")]
        //public async Task<IActionResult> SendToUser([FromBody] MessageRequest request)
        //{
        //    await _signalRService.SendToUserAsync(request.UserCode, "Message", request.Message);
        //    return Ok();
        //}

        /// <summary>
        /// Test api - Send message to specific room
        /// </summary>
        /// /// <remarks>Websocket - signal info: method(Message) -  json {roomId , {MessageViewModel}}</remarks>
        /// <param name="request" example="{Content: 'Hello world!' ,RoomCode: '613de7b4-db59-4a6c-b9a1-2b1e176460d3'}">Message schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost("message/send-message")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            var room = await AppServices.Room.GetViewModelByCode(request.RoomCode);
            var message = await AppServices.Message.Create(request.Content, room.Id, this.LoginedUser.Id);

            var respone = new Response
            {
                Data = message,
                Message = "Send message successfully",
                StatusCode = StatusCodes.Status200OK
            };

            var userCodes = room.Users.Select(user => user.Code.ToString()).ToList();

            await _signalRService.SendToUsersAsync(
                userCodes, 
                "Message", 
                new {
                    roomId = room.Id,
                    message
            });
            return new JsonResult(respone);
        }

        /// <summary>
        /// Test api - Get message room by partner's code
        /// </summary>
        /// /// <remarks>Get message room</remarks>
        /// <param name="userCodes" example="['613de7b4-db59-4a6c-b9a1-2b1e176460d3']">Message schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpGet("message/room/by-partner-codes")]
        public async Task<IActionResult> GetMessageRoomByUserCode([FromQuery] List<Guid> userCodes)
        {
            var user = this.LoginedUser;

            userCodes.Add(user.Code);

            var roomCode = await AppServices.UserRoom.GetRoomCodeByMemberCode(userCodes);
            var room = await AppServices.Room.GetViewModelByCode(roomCode);

            var respone = new Response
            {
                Data = room,
                Message = "Send message successfully",
                StatusCode = StatusCodes.Status200OK
            };
            return new JsonResult(respone);
        }

        /// <summary>
        /// Test api - Get message room by partner's code
        /// </summary>
        /// /// <remarks>Get message room</remarks>
        /// <param name="roomCode" example="'613de7b4-db59-4a6c-b9a1-2b1e176460d3'">Message schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [HttpGet("message/room/by-code")]
        public async Task<IActionResult> GetMessageRoomByCode(Guid roomCode)
        {
            var room = await AppServices.Room.GetViewModelByCode(roomCode);

            var respone = new Response
            {
                Data = room,
                Message = "Send message successfully",
                StatusCode = StatusCodes.Status200OK
            };
            return new JsonResult(respone);
        }

        /// <summary>
        /// Test api - Create message room with specific partners's code
        /// </summary>
        /// /// <remarks>Create message room</remarks>
        /// <param name="request" example="['613de7b4-db59-4a6c-b9a1-2b1e176460d3']">Message schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost("message/room")]
        public async Task<IActionResult> CreateMessageRoom([FromBody] MessageRoomRequest request)
        {
            var room = await AppServices.Room.Create(MessageRoomTypes.Conversation);

            var users = await AppServices.User.GetUsersByCode(request.PartnerUserCodes);

            var userIds = users.Select(user => user.Id).ToList();

            userIds.Add(this.LoginedUser.Id);

            var userRoom = await AppServices.UserRoom.Create(room.Id, userIds);

            var respone = new Response
            {
                Data = room,
                Message = "Send message successfully",
                StatusCode = StatusCodes.Status200OK
            };
            return new JsonResult(respone);
        }
    }
    //public class MessageRequest
    //{
    //    public string Message { get; set; }
    //    public string UserCode { get; set; }
    //}

}
