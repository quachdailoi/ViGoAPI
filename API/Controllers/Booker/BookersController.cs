using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Booker
{
    [Route("api/[controller]")]
    [Authorize(Roles = "BOOKER")]
    [ApiController]
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
        /// <remarks>SendOtpToLogin</remarks>
        /// <param name="request" example="{Registration: '+84837226239'}">Send Otp Request Schema</param>
        /// <response code = "200"> Send otp code successfully.</response>
        /// <response code = "400"> Not found account with this phone number to send login otp.</response>
        /// <response code = "500"> Fail to send code to this phone number.</response>
        [HttpPost("phone/send-otp-to-login")]
        [AllowAnonymous]
        public async Task<IActionResult> SendPhoneOtpToLogin([FromBody] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.LoginOTP;
            request.RegistrationTypes = RegistrationTypes.Phone;

            // check existed verified phone number to send otp if NOT return error response
            var notExistResponse = 
                AppServices.Booker.CheckExisted(
                    request, 
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
                    request, 
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
                    request, 
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
        /// <remarks>PhoneLogin</remarks>
        /// <param name="request" example="{Registration: '+84837226239', OTP: '123123'}">Verify Otp Request Schema</param>
        /// <response code = "200"> Login successfully.</response>
        /// <response code = "400"> Wrong or Expired OTP.</response>
        /// <response code = "400"> Not found phone of booker account in our system.</response>
        [HttpPost("phone/login")]
        [AllowAnonymous]
        public async Task<IActionResult> PhoneLogin([FromBody] VerifyOtpRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Phone;
            request.OtpTypes = OtpTypes.LoginOTP;

            Response response = new();

            var loginFailedResponse = 
                await AppServices.VerifiedCode.VerifyOtp(
                    request, 
                    errorResponse: new()
                    {
                        Message = "Wrong or Expired OTP.", 
                        StatusCode = StatusCodes.Status400BadRequest
                    }
                );

            if (loginFailedResponse != null) return ApiResult(loginFailedResponse);

            var user = await AppServices.Booker.GetUserViewModel(request);

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
                    RefreshAccessToken = refreshToken,
                    User = user
                });

            return ApiResult(response);
        }

        /// <summary>
        /// Send otp code to gmail to verified it.
        /// </summary>
        /// <remarks>SendGmailOtpToVerify</remarks>
        /// <param name="request" example="{Registration: 'abc@gmail.com'}">Send Otp Request Schema</param>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This email was verified by another account.</response>
        /// <response code = "500"> Fail to send otp to this gmail.</response>
        [HttpPost("gmail/send-otp-to-verify")]
        public async Task<IActionResult> SendGmailOtpToVerify([FromBody] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;
            request.RegistrationTypes = RegistrationTypes.Gmail;

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse = 
                AppServices.Booker.CheckNotExisted(
                    request, 
                    errorResponse: new()
                    {
                        Message = "This email was verified by another account.", 
                        StatusCode = StatusCodes.Status400BadRequest
                    },
                    isVerified:true
                );

            if (existResponse != null) return ApiResult(existResponse);

            // check valid time to send otp
            var checkValidResponse = 
                await AppServices.VerifiedCode.CheckValidTimeSendOtp(
                    request, 
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
                    request, 
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
        /// Verify gmail by otp code which was sent to it.
        /// </summary>
        /// <remarks>VerifyGmail</remarks>
        /// <param name="request" example="{Registration: 'abc@gmail.com', OTP: '123123'}">Verify Otp Request Schema</param>
        /// <response code = "200"> Verify gmail successfully.</response>
        /// <response code = "400"> This email was verified by another account.</response>
        /// <response code = "400"> Wrong or Expired OTP.</response>
        /// <response code = "500"> Failed to verify gmail.</response>
        [HttpPost("gmail/verify")]
        public async Task<IActionResult> VerifyGmail([FromBody] VerifyOtpRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Gmail;
            request.OtpTypes = OtpTypes.VerificationOTP;

            var authenResponse = CheckLoginedUserToGetAccount(RegistrationTypes.Gmail, out UserViewModel? loginedUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse = 
                AppServices.Booker.CheckNotExisted(
                    request, 
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
                    request, 
                    errorResponse: new()
                    {
                        Message = "Wrong or Expired OTP.", 
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
        /// Send otp code to phone and use otp to update account's phone number.
        /// </summary>
        /// <remarks>SendPhoneOtpForUpdate</remarks>
        /// <param name="request" example="{Registration: '+84837226239'}">Send Otp Request Schema</param>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This phone number was verified by another account.</response>
        /// <response code = "500"> Fail to send otp to this phone number.</response>
        [HttpPost("phone/send-otp-to-update")]
        public async Task<IActionResult> SendPhoneOtpForUpdate([FromBody] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.UpdateOTP; 
            request.RegistrationTypes = RegistrationTypes.Phone; 

            // check not existed verified phone number to send otp if EXIST return error response 
            var existResponse = 
                AppServices.Booker.CheckNotExisted( 
                    request, 
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
                    request,
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
                    request,
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
        /// Update phone number with otp code which was send to it.
        /// </summary>
        /// <remarks>UpdatePhone</remarks>
        /// <param name="request" example="{Registration: '+84837226239', OTP: '123123'}">Verify Otp Request Schema</param>
        /// <response code = "200"> Update phone number successfully.</response>
        /// <response code = "400"> This phone number was belong to another verified account.</response>
        /// <response code = "400"> Wrong or Expired OTP.</response>
        /// <response code = "500"> Failed to update phone number.</response>
        [HttpPut("phone")]
        public async Task<IActionResult> UpdatePhone([FromBody] VerifyOtpRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Phone;
            request.OtpTypes = OtpTypes.UpdateOTP;

            var authenResponse = CheckLoginedUserToGetAccount(RegistrationTypes.Phone, out UserViewModel? loginedUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified phone number to send otp if EXIST return error response
            var existResponse =
                AppServices.Booker.CheckNotExisted(
                    request,
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
                    request,
                    errorResponse: new()
                    {
                        Message = "Wrong or Expired OTP.",
                        StatusCode = StatusCodes.Status400BadRequest
                    }
                );

            if (verifyResponse != null) return ApiResult(verifyResponse);

            var updateResult = 
                await AppServices.Account.UpdateAccountRegistration(
                    account, 
                    request, 
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
        /// Update user's information if it includes valid gmail, then send verified code.
        /// </summary>
        /// <remarks>UpdateInformation</remarks>
        /// <param name="request" example="{Name: 'ABC' , Gender: 1, DateOfBirth='31-01-2000', Registration='abc@gmail.com'}">User Information Schema</param>
        /// <response code = "200"> Updated user's information successfully.</response>
        /// <response code = "200"> Update user's information successfully, but send verification code failed. Please click resend code.</response>
        /// <response code="400"> This gmail was verified by another account.</response>
        /// <response code="500"> Failed to update user's information.</response>
        [HttpPut("information")]
        public async Task<IActionResult> UpdateInformation([FromBody] UserInfoRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Gmail;
            request.OtpTypes = OtpTypes.VerificationOTP;

            var loginedUser = LoggedInUser;

            var updateResponse =
                    await AppServices.Booker.UpdateBookerAccount(
                        loginedUser.Code.ToString(), 
                        request, 
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
                        },
                        successButNotSendCodeResponse: new()
                        {
                            Message = "Update user's information successfully, but send verification code failed. Please click resend code.",
                            StatusCode = StatusCodes.Status200OK
                        }
                    );

            return ApiResult(updateResponse);
        }

        [HttpPost("phone/loginFake")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginFake([FromBody] string phoneNumber)
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
                    RefreshAccessToken = refreshToken,
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
        /// Send otp code to phone and use otp to register account.
        /// </summary>
        /// <remarks>SendOtpToRegister</remarks>
        /// <param name="request" example="{Registration: '+84837226239'}">Send Otp Request Schema</param>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This phone number was verified by another account.</response>
        /// <response code = "500"> Fail to send otp to this phone number.</response>
        [HttpPost("phone/send-otp-to-register")]
        [AllowAnonymous]
        public async Task<IActionResult> SendOtpToRegister([FromBody] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.RegisterOTP;
            request.RegistrationTypes = RegistrationTypes.Phone;

            // check not existed verified phone number to send otp if EXIST return error response 
            var existResponse =
                AppServices.Booker.CheckNotExisted(
                    request,
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
                    request,
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
                    request,
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
        /// Register account.
        /// </summary>
        /// <remarks>Register</remarks>
        /// <param name="request" example="{OptionalRegistration: 'abc@gmail.com', Name: 'ABC' , Gender: 1, DateOfBirth='2000-01-31', Registration='+84837226239'}">User Register Request Schema</param>
        /// <response code = "200"> Register account successfully.</response>
        /// <response code="400"> Register account failed - This phone number was register by another account.</response>
        /// <response code="400"> Wrong OTP to register.</response>
        /// <response code="500"> Failed to register account.</response>
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            request.OtpTypes = OtpTypes.RegisterOTP;
            request.RegistrationTypes = RegistrationTypes.Phone;
            request.OptionalRegistrationTypes = RegistrationTypes.Gmail;

            // verify OTP
            var verifyResponse =
                await AppServices.VerifiedCode.VerifyOtp(
                    request,
                    errorResponse: new()
                    {
                        Message = "Wrong or Expired OTP.",
                        StatusCode = StatusCodes.Status400BadRequest
                    }
                );

            if (verifyResponse != null) return ApiResult(verifyResponse);

            var createResponse =
                await AppServices.Booker.CreateBookerAccount(
                    request,
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
    }
}
