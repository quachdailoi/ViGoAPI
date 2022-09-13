namespace API.Helpers.Attributes;

using API.Models;
using API.Models.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly IList<string> _roles;
    public CustomAuthorizeAttribute(params string[] roles)
    {
        _roles = roles ?? new string[] { };
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        var user = (UserViewModel?)context.HttpContext.Items["User"];
        if (user == null || (_roles.Any() && !_roles.Contains(user.RoleName)))
        {
            // not logged in
            context.Result =
                new UnauthorizedObjectResult(new Response()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Message = "Unauthorize action."
                });
        }
    }
}
