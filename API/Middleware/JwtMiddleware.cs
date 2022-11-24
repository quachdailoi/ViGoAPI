using API.JwtFeatures;
using API.Services;
using API.Services.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtHandler jwtHandler, IAppServices appServices)
        {
            var metaData = context.GetEndpoint()?.Metadata;
            

            if (metaData != null)
            {
                var hasAuthorizeAttribute = metaData.Any(m => m is AuthorizeAttribute);

                if (hasAuthorizeAttribute)
                {
                    var hasAllowAnonymousAttribute = metaData.Any(m => m is AllowAnonymousAttribute);

                    if (!hasAllowAnonymousAttribute)
                    {
                        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                        var user = await jwtHandler.GetUserViewModelByTokenAsync(token);
                        if (user.RoleName == Roles.BOOKER.GetName())
                        {
                            await appServices.User.CheckValidUserToLogin(user, RegistrationTypes.Phone);
                        }
                        else
                        {
                            await appServices.User.CheckValidUserToLogin(user, RegistrationTypes.Gmail);

                        }
                        context.Items["User"] = user;
                    }                 
                }
            } 
            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}
