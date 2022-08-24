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

        /// <summary>
        /// Create support room (pending...)
        /// </summary>
        /// /// <remarks>Websocket - signal info: method(Room) - obj(Room)</remarks>
        /// <response code="200">Create successfully</response>
        /// <response code="102">Waiting to connect with support staff</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost("message/create-support-room")]
        public async Task<IActionResult> CreateSupportMessageRoom()
        {
            // Find staff in queue 
            // [If found] create support room between client and staff
            //            send room in response
            //            send room via websocket staff
            //            dequeue staff then enqueue staff
            // [If not found] add to staff message job queue
            //                when exist staff in application, do job and send room to both staff and customer via websocket
            //                dequeue staff and enqueue staff
            return Ok();
        }

        /// <summary>
        /// Send message to specific room
        /// </summary>
        /// /// <remarks>Websocket - signal info: method(Message) -  json { RoomCode, Message }</remarks>
        /// <param name="request" example="{Content: 'Hello world!' ,RoomCode: '613de7b4-db59-4a6c-b9a1-2b1e176460d3'}">MessageRequest schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost("message/send-message")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            var room = await AppServices.Room.GetViewModelByCode(request.RoomCode);
            var message = await AppServices.Message.Create(request.Content, room.Id, this.LoginedUser.Id);
            var messageViewModel = AppServices.Message.GetViewModel(message);

            var respone = new Response
            {
                Data = messageViewModel,
                Message = "Send message successfully",
                StatusCode = StatusCodes.Status200OK
            };

            var roomMemebersCode = room.Users.Select(user => user.Code.ToString()).ToList();

            await _signalRService.SendToUsersAsync(
                roomMemebersCode, 
                "Message", 
                new { 
                    RoomCode = room.Code,
                    Message = messageViewModel
                });
            return new JsonResult(respone);
        }

        /// <summary>
        /// Mark read in specific room
        /// </summary>
        /// /// <remarks>Websocket - signal info: method(MarkRead) -  json {RoomCode , UserCode, LastSeenTime}</remarks>
        /// <param name="request" example="{Content: 'Hello world!' ,RoomCode: '613de7b4-db59-4a6c-b9a1-2b1e176460d3'}">LastSeenTimeMessageRequest schema</param>
        /// <response code="200">Mark read successfully</response>
        /// <response code="400">Fail to mark read</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost("message/mark-read-message")]
        public async Task<IActionResult> MarkReadMessage([FromBody] LastSeenTimeMessageRequest request)
        {
            var response = new Response();
            var user = this.LoginedUser;

            var room = await AppServices.Room.GetViewModelByCode(request.RoomCode);

            var lastSeenTime = await AppServices.UserRoom.UpdateLastSeenTime(user.Id, request.RoomCode);

            if (lastSeenTime == null)
            {
                response = new Response
                {
                    Message = "Fail to mark read, please try again",
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }

            response = new Response
            {
                Message = "Mark read successfully",
                StatusCode = StatusCodes.Status200OK
            };

            var roomMemebersCode = room.Users.Select(user => user.Code.ToString()).ToList();

            await _signalRService.SendToUsersAsync(
                roomMemebersCode, 
                "MarkRead", 
                new { 
                    RoomCode = request.RoomCode, 
                    UserCode = user.Code,
                    LastSeenTime = lastSeenTime
                });
            return new JsonResult(response);
        }

        /// <summary>
        /// Get message room by partner's code (optional)
        /// </summary>
        /// /// <remarks>Get message room</remarks>
        /// <param name="userCodes" example="['613de7b4-db59-4a6c-b9a1-2b1e176460d3']">Users Code</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpGet("message/room/by-partner-codes")]
        public IActionResult GetMessageRoomByUserCode([FromQuery] List<Guid> userCodes)
        {
            var user = this.LoginedUser;

            userCodes.Add(user.Code);

            //var roomCode = await AppServices.UserRoom.GetRoomCodeByMemberCode(userCodes);
            var room = AppServices.Room.GetViewModelByMemberCode(userCodes);

            var respone = new Response
            {
                Data = room,
                Message = "Send message successfully",
                StatusCode = StatusCodes.Status200OK
            };
            return new JsonResult(respone);
        }

        /// <summary>
        /// Get message room by code
        /// </summary>
        /// /// <remarks>Get message room</remarks>
        /// <param name="roomCode" example="613de7b4-db59-4a6c-b9a1-2b1e176460d3">Room Code</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [HttpGet("message/room/by-code")]
        public async Task<IActionResult> GetMessageRoomByCode(Guid roomCode)
        {
            var roomViewModel = await AppServices.Room.GetViewModelByCode(roomCode);

            var respone = new Response
            {
                Data = roomViewModel,
                Message = "Send message successfully",
                StatusCode = StatusCodes.Status200OK
            };
            return new JsonResult(respone);
        }

        /// <summary>
        /// Get support message room
        /// </summary>
        /// /// <remarks>Get support message room</remarks>
        /// <response code="200">Get successfully</response>
        /// <response code="500">Failure</response>
        [HttpGet("message/room/support-type")]
        public async Task<IActionResult> GetSupportMessageRoom()
        {
            var user = this.LoginedUser;

            var roomViewModels = await AppServices.Room.GetByType(user.Id, MessageRoomTypes.Support);

            var response = new Response
            {
                Data = roomViewModels,
                Message = "Get successfully",
                StatusCode = StatusCodes.Status200OK
            };

            return new JsonResult(response);
        }

        /// <summary>
        /// Get message room by booking detail - (pending...)
        /// </summary>
        /// <remarks>Get message room</remarks>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [HttpGet("message/room/by-booking-detail")]
        public async Task<IActionResult> GetMessageRoomByBookingDetail()
        {
            return Ok();
        }


        /// <summary>
        /// Test api - Create message room with specific partners's code
        /// </summary>
        /// /// <remarks>Create message room</remarks>
        /// <param name="request" example="['613de7b4-db59-4a6c-b9a1-2b1e176460d3']">MessageRoomRequest schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost("message/room")]
        public async Task<IActionResult> CreateMessageRoom([FromBody] MessageRoomRequest request)
        {
            Response response = new();

            var user = this.LoginedUser;

            request.PartnerUserCodes.Add(user.Code);

            var members = await AppServices.User.GetUsersByCode(request.PartnerUserCodes);

            var room = await AppServices.Room.Create(members.Select(member => member.Id).ToList(),MessageRoomTypes.Conversation);

            if(room == null)
            {
                response = new Response
                {
                    Message = "Fail to create message room",
                    StatusCode = StatusCodes.Status400BadRequest
                };

                return BadRequest(response);
            }

            var roomViewModel = await AppServices.Room.GetViewModelByCode(room.Code);

            response = new Response
            {
                Data = roomViewModel,
                Message = "Send message successfully",
                StatusCode = StatusCodes.Status200OK
            };
            return new JsonResult(response);
        }
    }
}
