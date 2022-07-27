using API.JwtFeatures;
using API.Models;
using API.Models.Requests;
using API.Models.Response;
using AutoMapper;
using Domain.Entities;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : AuthController<DriversController>
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper mapper;

        public DriversController(IJwtHandler jwtHandler, IMapper mapper)
        {
            _jwtHandler = jwtHandler;
            this.mapper = mapper;
        }

        [HttpPost("login-by-email")]
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
        public override IActionResult SendGmailOtp([FromQuery] SendGmailOtpRequest request)
        {
            var response = new Response();
            return Ok(response);
        }

        [HttpGet("phone/send-otp")]
        public override Task<IActionResult> SendPhoneLoginOtp([FromBody] SendPhoneOtpRequest request)
        {
            return null;
        }
    }
}
