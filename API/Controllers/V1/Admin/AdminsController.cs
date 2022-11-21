﻿using API.Extensions;
using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Settings;
using API.Validators;
using Domain.Shares.Enums;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1.Admin
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AdminsController : BaseController<AdminsController>
    {
        private readonly IJwtHandler _jwtHandler;

        public AdminsController(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        /// <summary>
        ///     Login by admin gmail.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/admins/gmail/login
        ///     {
        ///         "IdToken": "..."
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Login successfully.</response>
        /// <response code = "400"> 
        ///     Login failed - Something went wrong. <br></br>
        ///     Not found email of admin account in our system.
        /// </response>
        [MapToApiVersion("1.0")]
        [HttpPost("gmail/login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailRequest request)
        {
            var authWithFireBaseResponse = await AppServices.User.GetEmailWithFireBaseAuthAsync(request);

            if (!authWithFireBaseResponse.Success) return ApiResult(authWithFireBaseResponse);

            var gmail = (string?)authWithFireBaseResponse.Data;

            if (string.IsNullOrEmpty(gmail)) throw new UnauthorizedAccessException();

            var user = await AppServices.Admin.GetUserViewModel(gmail, RegistrationTypes.Gmail);

            if (user == null)
            {
                return ApiResult(new()
                {
                    Message = "Not found email of admin account in our system.",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            await AppServices.User.CheckValidUserToLogin(user, RegistrationTypes.Gmail);

            string token = _jwtHandler.GenerateToken(user);
            string refreshToken = await _jwtHandler.GenerateRefreshToken(user.Code.ToString());

            return ApiResult(new()
            {
                Message = "Login successfully.",
                StatusCode = StatusCodes.Status200OK,
                Data = new LoginSuccessViewModel
                {
                    AccessToken = token,
                    AccessTokenExpiredTime = DateTimeOffset.Now.AddMinutes(Configuration.Get<double>(JwtSettings.AccessTokenTTLMinutes)),
                    RefreshToken = refreshToken,
                    RefreshTokenExpiredTime = DateTimeOffset.Now.AddDays(Configuration.Get<double>(JwtSettings.RefreshTokenTTLDays)),
                    User = user
                }
            });
        }

        /// <summary>
        ///     Get system finance information
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/admins/dashboard
        ///     {
        ///         "FromMonth": "05-2022",
        ///         "ToMonth": "11-2022"
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Get finance information successfully.</response>
        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardInfo([FromQuery] MonthFilterRequest request)
        {
            var response = await AppServices.Wallet.GetDashboardInfo(
                request,
                successReponse: new()
                {
                    Message = "Get finance information successfully.",
                    StatusCode = StatusCodes.Status200OK
                });

            return ApiResult(response);
        }

        /// <summary>
        ///     Get reports
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/admins/reports
        ///     {
        ///         "Page": 1,
        ///         "PageSize": 10,
        ///         "Status": 0, // 0: Pending, 1: Processed, 2: ProcessingDenied (nullable)
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Get reports successfully.</response>
        [HttpGet("reports")]
        public async Task<IActionResult> GetReports([FromQuery] PagingRequest pagingRequest, Reports.Status? Status = null)
        {
            var response = await AppServices.Report.Get(
                pagingRequest,
                status: Status,
                response: new()
                {
                    Message = "Get reports successfully.",
                    StatusCode = StatusCodes.Status200OK
                });

            return ApiResult(response);
        }

        /// <summary>
        ///     Update report status
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     PUT api/admins/report
        ///     {
        ///         "Code": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///         "Status": 2, // 1: Pending, 2: Processed, 3: ProcessingDenied
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200">Update report status successfully.</response>
        /// <response code = "400">Report is not exist.</response>
        /// <response code = "500">Fail to update report status.</response>
        [HttpPut("report")]
        public async Task<IActionResult> UpdateReportStatus([FromBody] UpdateReportStatusRequest request)
        {
            var result = await AppServices.Report.UpdateStatus(request.Code, request.Status);

            var response = new Response();

            if (!result.HasValue)
                response = new Response
                {
                    Message = "Report is not exist.",
                    StatusCode = StatusCodes.Status400BadRequest
                };

            else if (result.Value)
                response = new Response
                {
                    Message = "Update report status successfully.",
                    StatusCode = StatusCodes.Status200OK
                };
            else response = new Response
            {
                Message = "Fail to update report status.",
                StatusCode = StatusCodes.Status500InternalServerError
            };

            return ApiResult(response);
        }

        /// <summary>
        ///     Get report data
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/admins/report/data
        ///     {
        ///         "Code": "5592d1e0-a96a-4cca-967e-9cd0eb130657",
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200">Get report data successfully.</response>
        /// <response code = "204">Report data is not exist.</response>
        [HttpGet("report/data")]
        public async Task<IActionResult> GetReportData([FromQuery] GetReportDataRequest request)
        {
            var response = await AppServices.Report.GetData(
                request.Code,
                successResponse: new()
                {
                    Message = "Get report data successfully.",
                    StatusCode = StatusCodes.Status200OK
                },
                notFoundResponse: new()
                {
                    Message = "Report data is not exist.",
                    StatusCode = StatusCodes.Status204NoContent
                }
                );

            return ApiResult(response);
        }

        /// <summary>
        ///     Get system's settings
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/admins/settings
        /// ```
        /// </remarks>
        /// <response code = "200">Get report data successfully.</response>
        [HttpGet("settings")]
        public async Task<IActionResult> GetSettings()
        {
            var response = await AppServices.Setting.GetAll(new Response
            {
                Message = "Get settings successfully.",
                StatusCode = StatusCodes.Status200OK
            });

            return ApiResult(response);
        }

        /// <summary>
        ///     Update system's settings
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/admins/settings
        ///     {
        ///         [
        ///             {key , "value"} // key: setting's id 
        ///         ]
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200">Get report data successfully.</response>
        [HttpPost("settings")]
        public async Task<IActionResult> UpdateSettings(UpdateSettingRequest request)
        {
            var result = await AppServices.Setting.Update(request.Settings);

            if (!result)
                return ApiResult(new Response
                {
                    Message = "Fail to update settings.",
                    StatusCode = StatusCodes.Status500InternalServerError
                });

            return ApiResult(new Response
            {
                Message = "Update settings successfully.",
                StatusCode = StatusCodes.Status200OK
            });
        }


        [HttpPost("gmail/loginFake")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginFake([FromForm] string gmail)
        {
            Response response = new();

            var user = await AppServices.Admin.GetUserViewModel(gmail, RegistrationTypes.Gmail);

            if (user == null)
            {
                response.SetStatusCode(StatusCodes.Status500InternalServerError)
                    .SetMessage("Login failed - not found user with this gmail");
                return ApiResult(response);
            }

            string token = _jwtHandler.GenerateToken(user);
            string refreshToken = await _jwtHandler.GenerateRefreshToken(user.Code.ToString());

            response.SetStatusCode(StatusCodes.Status200OK)
                .SetMessage("Login successfully.")
                .SetData(new LoginSuccessViewModel
                {
                    AccessToken = token,
                    RefreshToken = refreshToken,
                    User = user
                });

            return ApiResult(response);
        }

        [HttpGet("test")]
        public IActionResult TestAuthen()
        {
            var user = LoggedInUser;
            return Ok(user);
        }

        [HttpGet("driver-registraions")]
        public IActionResult GetDriverRegistrations([FromQuery] PagingRequest pagingRequest)
        {
            var pendingDrivers = AppServices.Driver.GetPendingDriverPaging(pagingRequest);

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Get pending driver successfully.",
                Data = pendingDrivers
            });
        }

        [HttpPut("driver-registrations/{userCode}")]
        public async Task<IActionResult> UpdateDriverRegistration(string userCode, [FromForm] UpdateDriverRegistrationRequest request, [FromForm] Users.Status status)
        {
            var pendingDriver = await AppServices.Driver.GetPendingDriverByCode(userCode);

            if (pendingDriver == null)
                throw new ValidationException("Not found pending driver with this code.");

            //validate request
            var validationErrorMsg = request.Validate(AppServices, pendingDriver);
            if (validationErrorMsg != null) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = validationErrorMsg
            });

            var driver = await AppServices.Driver.UpdateDriverRegistration(pendingDriver, request, status);

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Update driver registration successfully.",
                Data = driver
            });
        }

        /// <summary>
        ///     Search driver by status and search value, with search value is a part of Code or Name or Phone Number or Gmail
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     Get api/admins/drivers
        ///     SearchValue: abc
        ///     Status: 1 (0: Inactive, 1: Active, 2: Pending, 3: Rejected)
        ///     Page: 1
        ///     PageSize: 5
        /// ```
        /// </remarks>
        /// <response code = "200">Get driver successfully.</response>
        [HttpGet("drivers")]
        public IActionResult SearchDriver([FromQuery] SearchDriverRequest request)
        {
            var drivers = AppServices.Driver.GetDrivers(request.SearchValue, request.Status, request.Paging);

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Get drivers successfully.",
                Data = drivers
            });
        }

        /// <summary>
        ///     Search station by search value, with search value is a part of Code or Name or Address
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     Get api/admins/stations
        ///     SearchValue: abc
        ///     Page: 1
        ///     PageSize: 5
        /// ```
        /// </remarks>
        /// <response code = "200">Get stations successfully.</response>
        [HttpGet("stations")]
        public IActionResult SearchStations([FromQuery] SearchStationRequest request)
        {
            var stations = AppServices.Station.GetStations(request.SearchValue, request.Paging);

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Get stations successfully.",
                Data = stations
            });
        }

        /// <summary>
        ///     Search routes by search value, with search value is a part of Code or Name or a part of Station Name or Station Address
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     Get api/admins/routes
        ///     SearchValue: abc
        ///     Page: 1
        ///     PageSize: 5
        /// ```
        /// </remarks>
        /// <response code = "200">Get routes successfully.</response>
        [HttpGet("routes")]
        public IActionResult SearchRoutes([FromQuery] SearchRouteRequest request)
        {
            var routes = AppServices.Route.GetRoutes(request.SearchValue, request.Paging);

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Get routes successfully.",
                Data = routes
            });
        }
    }
}
