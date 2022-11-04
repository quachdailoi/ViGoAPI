using API.Extensions;
using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Settings;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twilio.Rest.Api.V2010.Account;

namespace API.Controllers.V1.Driver
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "DRIVER")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DriversController : BaseController<DriversController>
    {
        private readonly IJwtHandler _jwtHandler;

        public DriversController(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        /// <summary>
        ///     Login by gmail which was register by admin.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/drivers/gmail/login
        ///     {
        ///         "IdToken": "..."
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Login successfully.</response>
        /// <response code = "400"> 
        ///     Login failed - Something went wrong. <br></br>
        ///     Not found email of driver account in our system.
        /// </response>
        [MapToApiVersion("1.0")]
        [HttpPost("gmail/login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailRequest request)
        {
            var authWithFireBaseResponse = await AppServices.User.GetEmailWithFireBaseAuthAsync(request);

            if (!authWithFireBaseResponse.Success) return ApiResult(authWithFireBaseResponse);

            var gmail = (string?) authWithFireBaseResponse.Data;

            if (string.IsNullOrEmpty(gmail)) throw new UnauthorizedAccessException();

            var user = await AppServices.Driver.GetUserViewModel(gmail, RegistrationTypes.Gmail);

            if (user == null)
            {
                return ApiResult(new()
                {
                    Message = "Not found email of driver account in our system.",
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
        ///     Send otp code to gmail and use otp to update account's gmail.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/drivers/gmail/send-otp-to-update
        ///     {
        ///         "Gmail": "loiqd.work@gmail.com"
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This gmail was verified by another account.</response>
        /// <response code = "500"> Fail to send otp to this gmail address.</response>
        [HttpPost("gmail/send-otp-to-update")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> SendGmailOtpToUpdate([FromBody] SendGmailOtpRequest request)
        {
            request.OtpTypes = OtpTypes.UpdateOTP;

            var genericRequest = request.ToGeneric();

            // check not existed verify gmail to send otp if EXIST return error response
            var existResponse =
                AppServices.Driver.CheckNotExisted(
                    genericRequest, 
                    errorResponse: new()
                    {
                        Message = "This gmail was verified by another account.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    isVerified: true
                );

            if (existResponse != null) return ApiResult(existResponse);

            // check valid time to send otp
            var checkValidResponse =
                await AppServices.VerifiedCode.CheckValidTimeSendOtp(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "Wait 1 minute since last sent, please.",
                        StatusCode = StatusCodes.Status400BadRequest
                    }
                );

            if (checkValidResponse != null) return ApiResult(checkValidResponse);

            // send and save otp code
            var sendAndSaveResponse =
                await AppServices.VerifiedCode.SendAndSaveOtp(
                    genericRequest,
                    successResponse: new()
                    {
                        Message = "Send Otp Successfully.",
                        StatusCode = StatusCodes.Status200OK
                    },
                    errorResponse: new()
                    {
                        Message = "Fail to send otp to this gmail address.",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Success = false
                    }
                );

            return ApiResult(sendAndSaveResponse);
        }

        /// <summary>
        ///     Update gmail with otp code which was send to it.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     PUT api/drivers/gmail
        ///     {
        ///         "Gmail": "loiqd.work@gmail.com",
        ///         "OTP: "123123"
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Update gmail successfully.</response>
        /// <response code = "400"> 
        ///     This gmail was belong to another verified account. <br></br>
        ///     Wrong OTP to update gmail. <br></br>
        ///     Expired OTP to update gmail.
        /// </response>
        /// <response code = "500"> Failed to update gmail.</response>
        [HttpPut("gmail")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> UpdateGmail([FromBody] VerifyGmailOtpRequest request)
        {
            request.OtpTypes = OtpTypes.UpdateOTP;

            var genericRequest = request.ToGeneric();

            var authenResponse = CheckLoggedInUserToGetAccount(RegistrationTypes.Phone, out UserViewModel? loggedInUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse =
                AppServices.Driver.CheckNotExisted(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "This gmail was belong to another verified account.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    isVerified: true
                );

            if (existResponse != null) return ApiResult(existResponse);

            // verify OTP
            var verifyResponse =
                await AppServices.VerifiedCode.VerifyOtp(
                    genericRequest,
                    wrongResponse: new()
                    {
                        Message = "Wrong OTP.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    expiredResponse: new()
                    {
                        Message = "Expired OTP.",
                        StatusCode = StatusCodes.Status400BadRequest
                    }
                );

            if (verifyResponse != null) return ApiResult(verifyResponse);

            var updateResult =
                await AppServices.Account.UpdateAccountRegistration(
                    account,
                    genericRequest, 
                    isVerified: true,
                    successResponse: new()
                    {
                        Message = "Update gmail successfully.",
                        StatusCode = StatusCodes.Status200OK
                    },
                    errorResponse: new()
                    {
                        Message = "Update gmail failed.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );

            return ApiResult(updateResult);
        }

        /// <summary>
        ///     Send otp code to phone number to verified it.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/drivers/phone/send-otp-to-verify
        ///     {
        ///         "PhoneNumber": "+84837226239"
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This phone number was verified by another account.</response>
        /// <response code = "500"> Fail to send otp to this phone number.</response>
        [HttpPost("phone/send-otp-to-verify")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> SendPhoneOtpToVerify([FromBody] SendPhoneOtpRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;

            var genericRequest = request.ToGeneric();

            // check not existed verified phone number to send otp if EXIST return error response
            var existResponse =
                AppServices.Driver.CheckNotExisted(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "This phone number was verified by another account.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    isVerified: true
                );

            if (existResponse != null) return ApiResult(existResponse);

            // check valid time to send otp
            var checkValidResponse =
                await AppServices.VerifiedCode.CheckValidTimeSendOtp(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "Wait 1 minute since last sent.",
                        StatusCode = StatusCodes.Status400BadRequest
                    }
                );

            if (checkValidResponse != null) return ApiResult(checkValidResponse);

            // send and save otp code
            var sendAndSaveResponse =
                await AppServices.VerifiedCode.SendAndSaveOtp(
                    genericRequest,
                    successResponse: new()
                    {
                        Message = "Send Otp Successfully.",
                        StatusCode = StatusCodes.Status200OK
                    },
                    errorResponse: new()
                    {
                        Message = "Fail to send otp to this phone number.",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Success = false
                    }
                );

            return ApiResult(sendAndSaveResponse);
        }

        /// <summary>
        ///     Verify phone number by otp code which was sent to it.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/drivers/phone/verify
        ///     {
        ///         "PhoneNumber": "+84837226239",
        ///         "OTP": "123123"
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Verify phone number successfully.</response>
        /// <response code = "400"> 
        ///     This phone numner was verified by another account. <br></br>
        ///     Wrong OTP to verify. <br></br>
        ///     Expired OTP to verify.
        /// </response>
        /// <response code = "500"> Failed to verify phone number.</response>
        [HttpPost("phone/verify")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> VerifyPhoneNumber([FromBody] VerifyPhoneOtpRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;

            var genericRequest = request.ToGeneric();

            var authenResponse = CheckLoggedInUserToGetAccount(RegistrationTypes.Gmail, out UserViewModel? loggedInUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse =
                AppServices.Driver.CheckNotExisted(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "This phone numner was verified by another account.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    isVerified: true
                );

            if (existResponse != null) return ApiResult(existResponse);

            // verify OTP
            var verifyResponse =
                await AppServices.VerifiedCode.VerifyOtp(
                    genericRequest,
                    wrongResponse: new()
                    {
                        Message = "Wrong OTP for verifying.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    expiredResponse: new()
                    {
                        Message = "Expired OTP for verifying.",
                        StatusCode = StatusCodes.Status400BadRequest
                    }
                );

            if (verifyResponse != null) return ApiResult(verifyResponse);

            // verify account
            var result =
                await AppServices.Account.VerifyAccount(
                    account,
                    successResponse: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Verify phone number successfully."
                    },
                    errorResponse: new()
                    {
                        Message = "Failed to verify phone number.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );

            return ApiResult(result);
        }

        /// <summary>
        ///     Update driver information with avatar is optional.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     PUT api/drivers/information
        ///     Name: Quach Dai Loi
        ///     Gender: 1,
        ///     DateOfBirth: 2000-01-31T17:56:43.179Z
        ///     PhoneNumber: +84837226239
        ///     Avatar: >>Choose a file (optional)
        /// ```
        /// </remarks>
        /// <response code = "200"> Update information successfully.</response>
        /// <response code="400"> This phone number was verified by another account.</response>
        /// <response code="500"> Something went wrong.</response>
        [HttpPut("information")]
        public async Task<IActionResult> UpdateInformation([FromForm] UpdateDriverInfoRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;

            var genericRequest = request.ToGeneric();

            var loggedInUser = LoggedInUser;

            var updateResponse =
                    await AppServices.Driver.UpdateDriverAccount(
                        loggedInUser.Code.ToString(),
                        genericRequest,
                        successResponse: new()
                        {
                            Message = "Update driver's information successfully, verification code was sent to your gmail.",
                            StatusCode = StatusCodes.Status200OK
                        },
                        duplicateReponse: new()
                        {
                            Message = "This gmail was verified by another account.",
                            StatusCode = StatusCodes.Status400BadRequest
                        },
                        failedResponse: new()
                        {
                            Message = "Failed to update driver's information.",
                            StatusCode = StatusCodes.Status500InternalServerError
                        }
                    );

            return ApiResult(updateResponse);
        }

        [HttpPost("gmail/loginFake")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginFake([FromForm] string gmail)
        {
            Response response = new();

            var user = await AppServices.Driver.GetUserViewModel(gmail, RegistrationTypes.Gmail);

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

        /// <summary>
        ///     Get driver's schedule by day paging.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/drivers/schedules
        ///     Page: 1,
        ///     PageSize: 3
        /// ```
        /// </remarks>
        /// <remarks>
        /// ```
        /// Note response:
        ///     Steps.Status (0: PickUp, 1: DropOff)
        /// ```
        /// </remarks>
        /// <response code = "200"> Get schedules of driver successfully.</response>
        [HttpGet("schedules")]
        public async Task<IActionResult> GetSchedules([FromQuery] PagingRequest pagingRequest, [FromQuery] DateFilterRequest dateFilterRequest)
        {
            var driver = LoggedInUser;

            var response = 
                await AppServices.BookingDetail.GetBookingsOfDriver(
                    driver.Id,
                    pagingRequest: pagingRequest,
                    dateFilterRequest: dateFilterRequest,
                    success: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Get schedules of driver successfully."
                    }
                );

            return ApiResult(response);
        }

        [HttpPut("booking-detail-drivers/start")]
        public async Task<IActionResult> StartRouteRoutine([FromBody] StartBookingDetailDriversRequest request)
        {
            var driver = LoggedInUser;

            // start update all booking detail drivers - trip status to Start
            var result = await AppServices.BookingDetailDriver.StartBookingDetailDrivers(request.BookingDetailDriverCodes);
            
            if (!result) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Failed to start booking detail driver."
            });

            var fcmTokens = AppServices.BookingDetailDriver.GetUserFCMTokens(request.BookingDetailDriverCodes);

            // send notification to users
            var message = new FirebaseAdmin.Messaging.Message()
            {
                Data = null,
                Notification = new FirebaseAdmin.Messaging.Notification()
                {
                    Title = "ViGo Notification",
                    Body = "Your driver is coming to pick you up."
                }
            };

            AppServices.Notification.SendPushNotifications(message, fcmTokens);

            // send signalR to users


            // send sms to phones

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Start booking detail driver successfully."
            });
        }

        /// <summary>
        ///     Update trip status of booking detail driver.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     PUT api/drivers/booking-detail-driver/trip-status
        ///     TripStatus: 1 (0: Not yet, 1: PickingUp, 2: Arrived, 3: Completed)
        /// ```
        /// </remarks>
        /// <remarks>
        /// ```
        /// 
        /// 
        /// 
        /// 
        /// ```
        /// </remarks>
        /// <response code = "200"> Update Trip Status Successfully.</response>
        /// <response code = "400"> 
        ///     Not found booking detail driver with this ID. <br></br>
        ///     This booking detail driver not belong to this Driver. <br></br>
        ///     New trip status not a valid next trip status.
        /// </response>
        /// <response code = "500"> Fail to update Trip Status for booking detail driver.</response>
        [HttpPut("booking-detail-driver/trip-status")]
        public async Task<IActionResult> UpdateTripStatus([FromBody] UpdateBookingDetailDriverTripStatusRequest request)
        {
            var driver = LoggedInUser;

            var bookingDetailDriver = await AppServices.BookingDetailDriver.GetBookingDetailDriverByCode(request.BookingDetailDriverCode);

            if (bookingDetailDriver == null) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Not found booking detail driver with this ID."
            });

            if (bookingDetailDriver.DriverId != driver.Id) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "This booking detail driver not belong to this Driver."
            });

            if (request.TripStatus != BookingDetailDrivers.TripStatus.Cancelled && 
                (int)request.TripStatus != (int)bookingDetailDriver.TripStatus + 1) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "New trip status not a valid next trip status."
            });

            var updateResult = await AppServices.BookingDetailDriver.UpdateTripStatus(bookingDetailDriver, request.TripStatus);

            if (!updateResult) return ApiResult(new()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Message = "Fail to update Trip Status for booking detail driver."
            });

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Update trip status for booking detail driver successfully."
            });
        }

        /// <summary>
        ///     Get driver's income by day paging.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     GET api/drivers/incomes
        ///     Page: 1,
        ///     PageSize: 3,
        ///     FromDate: ...,
        ///     ToDate: ...
        /// ```
        /// </remarks>
        /// <response code = "200"> Get imcomes of driver successfully.</response>
        [HttpGet("incomes")]
        public async Task<IActionResult> GetIncome([FromQuery] PagingRequest pagingRequest, [FromQuery] DateFilterRequest dateFilterRequest)
        {
            var driver = LoggedInUser;

            var incomes = AppServices.Driver.GetIncome(driver.Id, dateFilterRequest.FromDate, dateFilterRequest.ToDate, pagingRequest);

            return ApiResult(new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Get Driver's income success fully",
                Data = incomes,
            });
        }
    }
}