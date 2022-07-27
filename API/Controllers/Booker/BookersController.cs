using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using AutoMapper;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio.Rest.Api.V2010.Account;

namespace API.Controllers.Booker
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookersController : AuthController<BookersController>
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public BookersController(IJwtHandler jwtHandler, IMapper mapper)
        {
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        [HttpGet("phone/send-login-otp")]
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

            var verifiedCode = AppServices.VerifiedCodeService.SaveCode(otp, request.PhoneNumber, RegistrationTypes.Phone.GetInt(), VerifiedCodeTypes.LoginOTP.GetInt());

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

            return Ok(response);
        }

        [HttpPost("phone/login")]
        public async Task<IActionResult> PhoneLogin(PhoneLoginRequest request)
        {
            Response response = new();

            var checkLogin = await AppServices.VerifiedCodeService.CheckPhoneLoginByOtp(request.OTP, request.PhoneNumber, RegistrationTypes.Phone.GetInt(), VerifiedCodeTypes.LoginOTP.GetInt());

            if (!checkLogin)
            {
                response = new(
                    StatusCode: StatusCodes.Status401Unauthorized,
                    Message: "Login failed - Wrong otp."
                );
                return Unauthorized(response);
            }

            var user = await AppServices.AuthService.GetDriverUserViewModelByEmail(request.PhoneNumber);

            if (user == null)
            {
                response.SetStatusCode(StatusCodes.Status401Unauthorized)
                    .SetMessage("Login failed - Not found email of driver account in our system.");
                return Unauthorized(response);
            }

            string token = _jwtHandler.GenerateToken(user);

            response.SetStatusCode(StatusCodes.Status200OK)
                .SetMessage("Login successfully.")
                .SetData(new LoginSuccessViewModel
                {
                    AccessToken = token,
                    User = user
                });

            return new JsonResult(response);
        }

        [HttpGet("gmail/send-otp")]
        public override IActionResult SendGmailOtp([FromBody] SendGmailOtpRequest request)
        {
            var response = new Response();
            return Ok(response);
        }
    }
}
