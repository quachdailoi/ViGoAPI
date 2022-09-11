using API.Extensions;
using API.JwtFeatures;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Models.Settings;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1.Booker
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "BOOKER")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BookersController : BaseController<BookersController>
    {

        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;

        public BookersController(IMapper mapper, IJwtHandler jwtHandler)
        {
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        /// <summary>
        /// Send otp code to phone, which was used to login.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/bookers/phone/send-otp-to-login
        ///     PhoneNumber: +84837226239
        /// ```
        /// </remarks>
        /// <response code = "200"> Send otp code successfully.</response>
        /// <response code = "400"> Not found account with this phone number to send login otp.</response>
        /// <response code = "500"> Fail to send code to this phone number.</response>
        [HttpPost("phone/send-otp-to-login")]
        [AllowAnonymous]
        public async Task<IActionResult> SendPhoneOtpToLogin([FromForm] SendPhoneOtpRequest request)
        {
            request.OtpTypes = OtpTypes.LoginOTP;

            var genericRequest = request.ToGeneric();

            // check existed verified phone number to send otp if NOT return error response
            var notExistResponse =
                AppServices.Booker.CheckExisted(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "Not found account with this phone number to send login otp.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    isVerified: true
                );

            if (notExistResponse != null) return ApiResult(notExistResponse);

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
                        Message = "Fail to send code to this phone number.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );

            return ApiResult(sendAndSaveResponse);
        }

        /// <summary>
        /// Login by otp code, which was sent to phone.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/bookers/phone/login
        ///     PhoneNumber: +84837226239
        ///     OTP: 123456
        /// ```
        /// </remarks>
        /// <response code = "200"> Login successfully.</response>
        /// <response code = "400"> 
        ///     Wrong OTP to login.<br></br>
        ///     Expired OTP to login.<br></br>
        ///     Not found phone of booker account in our system.
        /// </response>
        [HttpPost("phone/login")]
        [AllowAnonymous]
        public async Task<IActionResult> PhoneLogin([FromForm] VerifyPhoneOtpRequest request)
        {
            request.OtpTypes = OtpTypes.LoginOTP;

            var genericRequest = request.ToGeneric();

            Response response = new();

            var loginFailedResponse =
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

            if (loginFailedResponse != null) return ApiResult(loginFailedResponse);

            var user = await AppServices.Booker.GetUserViewModel(genericRequest);

            if (user == null)
            {
                response.SetStatusCode(StatusCodes.Status400BadRequest)
                    .SetMessage("Not found phone of booker account in our system.");
                return Unauthorized(response);
            }

            string token = _jwtHandler.GenerateToken(user);
            string refreshToken = await _jwtHandler.GenerateRefreshToken(user.Code.ToString());

            response.SetStatusCode(StatusCodes.Status200OK)
                .SetMessage("Login successfully.")
                .SetData(new LoginSuccessViewModel
                {
                    AccessToken = token,
                    AccessTokenExpiredTime = DateTimeOffset.Now.AddMinutes(Configuration.Get<double>(JwtSettings.AccessTokenTTLMinutes)),
                    RefreshToken = refreshToken,
                    RefreshTokenExpiredTime = DateTimeOffset.Now.AddDays(Configuration.Get<double>(JwtSettings.RefreshTokenTTLDays)),
                    User = user
                });

            return ApiResult(response);
        }

        /// <summary>
        ///     Send otp code to gmail to verified it.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/bookers/gmail/send-otp-to-verify
        ///     Gmail: loiqd.work@gmail.com
        /// ```
        /// </remarks>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This email was verified by another account.</response>
        /// <response code = "500"> Fail to send otp to this gmail.</response>
        [HttpPost("gmail/send-otp-to-verify")]
        public async Task<IActionResult> SendGmailOtpToVerify([FromForm] SendGmailOtpRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;

            var genericRequest = request.ToGeneric();

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse =
                AppServices.Booker.CheckNotExisted(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "This email was verified by another account.",
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
                        Message = "Fail to send otp to this gmail.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );

            return ApiResult(sendAndSaveResponse);
        }

        /// <summary>
        ///     Verify gmail by otp code which was sent to it.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/bookers/gmail/verify
        ///     Gmail: loiqd.work@gmail.com
        ///     OTP: 123456
        /// ```
        /// </remarks>
        /// <response code = "200"> Verify gmail successfully.</response>
        /// <response code = "400"> 
        ///     This email was verified by another account. <br></br>
        ///     Wrong OTP to verify. <br></br>
        ///     Expired OTP to verify.
        /// </response>
        /// <response code = "500"> Failed to verify gmail.</response>
        [HttpPost("gmail/verify")]
        public async Task<IActionResult> VerifyGmail([FromForm] VerifyGmailOtpRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;

            var genericRequest = request.ToGeneric();

            var authenResponse = CheckLoginedUserToGetAccount(RegistrationTypes.Gmail, out UserViewModel? loginedUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse =
                AppServices.Booker.CheckNotExisted(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "This email was verified by another account.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    isVerified: true
                );

            if (existResponse != null) return ApiResult(existResponse);

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

            // verify account
            var result =
                await AppServices.Account.VerifyAccount(
                    account,
                    successResponse: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Verify gmail successfully."
                    },
                    errorResponse: new()
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = "Failed to verify gmail."
                    }
                );
            return ApiResult(result);
        }

        /// <summary>
        ///     Send otp code to phone and use otp to update account's phone number.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/bookers/phone/send-otp-to-update
        ///     PhoneNumber: +84837226239
        /// ```
        /// </remarks>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This phone number was verified by another account.</response>
        /// <response code = "500"> Fail to send otp to this phone number.</response>
        [HttpPost("phone/send-otp-to-update")]
        public async Task<IActionResult> SendPhoneOtpForUpdate([FromForm] SendPhoneOtpRequest request)
        {
            request.OtpTypes = OtpTypes.UpdateOTP;

            var genericRequest = request.ToGeneric();

            // check not existed verified phone number to send otp if EXIST return error response 
            var existResponse =
                AppServices.Booker.CheckNotExisted(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "This phone number was belong to another verified account.",
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
                        Message = "Wait 1 minute since last sent",
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
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );

            return ApiResult(sendAndSaveResponse);
        }

        /// <summary>
        ///     Update phone number with otp code which was send to it.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     PUT api/bookers/phone
        ///     PhoneNumber: +84837226239
        ///     OTP: 123123
        /// ```
        /// </remarks>
        /// <response code = "200"> Update phone number successfully.</response>
        /// <response code = "400"> 
        ///     This phone number was belong to another verified account. <br></br>
        ///     Wrong OTP to update phone number. <br></br>
        ///     Expired OTP to update phone number.
        /// </response>
        /// <response code = "500"> Failed to update phone number.</response>
        [HttpPut("phone")]
        public async Task<IActionResult> UpdatePhone([FromForm] VerifyPhoneOtpRequest request)
        {
            request.OtpTypes = OtpTypes.UpdateOTP;

            var genericRequest = request.ToGeneric();

            var authenResponse = CheckLoginedUserToGetAccount(RegistrationTypes.Phone, out UserViewModel? loginedUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified phone number to send otp if EXIST return error response
            var existResponse =
                AppServices.Booker.CheckNotExisted(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "This phone number was belong to another verified account.",
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
                        Message = "Update phone number successfully.",
                        StatusCode = StatusCodes.Status200OK
                    },
                    errorResponse: new()
                    {
                        Message = "Failed to update phone number.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );

            return ApiResult(updateResult);
        }

        /// <summary>
        ///     Update user's information with avatar is optional.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     PUT api/bookers/information
        ///     Name: Quach Dai Loi
        ///     Gender: 1
        ///     DateOfBirth: 2000-01-31T17:56:43.179Z
        ///     Gmail: loiqd.work@gmail.com
        ///     Avatar: >>Choose a file (optional)
        /// ```
        /// </remarks>
        /// <response code = "200"> Updated user's information successfully.</response>
        /// <response code="400"> This gmail was verified by another account.</response>
        /// <response code="500"> Failed to update user's information.</response>
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(200 * 1024 * 1024)]
        [HttpPut("information")]
        public async Task<IActionResult> UpdateInformation([FromForm] UpdateBookerInfoRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;

            var genericRequest = request.ToGeneric();

            var loginedUser = LoggedInUser;

            var updateResponse =
                    await AppServices.Booker.UpdateBookerAccount(
                        loginedUser.Code.ToString(),
                        genericRequest,
                        successResponse: new()
                        {
                            Message = "Updated user's information successfully.",
                            StatusCode = StatusCodes.Status200OK
                        },
                        duplicateReponse: new()
                        {
                            Message = "This gmail was verified by another account.",
                            StatusCode = StatusCodes.Status400BadRequest
                        },
                        failedResponse: new()
                        {
                            Message = "Failed to update user's information.",
                            StatusCode = StatusCodes.Status500InternalServerError
                        }
                    );

            return ApiResult(updateResponse);
        }

        [HttpPost("phone/loginFake")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginFake([FromForm] string phoneNumber)
        {
            Response response = new();

            var user = await AppServices.Booker.GetUserViewModel(phoneNumber, RegistrationTypes.Phone);

            if (user == null)
            {
                response.SetStatusCode(StatusCodes.Status500InternalServerError)
                    .SetMessage("Login failed - not found user with this phone number");
                return ApiResult(response);
            }

            string token = _jwtHandler.GenerateToken(user);
            string refreshToken = await _jwtHandler.GenerateRefreshToken(user.Code.ToString());

            response.SetStatusCode(StatusCodes.Status200OK)
                .SetMessage("Login successfully.")
                .SetData(new LoginSuccessViewModel
                {
                    AccessToken = token,
                    AccessTokenExpiredTime = DateTimeOffset.Now.AddMinutes(Configuration.Get<double>(JwtSettings.AccessTokenTTLMinutes)),
                    RefreshToken = refreshToken,
                    RefreshTokenExpiredTime = DateTimeOffset.Now.AddDays(Configuration.Get<double>(JwtSettings.RefreshTokenTTLDays)),
                    User = user,
                });

            return ApiResult(response);
        }

        [HttpGet("test")]
        [MapToApiVersion("1.0")]
        public IActionResult TestAuthen()
        {
            var user = LoggedInUser;
            return Ok(user);
        }

        /// <summary>
        ///     Send otp code to phone and use otp to register account.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/bookers/phone/send-otp-to-register
        ///     PhoneNumber: +84837226239
        /// ```
        /// </remarks>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This phone number was verified by another account.</response>
        /// <response code = "500"> Fail to send otp to this phone number.</response>
        [HttpPost("phone/send-otp-to-register")]
        [AllowAnonymous]
        public async Task<IActionResult> SendOtpToRegister([FromForm] SendPhoneOtpRequest request)
        {
            request.OtpTypes = OtpTypes.RegisterOTP;

            var genericRequest = request.ToGeneric();

            // check not existed verified phone number to send otp if EXIST return error response 
            var existResponse =
                AppServices.Booker.CheckNotExisted(
                    genericRequest,
                    errorResponse: new()
                    {
                        Message = "This phone number was belong to another verified account.",
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
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );

            return ApiResult(sendAndSaveResponse);
        }

        /// <summary>
        ///     Register account.
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/bookers 
        ///     {
        ///         "PhoneNumber": "+84837226239",
        ///         "OTP": "123456",
        ///         "Gmail": "loiqd.work@gmail.com",
        ///         "Name": "Quach Dai Loi"
        ///     }
        /// ```
        /// </remarks>
        /// <param name="request"></param>
        /// <response code = "200"> Register account successfully.</response>
        /// <response code="400"> 
        ///     Wrong OTP to register. <br></br>
        ///     Expired OTP to regiser <br></br>
        ///     Register account failed - This phone number was register by another account.
        /// </response>
        /// <response code="500"> Failed to register account.</response>
        [HttpPost()]
        [AllowAnonymous]
        [Produces("application/json")]
        public async Task<IActionResult> Register([FromBody] BookerRegisterRequest request)
        {
            request.OtpTypes = OtpTypes.RegisterOTP;

            var genericRequest = request.ToGeneric();

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

            var createResponse =
                await AppServices.Booker.CreateBookerAccount(
                    genericRequest,
                    successResponse: new()
                    {
                        Message = "Register account successfully.",
                        StatusCode = StatusCodes.Status200OK
                    },
                    duplicatedRegistrationResponse: new()
                    {
                        Message = "Register account failed - This phone number was register by another account.",
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    failedResponse: new()
                    {
                        Message = "Failed to register account.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );
            return ApiResult(createResponse);
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
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            var user = LoggedInUser;

            var booking = new BookingDTO();

            try
            {
                booking = _mapper.Map<BookingDTO>(request);
            }
            catch(Exception e)
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
        public async Task<IActionResult> GetBooking()
        {
            var user = LoggedInUser;

            var response = await AppServices.Booking.GetAll(
                                            user.Id,
                                            successReponse: new()
                                            {
                                                Message = "Get bookings successfully.",
                                                StatusCode = StatusCodes.Status200OK
                                            },
                                            notFoundResponse: new()
                                            {
                                                Message = "Not exist any bookings with this user.",
                                                StatusCode = StatusCodes.Status404NotFound
                                            }
                                            );
            return ApiResult(response);
        }

        /// <summary>
        ///     Get next trip of this user.
        /// </summary>
        /// <response code = "200"> Get bookings successfully.</response>
        /// <response code = "404"> Not found any bookings.</response>
        /// <response code="500"> Failed to get bookings.</response>
        [HttpGet("booking/next-booking-detail")]
        public async Task<IActionResult> GetNextTrip()
        {
            var user = LoggedInUser;

            var response = await AppServices.BookingDetail.GetNextBookingDetail(
                                            user.Id,
                                            successResponse: new()
                                            {
                                                Message = "Get next trip successfully.",
                                                StatusCode = StatusCodes.Status200OK
                                            },
                                            notFoundResponse: new()
                                            {
                                                Message = "Not exist any trips in next time.",
                                                StatusCode = StatusCodes.Status404NotFound
                                            }
                                            );

            return ApiResult(response);
        }
    }
}