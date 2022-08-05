using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using AutoMapper;
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
    public class BookersController : AuthController<BookersController>
    {

        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public BookersController(IMapper mapper, IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        [HttpGet("phone/send-otp-to-login")]
        [AllowAnonymous]
        public override async Task<IActionResult> SendPhoneLoginOtp([FromQuery] SendPhoneOtpRequest request)
        {
            Response response = new();

            var account = await AppServices.AuthService.GetBookerAccountByPhoneNumber(request.PhoneNumber);

            if (account == null)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status404NotFound,
                    Message: "This phone number has not been registered."
                );
                return NotFound(response);
            }

            var canResend = await AppServices.VerifiedCodeService.CheckValidTimeSendOtp(request.PhoneNumber, RegistrationTypes.Phone.GetInt(), VerifiedCodeTypes.LoginOTP.GetInt());

            if (!canResend)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status400BadRequest,
                    Message: "Wait 1 minute since last sent, please."
                );

                return BadRequest(response);
            }

            var result = await AppServices.VerifiedCodeService.SendPhoneOtp(request.PhoneNumber);

            var otp = result.Item2;

            var messageResource = result.Item1;

            if (messageResource.Status == MessageResource.StatusEnum.Failed)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status500InternalServerError,
                    Message: messageResource.ErrorMessage
                );

                return StatusCode(500, response);
            }

            var verifiedCode = await AppServices.VerifiedCodeService.SaveCode(otp, request.PhoneNumber, RegistrationTypes.Phone.GetInt(), VerifiedCodeTypes.LoginOTP.GetInt());

            if (verifiedCode == null)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status500InternalServerError,
                    Message: "Send code failed - Try again, please!"
                );

                return StatusCode(500, response);
            }

            response = new Response(
                StatusCode: StatusCodes.Status200OK,
                Message: "Send Otp Successfully.",
                Data: otp
            );

            return new JsonResult(response);
        }

        [HttpPost("phone/login")]
        [AllowAnonymous]
        public async Task<IActionResult> PhoneLogin(PhoneLoginRequest request)
        {
            Response response = new();

            var checkLogin = await AppServices.VerifiedCodeService.VerifyOtp(request.OTP, request.PhoneNumber, RegistrationTypes.Phone.GetInt(), VerifiedCodeTypes.LoginOTP.GetInt());

            if (!checkLogin)
            {
                response = new(
                    StatusCode: StatusCodes.Status401Unauthorized,
                    Message: "Login failed - Wrong otp."
                );
                return Unauthorized(response);
            }

            var user = await AppServices.AuthService.GetBookerUserViewModelByPhoneNumber(request.PhoneNumber);

            if (user == null)
            {
                response
                    .SetStatusCode(StatusCodes.Status401Unauthorized)
                    .SetMessage("Login failed - Not found email of driver account in our system.");
                return Unauthorized(response);
            }

            string token = _jwtHandler.GenerateToken(user);
            string refreshToken = _jwtHandler.GenerateRefreshToken(user);

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
        public override async Task<IActionResult> SendGmailOtp()
        {
            Response response = new();

            var user = _jwtHandler.GetUserFromToken(Request.Headers["Authorization"].FirstOrDefault().Split(" ").Last());

            var account = await AppServices.AccountService.GetAccountByUserCode(user.Code.ToString(), RegistrationTypes.Email);

            var canResend = await AppServices.VerifiedCodeService.CheckValidTimeSendOtp(account.Registration, RegistrationTypes.Email.GetInt(), VerifiedCodeTypes.VerificationOTP.GetInt());

            if (!canResend)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status400BadRequest,
                    Message: "Wait 1 minute since last sent, please."
                );

                return BadRequest(response);
            }         

            var result = await AppServices.VerifiedCodeService.SendGmailOtp(account);

            var otp = result.Item2;

            var mailResponse = result.Item1;
            
            if (!mailResponse.Contains("2.0.0"))
            {
                response = new Response(
                    StatusCode: StatusCodes.Status500InternalServerError,
                    Message: mailResponse
                );
            }

            var verifiedCode = await AppServices.VerifiedCodeService.SaveCode(otp, account.Registration, RegistrationTypes.Email.GetInt(), VerifiedCodeTypes.VerificationOTP.GetInt());

            if (verifiedCode == null)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status500InternalServerError,
                    Message: "Send code failed - Try again, please!"
                );

                return StatusCode(500, response);
            }

            response = new Response(
                StatusCode: StatusCodes.Status200OK,
                Message: "Send otp successfully.",
                Data: otp
            );

            return new JsonResult(response);
        }

        [HttpPost("gmail/verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyOtpCodeRequest request)
        {
            var response = new Response();

            var user = _jwtHandler.GetUserFromToken(Request.Headers["Authorization"].FirstOrDefault().Split(" ").Last());

            var account = await AppServices.AccountService.GetAccountByUserCode(user.Code.ToString(), RegistrationTypes.Email);

            var isValidOtp = await AppServices.VerifiedCodeService.VerifyOtp(request.Otp, account.Registration, RegistrationTypes.Email.GetInt(), VerifiedCodeTypes.VerificationOTP.GetInt());

            if (!isValidOtp)
            {
                response = new(
                    StatusCode: StatusCodes.Status400BadRequest,
                    Message: "Verify failed - Wrong otp."
                );
                return BadRequest(response);
            }

            await AppServices.AccountService.UpdateAccountVerification(account);

            response = new(
                StatusCode: StatusCodes.Status200OK,
                Message: "Verify email successfully."
            );

            return new JsonResult(response);
        }
        [HttpGet("phone/send-otp-to-update")]
        public async Task<IActionResult> SendPhoneOtpForUpdate([FromQuery] SendPhoneOtpRequest request)
        {
            Response response = new();

            var isDuplicatePhoneNumber = (await AppServices.AuthService.GetBookerAccountByPhoneNumber(request.PhoneNumber)) != null;

            if (isDuplicatePhoneNumber)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status400BadRequest,
                    Message: "This phone number has been registered."
                );
                return BadRequest(response);
            }

            var canResend = await AppServices.VerifiedCodeService.CheckValidTimeSendOtp(request.PhoneNumber, RegistrationTypes.Phone.GetInt(), VerifiedCodeTypes.VerificationOTP.GetInt());

            if (!canResend)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status400BadRequest,
                    Message: "Wait 1 minute since last sent, please."
                );

                return BadRequest(response);
            }

            var result = await AppServices.VerifiedCodeService.SendPhoneOtp(request.PhoneNumber);

            var otp = result.Item2;

            var messageResource = result.Item1;

            if (messageResource.Status == MessageResource.StatusEnum.Failed)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status500InternalServerError,
                    Message: messageResource.ErrorMessage
                );

                return StatusCode(500, response);
            }

            var verifiedCode = await AppServices.VerifiedCodeService.SaveCode(otp, request.PhoneNumber, RegistrationTypes.Phone.GetInt(), VerifiedCodeTypes.VerificationOTP.GetInt());

            if (verifiedCode == null)
            {
                response = new Response(
                    StatusCode: StatusCodes.Status500InternalServerError,
                    Message: "Send code failed - Try again, please!"
                );

                return StatusCode(500, response);
            }

            response = new Response(
                StatusCode: StatusCodes.Status200OK,
                Message: "Send otp successfully.",
                Data: otp
            );

            return new JsonResult(response);
        }
        [HttpPut("phone")]
        public async Task<IActionResult> UpdatePhone([FromBody] UpdatePhoneNumberRequest request)
        {
            Response response = new();

            var user = _jwtHandler.GetUserFromToken(Request.Headers["Authorization"].FirstOrDefault().Split(" ").Last());

            var account = await AppServices.AccountService.GetAccountByUserCode(user.Code.ToString(), RegistrationTypes.Phone);

            var isValidToken = await AppServices.VerifiedCodeService.VerifyOtp(request.OTP, request.PhoneNumber, RegistrationTypes.Phone.GetInt(),VerifiedCodeTypes.VerificationOTP.GetInt());

            if (!isValidToken)
            {
                response
                    .SetStatusCode(StatusCodes.Status400BadRequest)
                    .SetMessage("Otp is not valid");
                return BadRequest(response);
            }

            await AppServices.AccountService.UpdateAccountRegistration(account, request.PhoneNumber, RegistrationTypes.Phone);

            response
                    .SetStatusCode(StatusCodes.Status200OK)
                    .SetMessage("Update phone number successfully");
            return new JsonResult(response);
        }

        [HttpPut("gmail")]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailRequest request)
        {
            Response response = new();

            var user = _jwtHandler.GetUserFromToken(Request.Headers["Authorization"].FirstOrDefault().Split(" ").Last());

            var account = await AppServices.AccountService.GetAccountByUserCode(user.Code.ToString(), RegistrationTypes.Email);

            var isDuplicateEmail = (await AppServices.AuthService.GetBookerAccountByEmail(request.Email)) != null;

            if (isDuplicateEmail) {
                response
                .SetStatusCode(StatusCodes.Status400BadRequest)
                .SetMessage("Email has existed");

                return BadRequest(response);
                
            }

            await AppServices.AccountService.UpdateAccountRegistration(account, request.Email, RegistrationTypes.Email);

            response
                .SetStatusCode(StatusCodes.Status200OK)
                .SetMessage("Update email successfully");

            return new JsonResult(response);
        }

        [HttpPost("phone/loginFake")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginFake()
        {
            Response response = new();

            var user = await AppServices.AuthService.GetUserViewModelByRole(Roles.BOOKER);

            string token = _jwtHandler.GenerateToken(user);
            string refreshToken = _jwtHandler.GenerateRefreshToken(user);

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
    }
}
