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
        ///         "StartPoint": {
        ///             "Longitude": 106.78967,
        ///             "Latitude": 10.858,
        ///             "LocationName":"Trạm 1"
        ///         },
        ///         "EndPoint": {
        ///             "Longitude": 106.7008,
        ///             "Latitude": 10.798,
        ///             "LocationName": "12, đường D2, phường Tăng Nhơn Phú A, thành phố Thủ Đức, thành phố Hồ Chí Minh"
        ///         },
        ///         "Time": "04:30:00",
        ///         "Days": {
        ///              "DaysOfWeek": [],
        ///              "DaysOfMonth": [1,4,6,29,30,31],
        ///              "IgnoreDaysByMonth": { "2": [29,30,31], "4": [31] },
        ///              "AdditionalDaysByMonth": { "3": [1,2,3], "5": [1]}
        ///         },
        ///         "StartAt": "15-02-2022" ,
        ///         "EndAt": "25-06-2022",
        ///         "IsShared": true,
        ///         "Option": 0,
        ///         "Type": 0 (0 if monthly or 1 if weekly)
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request"></param>
        /// <response code = "200"> Create booking successfully.</response>
        /// <response code = "400"> Conflict about the time schedule with your other bookings.</response>
        /// <response code="500"> Failed to create booking.</response>
        [HttpPost("booking")]
        [Authorize(Roles = "BOOKER")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            var user = LoggedInUser;

            var booking = new BookingDTO();

            try
            {
                booking = _mapper.Map<BookingDTO>(request);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            booking.UserId = user.Id;

            var response = await AppServices.Booking.Create(
                                                    booking,
                                                    successResponse: new()
                                                    {
                                                        Message = "Create booking successfully.",
                                                        StatusCode = StatusCodes.Status200OK
                                                    },
                                                    duplicationResponse: new()
                                                    {
                                                        Message = "Your booking conflicts about the time schedule with your other bookings.",
                                                        StatusCode = StatusCodes.Status400BadRequest
                                                    },
                                                    invalidResponse: new()
                                                    {
                                                        Message = "Your promotion is invalid.",
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

        [HttpGet("booking/route-fee")]
        public async Task<IActionResult> GetRouteAndFee([FromQuery] GetRouteFeeRequest request)
        {
            var stations = await AppServices.Station.GetByCode(new List<Guid> { request.StartStationCode, request.EndStationCode });

            if(stations == null || stations.Count() != 2)
            {
                return ApiResult(new Response
                {
                    Message = "These stations are not exist",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var startStation = stations.Where(station => station.Code == request.StartStationCode).First();

            var endStation = stations.Where(station => station.Code == request.StartStationCode).First();

            var response =
                await AppServices.Route.GetRouteByPairOfStation(
                    startStation.Id,
                    endStation.Id,
                    successResponse: new()
                    {
                        Message = "Get route successfully",
                        StatusCode= StatusCodes.Status200OK
                    });

            return ApiResult(response);
        }

        [HttpGet("booking/route-fee/multiple-routes")]
        public async Task<IActionResult> GetRoutesAndFee([FromQuery] GetRouteFeeRequest request)
        {
            var stations = await AppServices.Station.GetByCode(new List<Guid> { request.StartStationCode, request.EndStationCode });

            if (stations == null || stations.Count() != 2)
            {
                return ApiResult(new Response
                {
                    Message = "These stations are not exist",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var startStation = stations.Where(station => station.Code == request.StartStationCode).First();

            var endStation = stations.Where(station => station.Code == request.StartStationCode).First();

            var response =
                await AppServices.Route.GetRouteByPairOfStation(
                    startStation.Id,
                    endStation.Id,
                    successResponse: new()
                    {
                        Message = "Get routes successfully",
                        StatusCode = StatusCodes.Status200OK
                    });

            return ApiResult(response);
        }
    }
}
