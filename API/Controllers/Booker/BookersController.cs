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
using Twilio.Rest.Api.V2010.Account;

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

        [HttpGet("phone/send-otp-to-login")]
        [AllowAnonymous]
        public async Task<IActionResult> SendPhoneOtpToLogin([FromQuery] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.LoginOTP;
            request.RegistrationTypes = RegistrationTypes.Phone;

            // check existed verified phone number to send otp if NOT return error response
            var notExistResponse = 
                AppServices.Booker.CheckExisted(
                    request, 
                    errorMessage: "Not found account with this phone number to send login otp.",
                    errorCode: StatusCodes.Status404NotFound,
                    isVerified: true
                );

            if (notExistResponse != null) return ApiResult(notExistResponse);

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
                    errorMessage: "Fail to send code to this phone number - Please try again.", 
                    errorCode: StatusCodes.Status500InternalServerError
                );

            return ApiResult(sendAndSaveResponse);
        }

        [HttpPost("phone/login")]
        [AllowAnonymous]
        public async Task<IActionResult> PhoneLogin(VerifyOtpRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Phone;
            request.OtpTypes = OtpTypes.LoginOTP;

            Response response = new();

            var checkLoginResponse = 
                await AppServices.VerifiedCode.VerifyOtp(
                    request, 
                    errorMessage: "Wrong or Expired OTP - Please try again.", 
                    errorCode: StatusCodes.Status401Unauthorized
                );

            if (checkLoginResponse != null) return ApiResult(checkLoginResponse);

            var user = await AppServices.Booker.GetUserViewModel(request);

            if (user == null)
            {
                response.SetStatusCode(StatusCodes.Status401Unauthorized)
                    .SetMessage("Login failed - Not found phone of booker account in our system.");
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

        [HttpGet("gmail/send-otp-to-verify")]
        public async Task<IActionResult> SendGmailOtpToVerify([FromQuery]SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.VerificationOTP;
            request.RegistrationTypes = RegistrationTypes.Gmail;

            // check not existed verified gmail to send otp if EXIST return error response
            var existResponse = 
                AppServices.Booker.CheckNotExisted(
                    request, 
                    errorMessage: "This email was verified by another account - please use another.", 
                    errorCode: StatusCodes.Status400BadRequest,
                    isVerified:true
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
                    errorMessage: "Fail to send otp to this gmail - Please try again.", 
                    errorCode: StatusCodes.Status500InternalServerError
                );

            return ApiResult(sendAndSaveResponse);
        }

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
                    errorMessage: "Verify failed - This email was verified by another account, please use another.", 
                    errorCode: StatusCodes.Status400BadRequest,
                    isVerified: true
                );

            if (existResponse != null) return ApiResult(existResponse);

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
                        Message: "Verify gmail failed."
                    ));
            }

            var response = new Response(
                StatusCode: StatusCodes.Status200OK,
                Message: "Verify gmail successfully."
            );

            return ApiResult(response);
        }
        
        [HttpGet("phone/send-otp-to-update")]
        public async Task<IActionResult> SendPhoneOtpForUpdate([FromQuery] SendOtpRequest request)
        {
            request.OtpTypes = OtpTypes.UpdateOTP; 
            request.RegistrationTypes = RegistrationTypes.Phone; 

            // check not existed verified phone number to send otp if EXIST return error response 
            var existResponse = 
                AppServices.Booker.CheckNotExisted( 
                    request, 
                    errorMessage: "This phone number was belong to another verified account - please use another.", 
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
                    errorMessage: "Fail to send otp to this phone number - Please try again.",
                    errorCode: StatusCodes.Status500InternalServerError
                );

            return ApiResult(sendAndSaveResponse);
        }

        [HttpPut("phone")]
        public async Task<IActionResult> UpdatePhone([FromBody] UpdateRegistrationByOtpRequest request)
        {
            request.RegistrationTypes = RegistrationTypes.Phone;
            request.OtpTypes = OtpTypes.UpdateOTP;

            Response response = new();

            var authenResponse = CheckLoginedUserToGetAccount(RegistrationTypes.Phone, out UserViewModel? loginedUser, out Account? account);

            if (authenResponse != null) return ApiResult(authenResponse);

            // check not existed verified phone number to send otp if EXIST return error response
            var existResponse =
                AppServices.Booker.CheckNotExisted(
                    request,
                    errorMessage: "This phone number was belong to another verified account - please use another.",
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
                    .SetMessage("Update phone number failed");

                return ApiResult(response);
            }

            response
                .SetStatusCode(StatusCodes.Status200OK)
                .SetMessage("Update phone number successfully");
            return ApiResult(response);
        }

        /// <summary>
        /// Update booker information - Update information if it includes valid email, then send verified code.
        /// </summary>
        /// <remarks>Update</remarks>
        /// <param name="request" example="{Name: 'ABC' , Gender: 1, DateOfBirth='31-01-2000', Registration='abc@gmail.com'}">Information schema</param>
        /// <response code = "200"> Update information successfully.</response>
        /// <response code="400"> Update failed - This email was verified by another account.</response>
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

            var user = await AppServices.Booker.GetUserViewModel("+84377322919", RegistrationTypes.Phone);

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

        //[HttpPost("phone/send-otp-to-signup")]
        //[AllowAnonymous]
        //public async Task<IActionResult> SendOtpToSignUp([FromBody] SendPhoneOtpRequest request)
        //{

        //}
    }
}
