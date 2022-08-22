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

        [HttpPost("login-by-email")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByEmail([FromBody] LoginByEmailRequest request)
        {
            FirebaseAuth firebaseAuth = FirebaseAuth.DefaultInstance;

            FirebaseToken verifiedIdToken = await firebaseAuth.VerifyIdTokenAsync(request.IdToken);

            Response response = new();

            if (verifiedIdToken == null)
            {
                response = new(
                    StatusCode: StatusCodes.Status401Unauthorized,
                    Message: "Login failed."
                );
                return Unauthorized(response);
            }

            IReadOnlyDictionary<string, dynamic> claims = verifiedIdToken.Claims;

            string gmail = claims["email"];

            var user = await AppServices.Driver.GetUserViewModel(gmail, RegistrationTypes.Gmail);

            if (user == null)
            {
                response.SetStatusCode(StatusCodes.Status401Unauthorized)
                    .SetMessage("Login failed - Not found email of driver account in our system.");
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

            return new JsonResult(response);
        }

        [HttpGet("gmail/send-otp-to-update")]
        public async Task<IActionResult> SendGmailOtpToUpdate([FromQuery] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.UpdateOTP;
            request.RegistrationTypes = RegistrationTypes.Gmail;

            // check not existed verify gmail to send otp if EXIST return error response
            var existResponse = 
                AppServices.Driver.CheckNotExisted(
                    request, 
                    errorMessage: "This gmail was belong to another verified account - please use another.", 
                    errorCode: StatusCodes.Status400BadRequest, 
                    isVerified: true
                );

            if (existResponse != null) return ApiResult(existResponse);

            // check valid time to send otp
            var checkValidResponse =
                await AppServices.VerifiedCode.CheckValidTimeSendOtp(
                    request,
                    errorMessage: "Wait 1 minute since last sent, please.",
                    errorCode: StatusCodes.Status400BadRequest
                );

            if (checkValidResponse != null) return ApiResult(checkValidResponse);

            // send and save otp code
            var sendAndSaveResponse =
                await AppServices.VerifiedCode.SendAndSaveOtp(
                    request,
                    errorMessage: "Fail to send otp to this gmail address - Please try again.",
                    errorCode: StatusCodes.Status500InternalServerError
                );

            return ApiResult(sendAndSaveResponse);
        }

        [HttpPut("gmail")]
        public async Task<IActionResult> UpdateGmail([FromBody] UpdateRegistrationByOtpRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Gmail;
            request.OtpTypes = OtpTypes.UpdateOTP;

            Response response = new();

            var authenResponse = CheckLoginedUserToGetAccount(RegistrationTypes.Phone, out UserViewModel? loginedUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse =
                AppServices.Driver.CheckNotExisted(
                    request,
                    errorMessage: "This gmail was belong to another verified account - please use another.",
                    errorCode: StatusCodes.Status400BadRequest,
                    isVerified: true
                );

            if (existResponse != null) return ApiResult(existResponse);

            // verify OTP
            var verifyResponse =
                await AppServices.VerifiedCode.VerifyOtp(
                    request,
                    errorMessage: "Wrong or Expired OTP - Please try again.",
                    errorCode: StatusCodes.Status400BadRequest
                );

            if (verifyResponse != null) return ApiResult(verifyResponse);

            var updateResult = await AppServices.Account.UpdateAccountRegistration(account, request.Registration, request.RegistrationTypes, isVerified: true);

            if (!updateResult)
            {
                response
                    .SetStatusCode(StatusCodes.Status500InternalServerError)
                    .SetMessage("Update gmail failed");

                return ApiResult(response);
            }

            response
                    .SetStatusCode(StatusCodes.Status200OK)
                    .SetMessage("Update gmail successfully");
            return ApiResult(response);
        }

        [HttpGet("phone/send-otp-to-verify")]
        public async Task<IActionResult> SendPhoneOtpToVerify([FromQuery] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;
            request.RegistrationTypes = RegistrationTypes.Phone;

            // check not existed verified phone number to send otp if EXIST return error response
            var existResponse =
                AppServices.Driver.CheckNotExisted(
                    request,
                    errorMessage: "This phone number was verified by another account - please use another.",
                    errorCode: StatusCodes.Status400BadRequest
                );

            if (existResponse != null) return ApiResult(existResponse);

            // check valid time to send otp
            var checkValidResponse =
                await AppServices.VerifiedCode.CheckValidTimeSendOtp(
                    request,
                    errorMessage: "Wait 1 minute since last sent, please.",
                    errorCode: StatusCodes.Status400BadRequest
                );

            if (checkValidResponse != null) return ApiResult(checkValidResponse);

            // send and save otp code
            var sendAndSaveResponse =
                await AppServices.VerifiedCode.SendAndSaveOtp(
                    request,
                    errorMessage: "Fail to send otp to this phone number - Please try again.",
                    errorCode: StatusCodes.Status500InternalServerError
                );

            return ApiResult(sendAndSaveResponse);
        }

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
                    errorMessage: "Verify failed - This phone numner was verified by another account, please use another.",
                    errorCode: StatusCodes.Status400BadRequest
                );

            if (existResponse != null) return ApiResult(existResponse);

            // verify OTP
            var verifyResponse =
                await AppServices.VerifiedCode.VerifyOtp(
                    request,
                    errorMessage: "Wrong or Expired OTP for verifying - please try again.",
                    errorCode: StatusCodes.Status400BadRequest
                );

            if (verifyResponse != null) return ApiResult(verifyResponse);

            // verify account
            var result = await AppServices.Account.VerifyAccount(account);
            if (!result)
            {
                return ApiResult(new(
                        StatusCode: StatusCodes.Status500InternalServerError,
                        Message: "Verify phone number failed."
                    ));
            }

            var response = new Response(
                StatusCode: StatusCodes.Status200OK,
                Message: "Verified phone number successfully."
            );

            return ApiResult(response);
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
        public async Task<IActionResult> UpdateInformation([FromBody] UpdateUserInfoRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Gmail;
            request.OtpTypes = OtpTypes.VerificationOTP;

            var loginedUser = LoginedUser;

            var updateResponse =
                    await AppServices.Booker.UpdateBookerAccount(
                        loginedUser.Code.ToString(),
                        request,
                        new[] { "This email was verified by another account.", "Update information failed." },
                        new[] { StatusCodes.Status400BadRequest, StatusCodes.Status500InternalServerError }
                    );

            if (updateResponse != null) return ApiResult(updateResponse);

            Response response = new();

            response
                .SetStatusCode(StatusCodes.Status200OK)
                .SetMessage("Updated information successfully.");

            return ApiResult(response);
        }

        [HttpPost("phone/loginFake")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginFake()
        {
            Response response = new();

            var user = await AppServices.Driver.GetUserViewModel();

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
        public IActionResult TestLogin()
        {
            var user = LoginedUser;
            return Ok(user);
        }  
    }
}
