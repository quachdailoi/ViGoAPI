﻿using API.JwtFeatures;
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
        private readonly ISignalRService _signalRService;

        public MessagesController(ISignalRService signalRService)
        {
            _signalRService = signalRService;
        }

        /// <summary>
        /// Send message to specific room
        /// </summary>
        /// /// <remarks>Websocket - signal info: method(Message) -  json { RoomCode, Message }</remarks>
        /// <param name="request" example="{Content: 'Hello world!' ,RoomCode: '613de7b4-db59-4a6c-b9a1-2b1e176460d3'}">MessageRequest schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost()]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            var response = await AppServices.Message.Create(
                                request.Content, 
                                request.RoomCode, 
                                this.LoggedInUser.Id,
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
        /// /// <remarks>Websocket - signal info: method(UpdateLastSeen) -  json {RoomCode , UserCode, LastSeenTime}</remarks>
        /// <param name="request" example="{Content: 'Hello world!' ,RoomCode: '613de7b4-db59-4a6c-b9a1-2b1e176460d3'}">LastSeenTimeMessageRequest schema</param>
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