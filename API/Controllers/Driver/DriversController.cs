using API.Extensions;
using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Twilio.Rest.Api.V2010.Account;

namespace API.Controllers.Driver
{
    [Route("api/[controller]")]
    [Authorize(Roles="DRIVER")]
    [ApiController]
    public class DriversController : BaseController<DriversController>
    {
        private readonly IJwtHandler _jwtHandler;

        public DriversController(IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
        }

        /// <summary>
        /// Login by gmail which was register by admin.
        /// </summary>
        /// <remarks>LoginByEmail</remarks>
        /// <param name="request" example="{IdToken: 'abc......'}">Login By Email Request Schema</param>
        /// <response code = "200"> Login successfully.</response>
        /// <response code = "400"> Login failed - Something went wrong.</response>
        /// <response code = "404"> Not found email of driver account in our system.</response>
        [HttpPost("login-by-email")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailRequest request)
        {
            FirebaseAuth firebaseAuth = FirebaseAuth.DefaultInstance;

            FirebaseToken verifiedIdToken = await firebaseAuth.VerifyIdTokenAsync(request.IdToken);

            if (verifiedIdToken == null)
            {
                return ApiResult(new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Login failed - Something went wrong."
                });
            }

            IReadOnlyDictionary<string, dynamic> claims = verifiedIdToken.Claims;

            string gmail = claims["email"];

            var user = await AppServices.Driver.GetUserViewModel(gmail, RegistrationTypes.Gmail);

            if (user == null)
            {
                return ApiResult(new()
                {
                    Message = "Not found email of driver account in our system.",
                    StatusCode = StatusCodes.Status404NotFound
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
                    RefreshAccessToken = refreshToken,
                    User = user
                }
            });
        }

        /// <summary>
        /// Send otp code to gmail and use otp to update account's gmail.
        /// </summary>
        /// <remarks>SendGmailOtpToUpdate</remarks>
        /// <param name="request" example="{Registration: 'abc@gmail.com'}">Send Otp Request Schema</param>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This gmail was verified by another account.</response>
        /// <response code = "400"> Wait 1 minute since last sent.</response>
        /// <response code = "500"> Fail to send otp to this gmail address.</response>
        [HttpGet("gmail/send-otp-to-update")]
        public async Task<IActionResult> SendGmailOtpToUpdate([FromQuery] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.UpdateOTP;
            request.RegistrationTypes = RegistrationTypes.Gmail;

            // check not existed verify gmail to send otp if EXIST return error response
            var existResponse = 
                AppServices.Driver.CheckNotExisted(
                    request, 
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
                    request,
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
                    request,
                    successResponse: new()
                    {
                        Message = "Send Otp Successfully.",
                        StatusCode = StatusCodes.Status200OK
                    },
                    errorResponse: new()
                    {
                        Message = "Fail to send otp to this gmail address.",
                        StatusCode = StatusCodes.Status500InternalServerError
                    }
                );

            return ApiResult(sendAndSaveResponse);
        }

        /// <summary>
        /// Update gmail with otp code which was send to it.
        /// </summary>
        /// <remarks>UpdateGmail</remarks>
        /// <param name="request" example="{Registration: 'newAbc@gmail.com', OTP: '123123'}">Verify Otp Request Schema</param>
        /// <response code = "200"> Update gmail successfully.</response>
        /// <response code = "400"> This gmail was belong to another verified account.</response>
        /// <response code = "400"> Wrong or Expired OTP.</response>
        /// <response code = "500"> Failed to update gmail.</response>
        [HttpPut("gmail")]
        public async Task<IActionResult> UpdateGmail([FromBody] VerifyOtpRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Gmail;
            request.OtpTypes = OtpTypes.UpdateOTP;

            var authenResponse = CheckLoginedUserToGetAccount(RegistrationTypes.Phone, out UserViewModel? loginedUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse =
                AppServices.Driver.CheckNotExisted(
                    request,
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
        /// Send otp code to phone number to verified it.
        /// </summary>
        /// <remarks>SendPhoneOtpToVerify</remarks>
        /// <param name="request" example="{Registration: '+84837226239'}">Send Otp Request Schema</param>
        /// <response code = "200"> Send Otp Successfully.</response>
        /// <response code = "400"> This phone number was verified by another account.</response>
        /// <response code = "400"> Wait 1 minute since last sent.</response>
        /// <response code = "500"> Fail to send otp to this phone number.</response>
        [HttpGet("phone/send-otp-to-verify")]
        public async Task<IActionResult> SendPhoneOtpToVerify([FromQuery] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;
            request.RegistrationTypes = RegistrationTypes.Phone;

            // check not existed verified phone number to send otp if EXIST return error response
            var existResponse =
                AppServices.Driver.CheckNotExisted(
                    request,
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
        /// Verify phone number by otp code which was sent to it.
        /// </summary>
        /// <remarks>VerifyPhoneNumber</remarks>
        /// <param name="request" example="{Registration: '+84837226239', OTP: '123123'}">Verify Otp Request Schema</param>
        /// <response code = "200"> Verify phone number successfully.</response>
        /// <response code = "400"> This phone numner was verified by another account.</response>
        /// <response code = "400"> Wrong or Expired OTP for verifying.</response>
        /// <response code = "500"> Failed to verify phone number.</response>
        [HttpPost("phone/verify")]
        public async Task<IActionResult> VerifyPhoneNumber([FromBody] VerifyOtpRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Phone;
            request.OtpTypes = OtpTypes.VerificationOTP;

            var authenResponse = CheckLoginedUserToGetAccount(RegistrationTypes.Gmail, out UserViewModel? loginedUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse =
                AppServices.Driver.CheckNotExisted(
                    request,
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
                    request,
                    errorResponse: new()
                    {
                        Message = "Wrong or Expired OTP for verifying.",
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
        /// Update driver information - Update information if it includes valid phone number, then send verified code.
        /// </summary>
        /// <remarks>Update</remarks>
        /// <param name="request" example="{Name: 'ABC' , Gender: 1, DateOfBirth='31-01-2000', Registration='0123123123'}">Information schema</param>
        /// <response code = "200"> Update information successfully.</response>
        /// <response code="400"> Update failed - This phone number was verified by another account.</response>
        /// <response code="500"> Update failed - Something went wrong.</response>
        [HttpPut("information")]
        public async Task<IActionResult> UpdateInformation([FromBody] UserInfoRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Gmail;
            request.OtpTypes = OtpTypes.VerificationOTP;

            var loginedUser = LoginedUser;

            var updateResponse =
                    await AppServices.Driver.UpdateDriverAccount(
                        loginedUser.Code.ToString(),
                        request,
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
                        },
                        successButNotSendCodeResponse: new()
                        {
                            Message = "Update driver's information successfully, but failed to send verification code - Please click resend code.",
                            StatusCode = StatusCodes.Status200OK
                        }
                    );

            return ApiResult(updateResponse);
        }

        [HttpPost("gmail/loginFake")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginFake([FromBody] string gmail)
        {
            Response response = new();

            var user = await AppServices.Driver.GetUserViewModel(gmail, RegistrationTypes.Phone);

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
                    RefreshAccessToken = refreshToken,
                    User = user
                });

            return new JsonResult(response);
        }

        [HttpGet("test")]
        public IActionResult TestAuthen()
        {
            var user = LoginedUser;
            return Ok(user);
        }  
    }
}
