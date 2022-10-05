using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class StationsController : BaseController<StationsController>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StationsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("nearby")]
        public async Task<IActionResult> GetStationNearby([FromQuery] CoordinatesDTO request)
        {
            var stationResponse =
                await AppServices.Station.GetNearByStationsByCoordinates(
                    request,
                    success: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Load nearby station successfully."
                    },
                    failed: new()
                    {
                        Message = "Load nearby station failed.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );
            return ApiResult(stationResponse);
        }

        /// <summary>
        /// Create list of stations
        /// </summary>
        /// ```
        /// Sample request:
        ///     POST api/stations
        ///     [
        ///         {
        ///             "Longitude": 106.768
        ///             "Latitude": 10.677,
        ///             "Name": "1"
        ///         },{
        ///             "Longitude": 106.708
        ///             "Latitude": 10.65,
        ///             "Name": "2"
        ///         },{
        ///             "Longitude": 106.77
        ///             "Latitude": 10.589,
        ///             "Name": "3"
        ///         }
        ///     ]
        /// ```
        /// <response code="200">Create successfully</response>
        /// <response code="400">
        ///     Exist duplicate stations coordinate in upload data <br/>
        ///     Exist duplicate stations coordinate 
        /// </response>
        /// <response code="500">Failure</response>
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Create([FromBody] List<CreateStationRequest> request)
        {
            var user = this.LoggedInUser;

            var stations = _mapper.Map<List<StationDTO>>(request);

            if (AppServices.Station.CheckDuplicateStations(stations))
            {
                return ApiResult(new Response
                {
                    Message = "Exist duplicate stations coordinate in upload data.",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var response = await AppServices.Station.Create(
                                        stations,
                                        user.Id,
                                        successResponse: new()
                                        {
                                            Message = "Create stations successfully.",
                                            StatusCode = StatusCodes.Status200OK
                                        },
                                        duplicateResponse: new()
                                        {
                                            Message = "Exist duplicate stations coordinate within database.",
                                            StatusCode = StatusCodes.Status400BadRequest
                                        },
                                        errorResponse: new()              
                                        {
                                            Message = "Fail to create stations.",
                                            StatusCode = StatusCodes.Status500InternalServerError
                                        }
                                    );
            return ApiResult(response);
        }

        /// <summary>
        /// Get list of stations - test api
        /// </summary>
        /// <response code="200">Get stations successfully</response>
        /// <response code="404">Not exist any stations</response>
        /// <response code="500">Failure</response>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] StartStationRequest request)
        {
            var response = await AppServices.Station.Get(
                                startStationCode: request.StartStationCode,
                                successResponse: new()
                                {
                                    Message = "Get stations successfully.",
                                    StatusCode = StatusCodes.Status200OK
                                });

            return ApiResult(response);
        }


    }
}
