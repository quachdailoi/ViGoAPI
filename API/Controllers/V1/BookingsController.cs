using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
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
        private readonly IRedisMQService _redisMQService;

        public BookingsController(IMapper mapper, IRedisMQService redisMQService)
        {
            _mapper = mapper;
            _redisMQService = redisMQService;
        }


        /// <summary>
        ///     Create booking (updating ...).
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/booking 
        ///     {
        ///         "VehicleTypeCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "Time": "04:30:00", // format("hh:mm:ss")
        ///         "Type": 0, // 0: WeekTicket, 1: MonthTicket, 2: QuaterTicket
        ///         "PaymentMethod": 1, // 0: COD, 1: Momo, 2: VNPay, 3: BankCard
        ///         "IsShared": true,
        ///         "StartStationCode": "352f7023-91c0-4201-b7b8-f9919f1181d9",
        ///         "EndStationCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "RouteCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657", // get from get route and fee api
        ///         "StartAt": "15-02-2022", // format("dd-MM-yyyy")
        ///         "EndAt": "25-06-2022",
        ///         "PromotionCode": "HELLO2022",
        ///         "Applink": "vigo://abcxyz" // redirect to app after pay via e-wallet app
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request"></param>
        /// <response code = "200"> Create booking successfully.</response>
        /// <response code = "202"> Not exist any available driver for this booking.</response>
        /// <response code = "400"> 
        ///     Start time must be before end time. <br></br>
        ///     Wrong format of date parameter. <br></br>
        ///     Start station and end station are not exist. <br></br>
        ///     Start station is not exist. <br></br>
        ///     End station is not exist. <br></br>
        ///     Route is not exist.<br></br>
        ///     VehicleTypeCode is invalid.<br></br>
        ///     Payment method is not supported.<br></br>
        ///     Conflict about the time schedule with your other bookings. <br></br>
        ///     Promotion code is not available. <br></br>
        /// </response>
        /// <response code="500"> Failed to create booking.</response>
        [HttpPost]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            var user = LoggedInUser;

            var pairOfStation = await AppServices.Station.GetByCode(new List<Guid> { request.StartStationCode, request.EndStationCode });

            var badRequestResponse = new Response
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            if (!pairOfStation.Any()) 
                return ApiResult(badRequestResponse.SetMessage("Start station and end station are not exist."));

            var startStation = pairOfStation
                .Where(station => station.Code == request.StartStationCode)
                .FirstOrDefault();

            var endStation = pairOfStation
                .Where(station => station.Code == request.EndStationCode)
                .FirstOrDefault();     

            if (startStation == null) 
                return ApiResult(badRequestResponse.SetMessage("Start station is not exist."));

            if (endStation == null) 
                return ApiResult(badRequestResponse.SetMessage("End station is not exist."));

            var booking = new BookingDTO();

            try
            {
                booking = _mapper.Map<BookingDTO>(request);
                if (booking.EndAt.CompareTo(booking.StartAt) < 0) return ApiResult(badRequestResponse.SetMessage("Start time must be before end time."));           
            }
            catch (Exception e)
            {
                return ApiResult(badRequestResponse.SetMessage("Wrong format of date parameter."));
            }

            VehicleType? vehicleType = await AppServices.VehicleType.GetByCode(request.VehicleTypeCode);

            if (vehicleType == null) return ApiResult(badRequestResponse.SetMessage("VehicleTypeCode is invalid."));

            booking.VehicleTypeId = vehicleType.Id;
            booking.UserId = user.Id;

            CollectionLinkRequestDTO paymentDto = new();

            switch (booking.PaymentMethod)
            {
                case PaymentMethods.Momo:
                    paymentDto = new MomoCollectionLinkRequestDTO
                    {
                        ipnUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}/ipn/momo",
                        redirectUrl = request.Applink
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
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    },
                                                    duplicationResponse: new()
                                                    {
                                                        Message = "Conflict about the time schedule with your other bookings.",
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    },
                                                    invalidPromotionResponse: new()
                                                    {
                                                        Message = "Promotion code is not available.",
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    },
                                                    notAvailableResponse: new()
                                                    {
                                                        Message = "Not exist any available driver for this booking.",
                                                        StatusCode = StatusCodes.Status202Accepted
                                                    },
                                                    errorReponse: new()
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
        /// <response code = "200"> Get bookings successfully.</response>
        /// <response code = "404"> Not found any bookings.</response>
        /// <response code="500"> Failed to get bookings.</response>
        [HttpGet]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> GetBooking()
        {
            var user = LoggedInUser;

            var response = await AppServices.Booking.GetAll(
                                            user.Id,
                                            successReponse: new()
                                            {
                                                Message = "Get bookings successfully.",
                                                StatusCode = StatusCodes.Status200OK
                                            }
                                            );
            return ApiResult(response);
        }

        /// <summary>
        ///     Get next trip of this user.
        /// </summary>
        /// <response code = "200"> Get bookings successfully.</response>
        /// <response code="500"> Failed to get bookings.</response>
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
        ///     GET api/booking/route-fee 
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
            var dto = new StationWithScheduleDTO();

            var badRequestResponse = new Response
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            try
            {
                dto = _mapper.Map<StationWithScheduleDTO>(request);
                if (dto.EndAt.CompareTo(dto.StartAt) < 0) return ApiResult(badRequestResponse.SetMessage("Start time must be before end time."));
            }
            catch(Exception e)
            {
                return ApiResult(badRequestResponse.SetMessage("Wrong format of date parameter."));
            }

            var pairOfStation = await AppServices.Station.GetByCode(new List<Guid> { request.StartStationCode, request.EndStationCode });

            if (!pairOfStation.Any())
                return ApiResult(badRequestResponse.SetMessage("Start station and end station are not exist."));

            var startStation = pairOfStation
                .Where(station => station.Code == request.StartStationCode)
                .FirstOrDefault();

            var endStation = pairOfStation
                .Where(station => station.Code == request.EndStationCode)
                .FirstOrDefault();

            if (startStation == null)
                return ApiResult(badRequestResponse.SetMessage("Start station is not exist."));

            if (endStation == null)
                return ApiResult(badRequestResponse.SetMessage("End station is not exist."));

            dto.StartStationId = startStation.Id;
            dto.EndStationId = endStation.Id;

            VehicleType? vehicleType = await AppServices.VehicleType.GetByCode(request.VehicleTypeCode);

            if (vehicleType == null) return ApiResult(badRequestResponse.SetMessage("VehicleTypeCode is invalid"));

            dto.VehicleTypeId = vehicleType.Id;

            var response =
                await AppServices.Route.GetRouteFeeByPairOfStation(
                    dto,
                    successResponse: new()
                    {
                        Message = "Get route successfully.",
                        StatusCode= StatusCodes.Status200OK
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
        ///         "RouteId": 1, // get from get route and fee api
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
        /// <response code="500"> Failed to create booking.</response>
        [HttpGet("booking-provision")]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> GetProvisionalBooking([FromQuery] GetProvisionalBookingRequest request)
        {
            var user = LoggedInUser;

            var pairOfStation = await AppServices.Station.GetByCode(new List<Guid> { request.StartStationCode, request.EndStationCode });

            var badRequestResponse = new Response
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            if (!pairOfStation.Any())
                return ApiResult(badRequestResponse.SetMessage("Start station and end station are not exist."));

            var startStation = pairOfStation
                .Where(station => station.Code == request.StartStationCode)
                .FirstOrDefault();

            var endStation = pairOfStation
                .Where(station => station.Code == request.EndStationCode)
                .FirstOrDefault();

            if (startStation == null)
                return ApiResult(badRequestResponse.SetMessage("Start station is not exist."));

            if (endStation == null)
                return ApiResult(badRequestResponse.SetMessage("End station is not exist."));

            var booking = new BookingDTO();

            try
            {
                booking = _mapper.Map<BookingDTO>(request);
                if (booking.EndAt.CompareTo(booking.StartAt) < 0) return ApiResult(badRequestResponse.SetMessage("Start time must be before end time."));
            }
            catch (Exception e)
            {
                return ApiResult(badRequestResponse.SetMessage("Wrong format of date parameter."));
            }

            VehicleType? vehicleType = await AppServices.VehicleType.GetByCode(request.VehicleTypeCode);

            if (vehicleType == null) return ApiResult(badRequestResponse.SetMessage("VehicleTypeCode is invalid"));

            booking.VehicleTypeId = vehicleType.Id;

            //booking.StartStationId = startStation.Id;
            //booking.EndStationId = endStation.Id;

            var response = await AppServices.Booking.GetProvision(
                                                    booking,
                                                    successResponse: new()
                                                    {
                                                        Message = "Get booking provisional successfully.",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    invalidRouteResponse: new()
                                                    {
                                                        Message = "Route is not exist.",
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

            if (dto.resultCode == (int)MomoStatusCodes.Successed)
            {
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

                //if (signature == dto.signature)
                //{
                    var booking = await AppServices.Booking.GetByCode(Guid.Parse(dto.orderId));

                    if (booking?.Status == Bookings.Status.Unpaid && booking?.TotalPrice == dto.amount)
                    {
                        booking.Status = Bookings.Status.PendingMapping;
                        await AppServices.Booking.Update(booking);
                        
                        //add job queue to map with specific driver
                        await _redisMQService.Publish(MappingBookingTask.BOOKING_QUEUE, booking.Id);
                }
                //}
            }
            return NoContent();
        }
        /// <summary>
        ///     Get route and fee from pair of stations (cross multiple routes is possible) - updating ...
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/bookers/booking/route-fee 
        ///     {
        ///         "StartStationCode": "352f7023-91c0-4201-b7b8-f9919f1181d9",
        ///         "EndStationCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "VehicleType": 0,  // 0: ViRide, 1: ViCar_4, 2: ViCar_7
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request"></param>
        /// <response code = "200"> 
        ///     Get successfully. <br></br>
        ///     Not exist any route satisfied this trip. <br></br>
        /// </response>
        /// <response code = "400"> 
        ///     Start station and end station are not exist. <br></br>
        ///     Start station is not exist. <br></br>
        ///     End station is not exist. <br></br>
        /// </response>
        /// <response code="500"> Failed to get route and fee.</response>
        //[HttpGet("booking/route-fee/multiple-routes")]
        //[Authorize(Roles = "BOOKER")]
        //public async Task<IActionResult> GetRoutesAndFee([FromQuery] GetRouteFeeRequest request)
        //{
        //var pairOfStation = await AppServices.Station.GetByCode(new List<Guid> { request.StartStationCode, request.EndStationCode });

        //var inValidStationResponse = new Response
        //{
        //    StatusCode = StatusCodes.Status400BadRequest
        //};

        //if (!pairOfStation.Any())
        //    return ApiResult(inValidStationResponse.SetMessage("Start station and end station are not exist."));

        //var startStation = pairOfStation
        //    .Where(station => station.Code == request.StartStationCode)
        //    .FirstOrDefault();

        //var endStation = pairOfStation
        //    .Where(station => station.Code == request.EndStationCode)
        //    .FirstOrDefault();

        //if (startStation == null)
        //    return ApiResult(inValidStationResponse.SetMessage("Start station is not exist."));

        //if (endStation == null)
        //    return ApiResult(inValidStationResponse.SetMessage("End station is not exist."));

        //var response =
        //    await AppServices.Route.GetStepsByPairOfStations(
        //        startStation,
        //        endStation,
        //        request.VehicleType,
        //        successResponse: new()
        //        {
        //            Message = "Get routes successfully",
        //            StatusCode = StatusCodes.Status200OK
        //        });

        //return ApiResult(response);
        //}
    }
}
