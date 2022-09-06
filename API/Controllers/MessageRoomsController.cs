using API.Models.Requests;
using API.Models.Response;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MessageRoomsController : BaseController<MessageRoomsController>
    {
        /// <summary>
        /// Create support room (pending...)
        /// </summary>
        /// /// <remarks>Websocket - signal info: method(Room) - obj(Room)</remarks>
        /// <response code="200">Create successfully</response>
        /// <response code="102">Waiting to connect with support staff</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost("support")]
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
        /// Get message room by partner's code (optional)
        /// </summary>
        /// /// <remarks>Get message room</remarks>
        /// <param name="userCode" example="613de7b4-db59-4a6c-b9a1-2b1e176460d3">Users Code</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpGet("{userCode}")]
        public IActionResult GetMessageRoomByUserCode(Guid userCode)
        {
            var userCodes = new List<Guid>
            {
                userCode,
                this.LoggedInUser.Code
            };

            var response = AppServices.Room.GetViewModelByMemberCode(
                                userCodes,
                                successResponse: new()
                                {
                                    Message = "Get message room successfully.",
                                    StatusCode = StatusCodes.Status200OK
                                },
                                notFoundResponse: new()
                                {
                                    Message = "Not message room with this user.",
                                    StatusCode = StatusCodes.Status404NotFound
                                },
                                errorResponse: new()
                                {
                                    Message = "Fail to get message room.",
                                    StatusCode = StatusCodes.Status500InternalServerError
                                }
                                );

            return new JsonResult(response);
        }

        /// <summary>
        /// Get message room by code
        /// </summary>
        /// /// <remarks>Get message room</remarks>
        /// <param name="roomCode" example="613de7b4-db59-4a6c-b9a1-2b1e176460d3">Room Code</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [HttpGet("code/{roomCode}")]
        public async Task<IActionResult> GetMessageRoomByCode(Guid roomCode)
        {
            var response = await AppServices.Room.GetViewModelByCode(                                                            
                                        roomCode,                                                            
                                        successResponse: new()                                                            
                                        {                                                                
                                            Message = "Get message room successfully",                                                               
                                            StatusCode = StatusCodes.Status200OK                                                            
                                        },                                                            
                                        notFoundResponse: new()                                                          
                                        {                                                                
                                            Message = "Not message room with this code.",                                                               
                                            StatusCode = StatusCodes.Status404NotFound                                                            
                                        },                                                            
                                        errorResponse: new()                                                            
                                        {                                                               
                                            Message = "Fail to get message room.",                                                                
                                            StatusCode = StatusCodes.Status500InternalServerError                                                            
                                        }                                                            
                                        );

            return new JsonResult(response);
        }

        /// <summary>
        /// Get support message room
        /// </summary>
        /// /// <remarks>Get support message room</remarks>
        /// <response code="200">Get successfully</response>
        /// <response code="500">Failure</response>
        [HttpGet("support")]
        public async Task<IActionResult> GetSupportMessageRoom()
        {
            var user = this.LoggedInUser;

            var response = await AppServices.Room.GetByType(
                                        user.Id, 
                                        MessageRoomTypes.Support,
                                        successResponse: new()
                                        {
                                            Message = "Get message room successfully.",
                                            StatusCode = StatusCodes.Status200OK
                                        },
                                        notFoundResponse: new()
                                        {
                                            Message = "Not message room with this code.",
                                            StatusCode = StatusCodes.Status404NotFound
                                        },
                                        errorResponse: new()
                                        {
                                            Message = "Fail to get message room.",
                                            StatusCode = StatusCodes.Status500InternalServerError
                                        }
                                        );

            return new JsonResult(response);
        }

        /// <summary>
        /// Test api - Create message room with specific partners's code
        /// </summary>
        /// /// <remarks>Create message room</remarks>
        /// <param name="request" example="['613de7b4-db59-4a6c-b9a1-2b1e176460d3']">MessageRoomRequest schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateMessageRoom([FromBody] MessageRoomRequest request)
        { 
            var user = this.LoggedInUser;

            request.PartnerUserCodes.Add(user.Code);

            var response = await AppServices.Room.Create(
                                request.PartnerUserCodes, 
                                MessageRoomTypes.Conversation,
                                successResponse: new()
                                {
                                    Message = "Create successfully.",
                                    StatusCode = StatusCodes.Status200OK
                                },
                                duplicateResponse: new()
                                {
                                    Message = "Duplicate - Message room for there users is existed.",
                                    StatusCode= StatusCodes.Status400BadRequest
                                },
                                errorResponse: new()
                                {
                                    Message = "Fail to create message room.",
                                    StatusCode = StatusCodes.Status500InternalServerError
                                }
                                );

            return new JsonResult(response);
        }

        /// <summary>
        /// Test api - Create message room with specific partners's code
        /// </summary>
        /// /// <remarks>Create message room</remarks>
        /// <param name="request" example="['613de7b4-db59-4a6c-b9a1-2b1e176460d3']">MessageRoomRequest schema</param>
        /// <response code="200">Send successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var user = this.LoggedInUser;

            var response = await AppServices.Room.GetAll(
                                user.Id,
                                successResponse: new()
                                {
                                    Message = "Get successfully.",
                                    StatusCode = StatusCodes.Status200OK
                                },
                                notFoundResponse: new()
                                {
                                    Message = "Not exist message rooms of this user.",
                                    StatusCode = StatusCodes.Status404NotFound
                                },
                                errorResponse: new()
                                {
                                    Message = "Fail to create message room.",
                                    StatusCode = StatusCodes.Status500InternalServerError
                                }
                                );

            return new JsonResult(response);
        }
    }
}
