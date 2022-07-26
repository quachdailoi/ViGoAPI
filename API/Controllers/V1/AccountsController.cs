﻿using API.AWS.S3;
using API.Extensions;
using API.JwtFeatures;
using API.Models.Requests;
using API.Models.Response;
using API.Quartz;
using API.Quartz.Jobs;
using API.Services.Constract;
using API.SignalR.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountsController : BaseController<AccountsController>
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IConfiguration _config;
        private readonly IFileService _storageService;

        public AccountsController(IJwtHandler jwtHandler, IConfiguration configuration, IFileService storageService)
        {
            _jwtHandler = jwtHandler;
            _config = configuration;
            _storageService = storageService;
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var response = CheckRequest(request);

            string accessToken = request.AccessToken;
            string refreshToken = request.RefreshToken;

            try
            {
                var isRevokedToken = await AppServices.Token.IsRevokedRefreshTokenAsync(refreshToken);
                if (isRevokedToken)
                    throw new SecurityTokenExpiredException();

                // generate new access token
                var userViewModel = await _jwtHandler.GetUserViewModelByTokenAsync(accessToken);

                if (userViewModel == null)
                {
                    throw new SecurityTokenException();
                }
                // check exist refresh token with user code
                var userCodeFromRefreshToken = await AppServices.Token.ValueOfActiveRefreshToken(refreshToken);
                if (userCodeFromRefreshToken != userViewModel.Code.ToString())
                    throw new SecurityTokenExpiredException();

                var newAccessToken = _jwtHandler.GenerateToken(userViewModel);

                // replace old refresh token with a new one (rotate token)
                var newRefreshToken = await RotateRefreshToken(refreshToken, userViewModel.Code.ToString());

                response = new(
                        StatusCode: StatusCodes.Status200OK,
                        Message: "Refresh token successfully",
                        Data: new
                        {
                            token = newAccessToken,
                            refreshToken = newRefreshToken
                        }
                    );
                return Ok(response);
            }
            catch (SecurityTokenExpiredException)
            {
                response = new(
                    StatusCode: StatusCodes.Status401Unauthorized,
                    Message: "Refresh token is expired or invalid"
                );
                return BadRequest(response);
            }
            catch (SecurityTokenException)
            {
                response = new(
                    StatusCode: StatusCodes.Status400BadRequest,
                    Message: "Expired Access Token is invalid"
                );
                return BadRequest(response);
            }
        }

        private async void RevokeRefreshToken(string token)
        {
            await AppServices.Token.RevokeRefreshTokenAsync(token);
        }

        private async Task<string> RotateRefreshToken(string refreshToken, string userCode)
        {
            var newRefreshToken = await _jwtHandler.GenerateRefreshToken(userCode);
            RevokeRefreshToken(refreshToken);
            return newRefreshToken;
        }

        [HttpPost("revoke-token/token")]
        public async Task<IActionResult> RevokeToken([FromQuery] string token)
        {
            await AppServices.Token.RevokeRefreshTokenAsync(token);

            return Ok(new Response(StatusCode: 200, Message: "Token revoked successfully."));
        }
    }
}