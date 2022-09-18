using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        ///     POST api/bookers/booking 
        ///     {
        ///         "TotalPrice": 50000,
        ///         "VehicleType": 0,  // 0: ViRide, 1: ViCar_4, 2: ViCar_7
        ///         "Time": "04:30:00",
        ///         "Option": 0, // 0: none, 1: ignore on sunday, 2: ignore on saturday and sunday
        ///         "Type": 0, // 0: monthly, 1: weekly
        ///         "PaymentMethod": 0, //COD = 0,Momo = 1,VNPay = 2, BankCard = 3
        ///         "Days": {
        ///              "DaysOfWeek": [],
        ///              "DaysOfMonth": [1,4,6,29,30,31],
        ///              "AdditionalDaysByMonth": { "3": [1,2,3], "5": [1]}
        ///         },
        ///         "IsShared": true,
        ///         "StartStationCode": "352f7023-91c0-4201-b7b8-f9919f1181d9",
        ///         "EndStationCode": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "Duration": 600, //(seconds) // get from get route and fee api
        ///         "Distance": 3000, //(meters) // get from get route and fee api
        ///         "Steps": [], // get from get route and fee api
        ///         "StartAt": "15-02-2022",
        ///         "EndAt": "25-06-2022",
        ///         "PromotionCode": "HELLO2022"
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request"></param>
        /// <response code = "200"> Create booking successfully.</response>
        /// <response code = "400"> 
        ///     Start station and end station are not exist. <br></br>
        ///     Start station is not exist. <br></br>
        ///     End station is not exist. <br></br>
        ///     Conflict about the time schedule with your other bookings. <br></br>
        ///     Promotion code is not available. <br></br>
        /// </response>
        /// <response code="500"> Failed to create booking.</response>
        [HttpPost("booking")]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            var user = LoggedInUser;

            var pairOfStation = await AppServices.Station.GetByCode(new List<Guid> { request.StartStationCode, request.EndStationCode });

            var inValidStationResponse = new Response
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            if (!pairOfStation.Any()) 
                return ApiResult(inValidStationResponse.SetMessage("Start station and end station are not exist."));

            var startStation = pairOfStation
                .Where(station => station.Code == request.StartStationCode)
                .FirstOrDefault();

            var endStation = pairOfStation
                .Where(station => station.Code == request.EndStationCode)
                .FirstOrDefault();     

            if (startStation == null) 
                return ApiResult(inValidStationResponse.SetMessage("Start station is not exist."));

            if (endStation == null) 
                return ApiResult(inValidStationResponse.SetMessage("End station is not exist."));

            var booking = new BookingDTO();

            try
            {
                booking = _mapper.Map<BookingDTO>(request);
            }
            catch (Exception e)
            {
                return ApiResult(new Response
                {
                    Message = e.Message,
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            booking.UserId = user.Id;
            booking.StartStationId = startStation.Id;
            booking.EndStationId = endStation.Id;

            var response = await AppServices.Booking.Create(
                                                    booking,
                                                    successResponse: new()
                                                    {
                                                        Message = "Create booking successfully.",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    duplicationResponse: new()
                                                    {
                                                        Message = "Conflict about the time schedule with your other bookings.",
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    },
                                                    invalidResponse: new()
                                                    {
                                                        Message = "Promotion code is not available.",
                                                        StatusCode = StatusCodes.Status400BadRequest
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
        [HttpGet("booking")]
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
        [HttpGet("booking/next-booking-detail")]
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
        [HttpGet("booking/route-fee")]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> GetRouteAndFee([FromQuery] GetRouteFeeRequest request)
        {
            var pairOfStation = await AppServices.Station.GetByCode(new List<Guid> { request.StartStationCode, request.EndStationCode });

            var inValidStationResponse = new Response
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            if (!pairOfStation.Any())
                return ApiResult(inValidStationResponse.SetMessage("Start station and end station are not exist."));

            var startStation = pairOfStation
                .Where(station => station.Code == request.StartStationCode)
                .FirstOrDefault();

            var endStation = pairOfStation
                .Where(station => station.Code == request.EndStationCode)
                .FirstOrDefault();

            if (startStation == null)
                return ApiResult(inValidStationResponse.SetMessage("Start station is not exist."));

            if (endStation == null)
                return ApiResult(inValidStationResponse.SetMessage("End station is not exist."));

            var response =
                await AppServices.Route.GetRouteByPairOfStation(
                    startStation.Id,
                    endStation.Id,
                    request.VehicleType,
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
        [HttpGet("booking/route-fee/multiple-routes")]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> GetRoutesAndFee([FromQuery] GetRouteFeeRequest request)
        {
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

            return Ok();
        }
    }
}
