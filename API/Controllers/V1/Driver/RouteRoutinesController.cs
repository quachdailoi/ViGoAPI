﻿using API.Extensions;
using API.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1.Driver
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "DRIVER")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RouteRoutinesController : BaseController<RouteRoutinesController>
    {
        public RouteRoutinesController()
        {
        }

        /// <summary>
        ///     Driver sign a route by input route code, start date, end date, start time every day. 
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/route-routines
        ///     {
        ///         "RouteCode": "...",
        ///         "StartAt": "",
        ///         "EndAt": "",
        ///         "StartTime": ""
        ///     }
        /// ```
        /// </remarks>
        /// <response code = "200"> Create successfully.</response>
        /// <response code = "500"> 
        ///     Create failed - Something went wrong.
        /// </response>
        [MapToApiVersion("1.0")]
        [HttpPost()]
        public async Task<IActionResult> CreateRouteRoutine([FromBody] CreateRouteRoutineRequest request)
        {
            request.UserId = LoggedInUser.Id;

            var foundedRoute = AppServices.Route.GetRoute(request.RouteCode).FirstOrDefault();

            if (foundedRoute == null)
            {
                return ApiResult(new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Not found route to create routine."
                });
            }
            request.RouteId = foundedRoute.Id;
            
            // parse date and time from string to right type
            var NewStartAt = DateTimeExtensions.ParseExactDateOnly(request.StartAt);
            var NewEndAt = DateTimeExtensions.ParseExactDateOnly(request.EndAt);
            var NewStartTime = DateTimeExtensions.ParseExactTimeOnly(request.StartTime);
            var NewEndTime = NewStartTime.AddMinutes(foundedRoute.Duration / 60);

            request.StartAtParsed = NewStartAt;
            request.EndAtParsed = NewEndAt;
            request.StartTimeParsed = NewStartTime;
            request.EndTimeParsed = NewEndTime;

            var checkValidTime = await AppServices.RouteRoutine.CheckTimeToCreateRoutine(request);
            if (checkValidTime != null) return ApiResult(checkValidTime);

            var checkValidDate = await AppServices.RouteRoutine.CheckDateToCreateRoutine(request);
            if (checkValidDate != null) return ApiResult(checkValidDate); 

            //

            if (!AppServices.RouteRoutine.CheckValidRoutineForRoute(request))
            {
                return ApiResult(new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Invalid date of 'start at' and 'end at' of new routine."
                });
            }

            var checkValidDistance = await AppServices.RouteRoutine.CheckValidDistanceNewRoutine(request);

            if (checkValidDistance != null)
            {
                return ApiResult(new()
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = $"{checkValidDistance.Compare} {checkValidDistance.ValidTime}",
                    Data = checkValidDistance
                });
            }

            var response = 
                await AppServices.RouteRoutine.CreateRouteRoutine(
                    request,
                    success: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Create route routine successfully."
                    },
                    failed: new()
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Message = "Failed to create route routine - internal error."
                    }
                );

            return ApiResult(response);
        }

        /// <summary>
        ///     Get route routine of driver. 
        /// </summary>
        /// <response code = "200"> Get successfully.</response>
        [MapToApiVersion("1.0")]
        [HttpGet()]
        public async Task<IActionResult> GetRouteRoutines()
        {
            var response = 
                await AppServices.RouteRoutine.GetRouteRoutineOfDriver(
                    LoggedInUser.Id,
                    success: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Get route routines successfully."
                    }
                );

            return ApiResult(response);
        }
    }
}
