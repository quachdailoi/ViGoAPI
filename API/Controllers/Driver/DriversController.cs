using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Shares.Enums;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Api.V2010.Account;

namespace API.Controllers.Driver
{
    [Route("api/[controller]")]
    [Authorize(Roles="DRIVER")]
    [ApiController]
    public class DriversController : AuthController<DriversController>
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public DriversController( IMapper mapper, IJwtHandler jwtHandler)
        {
            _jwtHandler = jwtHandler;
            _mapper = mapper;
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

            string email = claims["email"];

            var user = await AppServices.AuthService.GetDriverUserViewModelByEmail(email);

            if (user == null)
            {
                response.SetStatusCode(StatusCodes.Status401Unauthorized)
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

        [HttpGet("gmail/send-otp-to-vefiry")]
        public override async Task<IActionResult> SendGmailOtp()
        {
            Response response = new();

            var userCode = _jwtHandler.GetUserFromToken(Request.Headers["Authorization"].FirstOrDefault().Split(" ").Last());

            var account = await AppServices.AccountService.GetAccountByUserCode(userCode.Code.ToString(), RegistrationTypes.Email);

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

            var verifiedCode = await AppServices.VerifiedCodeService.SaveCode(otp, account.Registration, RegistrationTypes.Email.GetInt(), VerifiedCodeTypes.RegisterOTP.GetInt());

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

        [HttpGet("phone/send-otp-to-login")]
        [AllowAnonymous]
        public override async Task<IActionResult> SendPhoneLoginOtp([FromBody] SendPhoneOtpRequest request)
        {
            Response response = new();

            var account = await AppServices.AuthService.GetDriverAccountByPhoneNumber(request.PhoneNumber);

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
        [HttpGet("phone/send-otp-to-update")]
        public async Task<IActionResult> SendPhoneOtpForUpdate([FromQuery] SendPhoneOtpRequest request)
        {
            Response response = new();

            var isDuplicatePhoneNumber = (await AppServices.AuthService.GetDriverAccountByPhoneNumber(request.PhoneNumber)) == null;

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
        public async Task<IActionResult> UpdatePhone([FromBody] string phoneNumber, string otp)
        {
            Response response = new();

            var user = _jwtHandler.GetUserFromToken(Request.Headers["Authorization"].FirstOrDefault().Split(" ").Last());

            var account = await AppServices.AccountService.GetAccountByUserCode(user.Code.ToString(), RegistrationTypes.Phone);

            var isValidToken = await AppServices.VerifiedCodeService.VerifyOtp(otp, phoneNumber, RegistrationTypes.Phone.GetInt(), VerifiedCodeTypes.VerificationOTP.GetInt());

            if (!isValidToken)
            {
                response
                    .SetStatusCode(StatusCodes.Status400BadRequest)
                    .SetMessage("Otp is not valid");
                return BadRequest(response);
            }

            await AppServices.AccountService.UpdateAccountRegistration(account, phoneNumber, RegistrationTypes.Phone);

            response
                    .SetStatusCode(StatusCodes.Status200OK)
                    .SetMessage("Update phone number successfully");
            return new JsonResult(response);
        }

        [HttpPost("phone/loginFake")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginFake()
        {
            Response response = new();

            var user = await AppServices.AuthService.GetUserViewModelByRole(Roles.DRIVER);

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
