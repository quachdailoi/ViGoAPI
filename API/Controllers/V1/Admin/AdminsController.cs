using API.Extensions;
using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Settings;
using Domain.Shares.Enums;
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
        ///     GET api/admins/finance
        ///     {
        ///         "FromDate": "01/01/2022",
        ///         "ToDate": "05/05/2022"
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Get finance information successfully.</response>
        [HttpGet("finance")]
        public async Task<IActionResult> GetFinance([FromQuery] DateFilterRequest request)
        {
            var finance = await AppServices.Wallet.GetFinance(request);

            return ApiResult(new Response
            {
                Data = finance,
                Message = "Get finance information successfully.",
                StatusCode = StatusCodes.Status200OK
            });
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

            return Ok();
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
        ///         "Status": 1, // 0: Pending, 1: Processed, 2: ProcessingDenied
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
    }
}
