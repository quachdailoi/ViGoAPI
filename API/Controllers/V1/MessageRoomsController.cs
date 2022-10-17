using API.Models.Requests;
using API.Models.Response;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
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

        ///// <summary>
        ///// Get message room by partner's code (optional)
        ///// </summary>
        ///// /// <remarks>Get message room</remarks>
        ///// <param name="userCode" example="613de7b4-db59-4a6c-b9a1-2b1e176460d3">Users Code</param>
        ///// <response code="200">Send successfully</response>
        ///// <response code="500">Failure</response>
        //[CustomAuthorize]
        //[HttpGet("{userCode}")]
        //public IActionResult GetMessageRoomByUserCode(Guid userCode)
        //{
        //    var userCodes = new List<Guid>
        //    {
        //        userCode,
        //        this.LoggedInUser.Code
        //    };

        //    var response = AppServices.Room.GetViewModelByMemberCode(
        //                        userCodes,
        //                        successResponse: new()
        //                        {
        //                            Message = "Get message room successfully.",
        //                            StatusCode = StatusCodes.Status200OK
        //                        },
        //                        notFoundResponse: new()
        //                        {
        //                            Message = "Not message room with this user.",
        //                            StatusCode = StatusCodes.Status404NotFound
        //                        }
        //                        );

        //    return ApiResult(response);
        //}


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

            var response = 
                await AppServices.Room.Create(
                    request.PartnerUserCodes,
                    Rooms.RoomTypes.Conversation,
                    successResponse: new()
                    {
                        Message = "Create successfully.",
                        StatusCode = StatusCodes.Status200OK
                    },
                    duplicateResponse: new()
                    {
                        Message = "Duplicate - Message room for there users is existed.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    errorResponse: new()
                    {
                        Message = "Failed to create message room.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );

            return ApiResult(response);
        }

        /// <summary>
        /// Get  user's message rooms
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/messages 
        ///     {
        ///         "RoomType": 1, // 0: supportRoom, 1: conservationRoom
        ///         "Code": "352f7023-91c0-4201-b7b8-f9919f1181d9"
        ///     }
        /// ```
        /// </remarks>
        /// <response code="200">Get successfully</response>
        /// <response code="500">Failure</response>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetMessageRoomRequest request)
        {
            var user = this.LoggedInUser;

            var response =
                await AppServices.Room.Get(
                    user.Id,
                    request,
                    successResponse: new()
                    {
                        Message = "Get successfully.",
                        StatusCode = StatusCodes.Status200OK
                    }
                );

            return ApiResult(response);
        }
    }
}
