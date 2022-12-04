using API.Models.Response;
using Domain.Interfaces.UnitOfWork;
using FluentValidation;
using Infrastructure.Data.UnitOfWork;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Buffers;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ErrorHandlerMiddleware> logger, IUnitOfWork unitOfWork)
        {
            try
            {
                await _next(context);
                if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException("Token Validation Has Failed. Request Access Denied");
                } 
                
            }
            catch (Exception error)
            {
                await unitOfWork.Rollback();
                
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ForbiddenException e:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedAccessException e:
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsJsonAsync<Response>(new()
                {
                    StatusCode = response.StatusCode,
                    Message = error.Message
                });

                logger.LogError(error, "Request {method} {url} => {statusCode}", 
                    context.Request?.Method, 
                    context.Request?.Path.Value, 
                    context.Response?.StatusCode);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
