﻿using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.SignalR.Constract;
using API.TaskQueues;
using API.TaskQueues.TaskResolver;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BookingsController : BaseController<BookingsController>
    {
        private readonly IMapper _mapper;

        public BookingsController(IMapper mapper)
        {
            _mapper = mapper;
        }


        /// <summary>
        ///     Create booking (updating ...).
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/bookings 
        ///     {
        ///         "VehicleTypeCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "Time": "04:30:00", // format("hh:mm:ss")
        ///         "Type": 0, // 0: WeekTicket, 1: MonthTicket, 2: QuaterTicket
        ///         "PaymentMethod": 1, // 0: COD, 1: Momo, 2: VNPay, 3: BankCard, 4: Wallet
        ///         "IsShared": true,
        ///         "StartStationCode": "352f7023-91c0-4201-b7b8-f9919f1181d9",
        ///         "EndStationCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "RouteCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657", // get from get route and fee api
        ///         "StartAt": "15-02-2022", // format("dd-MM-yyyy")
        ///         "EndAt": "25-06-2022",
        ///         "PromotionCode": "HELLO2022"
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request"></param>
        /// <response code = "200"> Create booking successfully.</response>
        /// <response code = "202"> Not exist any available driver for this booking.</response>
        /// <response code = "400"> 
        ///     Start time must be before end time. <br></br>
        ///     Wrong format of date parameter. <br></br>
        ///     Stations are not exist. <br></br>
        ///     Route is not exist.<br></br>
        ///     VehicleTypeCode is invalid.<br></br>
        ///     Payment method is not supported.<br></br>
        ///     You have booked at this time in an another booking. Check again! <br></br>
        ///     Insufficient balance. <br></br>
        ///     Fail to pay by wallet. <br></br>
        ///     Promotion code is not available. <br></br>
        /// </response>
        /// <response code="500"> Failed to create booking.</response>
        [HttpPost]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            var user = LoggedInUser;

            var badRequestResponse = new Response
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            var booking = _mapper.Map<BookingDTO>(request);             

            booking.UserId = user.Id;

            CollectionLinkRequestDTO paymentDto = new();

            switch (booking.PaymentMethod)
            {
                case Payments.PaymentMethods.COD:
                    break;
                case Payments.PaymentMethods.Momo:
                    paymentDto = new MomoCollectionLinkRequestDTO
                    {
                        ipnUrl = $"{GetControllerContextUri()}/ipn/momo"
                    };
                    break;
                default: return ApiResult(badRequestResponse.SetMessage("Payment method is not supported."));
            }

            var response = await AppServices.Booking.Create(
                                                    booking,
                                                    paymentDto,
                                                    successResponse: new()
                                                    {
                                                        Message = "Create booking successfully.",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    invalidRouteResponse: new()
                                                    {
                                                        Message = "Route is not exist.",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    invalidStationResponse: new()
                                                    {
                                                        Message = "Stations are not exist.",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    invalidVehicleTypeResponse: new()
                                                    {
                                                        Message = "Vehicle type is not exist.",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    duplicationResponse: new()
                                                    {
                                                        Message = "You have booked at this time in an another booking. Check again!",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    invalidPromotionResponse: new()
                                                    {
                                                        Message = "Promotion code is not available.",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    notAvailableResponse: new()
                                                    {
                                                        Message = "Not exist any available driver for this booking.",
                                                        StatusCode = StatusCodes.Status202Accepted
                                                    },
                                                    insufficientBalanceResponse: new()
                                                    {
                                                        Message = "Insufficient balance.",
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    },
                                                    errorResponse: new()
                                                    {
                                                        Message = "Fail to create booking.",
                                                        StatusCode = StatusCodes.Status500InternalServerError
                                                    }
                                                    );
            return ApiResult(response);
        }

        /// <summary>
        ///     Get all booking belong to user (updating ...).
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/bookings 
        /// </remarks>
        /// <response code = "200"> Get bookings successfully.</response>
        /// <response code = "404"> Not found any bookings.</response>
        /// <response code="500"> Failed to get bookings.</response>
        [HttpGet]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> GetBooking([FromQuery] GetBookingRequest request)
        {
            var user = LoggedInUser;

            var response = await AppServices.Booking.Get(
                                            user.Id,
                                            request,
                                            successReponse: new()
                                            {
                                                Message = "Get bookings successfully.",
                                                StatusCode = StatusCodes.Status200OK
                                            }
                                            );
            return ApiResult(response);
        }

        ///// <summary>
        /////     Get history of booking details belong to user.
        ///// </summary>
        ///// <remarks>
        ///// ```
        ///// Sample request:
        /////     GET api/bookings/history 
        /////     {
        /////         FromDate: "10-10-2022",
        /////         ToDate: "17-10-2022"
        /////     }
        ///// </remarks>
        ///// <response code = "200"> Get bookings successfully.</response>
        ///// <response code = "404"> Not found any bookings.</response>
        ///// <response code="500"> Failed to get bookings.</response>
        //[HttpGet("history")]
        //[Authorize(Roles = "BOOKER")]
        //public async Task<IActionResult> GetBookingDetailHistory([FromQuery] DateFilterRequest dateFilterRequest)
        //{
        //    var user = LoggedInUser;

        //    var response = await AppServices.BookingDetail.GetHistory(
        //                                    user.Id,
        //                                    dateFilterRequest: dateFilterRequest,
        //                                    successResponse: new()
        //                                    {
        //                                        Message = "Get booking details successfully.",
        //                                        StatusCode = StatusCodes.Status200OK
        //                                    }
        //                                    );
        //    return ApiResult(response);
        //}

        ///// <summary>
        /////     Get on going booking details belong to user.
        ///// </summary>
        ///// <remarks>
        ///// ```
        ///// Sample request:
        /////     GET api/bookings/on-going 
        /////     {
        /////         FromDate: "10-10-2022",
        /////         ToDate: "17-10-2022"
        /////     }
        ///// </remarks>
        ///// <response code = "200"> Get bookings successfully.</response>
        ///// <response code = "404"> Not found any bookings.</response>
        ///// <response code="500"> Failed to get bookings.</response>
        //[HttpGet("on-going")]
        //[Authorize(Roles = "BOOKER")]
        //public async Task<IActionResult> GetBookingDetailOnGoing([FromQuery] DateFilterRequest dateFilterRequest)
        //{
        //    var user = LoggedInUser;

        //    var response = await AppServices.BookingDetail.GetOnGoing(
        //                                    user.Id,
        //                                    dateFilterRequest: dateFilterRequest,
        //                                    successResponse: new()
        //                                    {
        //                                        Message = "Get booking details successfully.",
        //                                        StatusCode = StatusCodes.Status200OK
        //                                    }
        //                                    );
        //    return ApiResult(response);
        //}

        /// <summary>
        ///     Get on going booking details belong to user.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/bookings/on-going 
        ///     {
        ///         FromDate: "10-10-2022",
        ///         ToDate: "17-10-2022"
        ///     }
        /// </remarks>
        /// <response code = "200"> Get bookings successfully.</response>
        /// <response code = "404"> Not found any bookings.</response>
        /// <response code="500"> Failed to get bookings.</response>
        [HttpGet("booking-details")]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> GetBookingDetail()
        {
            var user = LoggedInUser;

            var response = await AppServices.BookingDetail.GetAll(
                                            user.Id,
                                            successResponse: new()
                                            {
                                                Message = "Get booking details successfully.",
                                                StatusCode = StatusCodes.Status200OK
                                            }
                                            );
            return ApiResult(response);
        }

        /// <summary>
        ///     Get next trip of this user.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/bookings/next-booking-detail 
        /// </remarks>
        /// <response code = "200"> Get next trip successfully.</response>
        [HttpGet("next-booking-detail")]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> GetNextTrip()
        {
            var user = LoggedInUser;

            var response = await AppServices.BookingDetail.GetNextBookingDetail(
                                            user.Id,
                                            successResponse: new()
                                            {
                                                Message = "Get next trip successfully.",
                                                StatusCode = StatusCodes.Status200OK
                                            }
                                            );

            return ApiResult(response);
        }

        /// <summary>
        ///     Get route and fee from pair of stations
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/bookings/route-fee 
        ///     {
        ///         "StartStationCode": "352f7023-91c0-4201-b7b8-f9919f1181d9",
        ///         "EndStationCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "BookingType": 0, // 0: WeekTicket, 1: MonthTicket, 2: QuarterTicket
        ///         "StartAt": "15-09-2022", // format("dd-MM-yyyy")
        ///         "EndAt": "31-10-2022",
        ///         "Time": "08:00:00",
        ///         "VehicleTypeCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657"
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request"></param>
        /// <response code = "200"> 
        ///     Get successfully. <br></br>
        ///     Not exist any route satisfied this trip. <br></br>
        /// </response>
        /// <response code = "400"> 
        ///     Start time must be before end time. <br></br>
        ///     Wrong format of date parameter. <br></br>
        ///     Start station and end station are not exist. <br></br>
        ///     Start station is not exist. <br></br>
        ///     End station is not exist. <br></br>
        ///     Route is not exist.<br></br>
        ///     VehicleTypeCode is invalid.<br></br>
        /// </response>
        /// <response code="500"> Failed to get route and fee.</response>
        [HttpGet("route-fee")]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> GetRouteAndFee([FromQuery] GetRouteFeeRequest request)
        {
            var dto = _mapper.Map<StationWithScheduleDTO>(request);

            var response =
                await AppServices.Route.GetRouteFeeByPairOfStation(
                    dto,
                    successResponse: new()
                    {
                        Message = "Get route successfully.",
                        StatusCode= StatusCodes.Status200OK
                    },
                    invalidStationResponse: new()
                    {
                        Message = "Stations are not exist.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    invalidVehicleTypeResponse: new()
                    {
                        Message = "Vehicle type is not exist.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    notFoundResponse: new()
                    {
                        Message = "Not exist any route satisfied this trip.",
                        StatusCode = StatusCodes.Status200OK
                    });

            return ApiResult(response);
        }

        /// <summary>
        ///     Get booking provisional.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/bookings/booking-provision 
        ///     {
        ///         "VehicleTypeCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "Time": "04:30:00", // format("hh:mm:ss")
        ///         "Type": 0, // 0: WeekTicket, 1: MonthTicket, 2: QuaterTicket
        ///         "StartStationCode": "352f7023-91c0-4201-b7b8-f9919f1181d9",
        ///         "EndStationCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "RouteCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657", // get from get route and fee api
        ///         "StartAt": "15-02-2022", // format("dd-MM-yyyy")
        ///         "EndAt": "25-06-2022",
        ///         "PromotionCode": "HELLO2022"
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request"></param>
        /// <response code = "200"> Get booking provisional successfully.</response>
        /// <response code = "400"> 
        ///     Start time must be before end time. <br></br>
        ///     Wrong format of date parameter. <br></br>
        ///     Start station and end station are not exist. <br></br>
        ///     Start station is not exist. <br></br>
        ///     End station is not exist. <br></br>
        ///     Route is not exist.<br></br>
        ///     VehicleTypeCode is invalid.<br></br>
        ///     Payment method is not supported.<br></br>
        ///     Promotion code is not available. <br></br>
        /// </response>
        /// <response code="500"> Failed to get booking provisional.</response>
        [HttpGet("booking-provision")]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> GetProvisionalBooking([FromQuery] GetProvisionalBookingRequest request)
        {
            var user = LoggedInUser;

            var booking = _mapper.Map<BookingDTO>(request);

            booking.UserId = user.Id;

            var response = await AppServices.Booking.GetProvision(
                                                    booking,
                                                    successResponse: new()
                                                    {
                                                        Message = "Get booking provisional successfully.",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    invalidStationResponse: new()
                                                    {
                                                        Message = "Stations are not exist.",
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    },
                                                    invalidRouteResponse: new()
                                                    {
                                                        Message = "Route is not exist.",
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    },
                                                    invalidVehicleTypeResponse: new()
                                                    {
                                                        Message = "Vehicle type is not exist.",
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    },
                                                    invalidPromotionResponse: new()
                                                    {
                                                        Message = "Promotion code is not available.",
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    }
                                                    );
            return ApiResult(response);
        }

        [ApiExplorerSettings(IgnoreApi =true)] // api for momo return result of transaction
        [HttpPost("ipn/momo")]
        public async Task<IActionResult> HandleBookingMomoPaymentIPN([FromBody] JsonElement request)
        {
            var dto = JsonSerializer.Deserialize<MomoPaymentNotificationRequest>(request.GetRawText());

            var rawSignature = $"amount={dto.amount}&" +
                    $"extraData={dto.extraData}&" +
                    $"message={dto.message}&" +
                    $"orderId={dto.orderId}&" +
                    $"orderInfo={dto.orderInfo}&" +
                    $"orderType={dto.orderType}&" +
                    $"partnerCode={dto.partnerCode}&" +
                    $"payType={dto.payType}&" +
                    $"requestId={dto.requestId}&" +
                    $"responseTime={dto.responseTime}&" +
                    $"resultCode={dto.resultCode}&" +
                    $"transId={dto.transId}";

            var signature = AppServices.Payment.GetMomoSignature(rawSignature);
            var booking = await AppServices.Booking.GetByCode(Guid.Parse(dto.orderId));

            if(booking != null)
            {
                if (dto.resultCode == (int)Payments.MomoStatusCodes.Successed)
                {
                    if (booking.Status == Bookings.Status.Unpaid && booking.TotalPrice == dto.amount)
                    {
                        if (!AppServices.Booking.CheckIsConflictBooking(booking).Result)
                        {
                            booking.Status = Bookings.Status.PendingMapping;
                            await AppServices.Booking.Update(booking);

                            //add job queue to map with specific driver
                            await AppServices.RedisMQ.Publish(MappingBookingTask.BOOKING_QUEUE, booking.Id);

                            await AppServices.SignalR.SendToUserAsync(booking.User.Code.ToString(), "BookingPaymentResult",
                            new
                            {
                                BookingCode = dto.orderId,
                                PaymentMethod = Payments.PaymentMethods.Momo,
                                IsSuccess = dto.resultCode == (int)Payments.MomoStatusCodes.Successed,
                                Message = "Pay booking by Momo successfully."
                            });
                        }
                        else
                        {
                            await AppServices.SignalR.SendToUserAsync(booking.User.Code.ToString(), "BookingPaymentResult",
                            new
                            {
                                BookingCode = dto.orderId,
                                PaymentMethod = Payments.PaymentMethods.Momo,
                                IsSuccess = false,
                                Message = "You have booked at this time in an another booking. Check again!"
                            });
                        }                       
                    }
                }
            } 

            //if (signature == dto.signature)
            //{
            return NoContent();
        }
    }
}
