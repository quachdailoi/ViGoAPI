using API.JwtFeatures;
using API.Models.Requests;
using API.Models.Response;
using API.Quartz;
using API.SignalR.Constract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MessagesController : BaseController<MessagesController>
    {

        /// <summary>
        /// Send message to specific room
        /// </summary>
        /// <remarks>
        /// Websocket - signal info: method(Message) -  json { RoomCode, Message }
        /// ```
        /// Sample request:
        ///     POST api/messages
        ///     {
        ///         "RoomCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "Content": "hello", 
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request">MessageRequest schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            var response = await AppServices.Message.Create(
                                request.Content, 
                                request.RoomCode, 
                                this.LoggedInUser,
                                successResponse: new()
                                {
                                    Message = "Send message successfully",
                                    StatusCode = StatusCodes.Status200OK
                                },
                                errorResponse: new()
                                {
                                    Message = "Fail to send message",
                                    StatusCode = StatusCodes.Status500InternalServerError
                                }
                                );
            return ApiResult(response);
        }

        /// <summary>
        /// Mark read in specific room
        /// </summary>
        /// <remarks>
        /// Websocket - signal info: method(UpdateLastSeen) -  json {RoomCode , UserCode, LastSeenTime}
        /// ```
        /// Sample request:
        ///     PUT api/messages/last-seen-time
        ///     {
        ///         "RoomCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request"></param>
        /// <response code="200">Mark read successfully</response>
        /// <response code="400">Fail to mark read</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPut("last-seen-time")]
        public async Task<IActionResult> UpdateLastSeen([FromBody] LastSeenTimeMessageRequest request)
        {
            var user = this.LoggedInUser;

            var response = await AppServices.UserRoom.UpdateLastSeenTime(
                                                        user: new()
                                                        {
                                                            Code = user.Code,
                                                            Id = user.Id
                                                        }, 
                                                        request.RoomCode,
                                                        successResponse: new()
                                                        {
                                                            Message = "Update last seen time successfully",
                                                            StatusCode = StatusCodes.Status200OK
                                                        },
                                                        errorResponse: new()
                                                        {
                                                            Message = "Fail to update last seen time",
                                                            StatusCode = StatusCodes.Status500InternalServerError
                                                        }
                                                        );

            return ApiResult(response);
        }
    }
}
