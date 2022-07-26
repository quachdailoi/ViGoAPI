﻿using API.Extensions;
using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.TaskQueues;
using API.Utils;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;
using System.Security.Cryptography;
using System.Text.Json;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    public class TestsController : BaseController<TestsController>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRedisMQService _redisMQMessage;
        private readonly IMapper _mapper;

        public TestsController(IUnitOfWork unitOfWork, IRedisMQService redisMQMessage, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _redisMQMessage = redisMQMessage; 
            _mapper = mapper;
        }

        [HttpDelete("user/{code}")]
        
        public async Task<IActionResult> DeleteUser(string code)
        {
            var user = await _unitOfWork.Users.GetUserByCode(code).Include(x => x.Accounts).Include(x => x.File).FirstOrDefaultAsync();

            if (user == null) return NotFound("Not found user with code to delete.");

            await _unitOfWork.Users.Remove(user);
            foreach (var acc in user.Accounts)
            {
                await _unitOfWork.Accounts.Remove(acc);
            }
            if (user.File != null)
            await _unitOfWork.Files.Remove(user.File);

            return Ok("Delete user successfully.");
        }

		[HttpGet("user")]
        public async Task<IActionResult> GetUser(string code)
        {
            var user = await _unitOfWork.Users.GetUserByCode(code).FirstOrDefaultAsync();
            return Ok(user);
        }

        [HttpGet("test")]
        [AllowAnonymous]
        public async Task<IActionResult> Test()
        {
            var settingTime = await AppServices.Setting.GetValue<TimeOnly>(Settings.AllowedBookerCancelTripTime, new TimeOnly(19, 45));

            var nowTime = DateTimeExtensions.NowTimeOnly;

            var tomorrowDate = DateTimeExtensions.NowDateOnly.AddDays(1);
            return Ok(new
            {
                Setting = settingTime,
                NowTime = nowTime,
                TomorrowDate = tomorrowDate,
                IsExpried = settingTime < nowTime
            });
        }

        public class Number
        {
            public int Value { get; set; }
            public List<int> Items { get; set; } = new();
        }

        [HttpPost("dump/drivers")]
        [AllowAnonymous]
        public async Task<IActionResult> DumpDrivers([FromQuery] DumpDriverRequest request)
        {
            dynamic vehicleTypes = (await AppServices.VehicleType.Get(new())).Data;

            VehicleTypeViewModel vehicleTypeVM = null;

            foreach(dynamic type in vehicleTypes)
            {
                foreach(VehicleTypeViewModel vehicleType in type.VehicleTypes)
                {
                    if (vehicleType.Code == request.VehicleTypeCode) vehicleTypeVM = vehicleType;
                }
            }

            var route = await AppServices.Route.GetRouteByCode(request.RouteCode.ToString());

            var nowDateOnly = DateTimeExtensions.NowDateOnly;
            var startDateInCurMonth = new DateOnly(nowDateOnly.Year, nowDateOnly.Month, 1);
            var startDateInNextMonth = startDateInCurMonth.AddMonths(1);

            var startTimes = new List<TimeOnly>
            {
                new TimeOnly(7,0),
                new TimeOnly(8,0),
                new TimeOnly(9,0),
                new TimeOnly(15,0),
                new TimeOnly(16,0),
                new TimeOnly(17,0),
                new TimeOnly(18,0)
            };

            var users = new List<User>();

            for (var i = 0; i < request.Quantity; i++)
            {
                var nextStartDateOnly = startDateInNextMonth.AddMonths(i);
                var endDate = new DateOnly(nextStartDateOnly.Year, nextStartDateOnly.Month, DateTime.DaysInMonth(nextStartDateOnly.Year, nextStartDateOnly.Month));
                var user = new User
                {
                    Name = $"Dummy_{DateTime.Now}_{i}",
                    Wallet = new(),
                    Accounts = new List<Account>
                    {
                        new Account
                        {
                            RegistrationType = RegistrationTypes.Gmail,
                            Registration = $"Dummy{DateTime.Now}{i}",
                            RoleId = Roles.DRIVER
                        },
                        new Account
                        {
                            RegistrationType = RegistrationTypes.Phone,
                            Registration = $"Dummy{DateTime.Now.Ticks}{i}",
                            RoleId = Roles.DRIVER
                        }
                    },
                    Vehicle = new Vehicle
                    {
                        LicensePlate = $"Dummy_{DateTime.Now}_{i}",
                        VehicleTypeId = (VehicleTypes.SpecificType)vehicleTypeVM.Id,
                        Name = $"Dummy{DateTime.Now.Ticks}{i}"
                    },
                    RouteRoutines = startTimes
                    .Select(time => new RouteRoutine
                        {
                            RouteId = route.Id,
                            StartAt = startDateInNextMonth,
                            EndAt = endDate,
                            StartTime = time,
                            EndTime = time.AddMinutes(route.Duration / 60)
                        })
                    .ToList()
                };

                users.Add(user);
            }

            await AppServices.User.CreateRange(users);

            return Ok();
        }

        public class DumpDriverRequest
        {
            public int Quantity { get; set; }
            public Guid VehicleTypeCode { get; set; }
            public Guid RouteCode { get; set; }
        }

        [HttpPost("dump/bookings")] // dump bookings
        [AllowAnonymous]
        public async Task<IActionResult> DumpBookings()
        {
            dynamic vehicleTypes = (await AppServices.VehicleType.Get(new())).Data;

            dynamic routes = (await AppServices.Route.GetAll(new(),new())).Data;

            var users = await AppServices.User.GetByRole(Roles.BOOKER);

            var route = routes[0];

            var routeRoutines = await AppServices.RouteRoutine.GetByRouteId((int)route.Id);

            var totalSuccessBooking = 0;
            var totalFailedBooking = 0;

            foreach(var user in users)
            {
                foreach (dynamic type in vehicleTypes)
                {
                    foreach (dynamic vehicleType in type.VehicleTypes)
                    {
                        if (vehicleType.Type == VehicleTypes.Type.ViRide) continue;

                        var fitRouteRoutines = routeRoutines
                            .Where(routeRoutine =>
                                routeRoutine.User.Vehicle.VehicleTypeId == (VehicleTypes.SpecificType)vehicleType.Id)
                            .ToList();

                        foreach (var routeRoutine in fitRouteRoutines)
                        {
                            var timeDuration = (routeRoutine.EndTime.ToTimeSpan() - routeRoutine.StartTime.ToTimeSpan()).TotalMinutes;

                            var time = routeRoutine.StartTime.AddMinutes(((new Random()).Next() % 4) * 5);

                            var dateDuration = (int)Math.Floor(routeRoutine.EndAt.ToDateTime(TimeOnly.MinValue).Subtract(routeRoutine.StartAt.ToDateTime(TimeOnly.MinValue)).TotalDays) % (30*3);

                            var startDate = routeRoutine.StartAt.AddDays(((new Random()).Next() % dateDuration));
                            var endDate = new DateOnly(startDate.Year, startDate.Month, DateTime.DaysInMonth(startDate.Year, startDate.Month));

                            List<StationInRouteViewModel> stations = route.Stations;

                            var startIndex = (new Random()).Next() % (stations.Count-1);
                            var endIndex = startIndex + 1 + (new Random()).Next() % (stations.Count - startIndex -1);

                            var bookingDto = new BookingDTO();

                            bookingDto.PaymentMethod = Payments.PaymentMethods.COD;
                            bookingDto.VehicleTypeCode = vehicleType.Code;
                            bookingDto.StartAt = startDate;
                            bookingDto.EndAt = endDate;
                            bookingDto.Time = time;
                            bookingDto.UserId = user.Id;
                            bookingDto.DayOfWeeks = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };
                            //bookingDto.Type = Bookings.Types.MonthTicket;
                            bookingDto.IsShared = (new Random()).Next() % 10 < 9;
                            bookingDto.RouteCode = route.Code;
                            bookingDto.StartStationCode = stations[startIndex].Code;
                            bookingDto.EndStationCode = stations[endIndex].Code;

                            dynamic booking = (await AppServices.Booking.Create(bookingDto, new(), new(), new(), new(), new(), new(), new(),new(), new(), new(), true)).Data;

                            if (booking != null)
                                totalSuccessBooking++;
                            else
                                totalFailedBooking++;
                        }
                    }
                }
            }

            return Ok(new
            {
                Success = totalSuccessBooking,
                Fail = totalFailedBooking
            });
        }

        [HttpGet("checking-mapping")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckMapping()
        {
            var result = await AppServices.RouteRoutine.GetMappedBookingDetailDriverByRouteRoutine();

            return Ok(result);
        }

        [HttpPut("dump/completed-booking-details")]
        [AllowAnonymous]
        public async Task<IActionResult> DumpCompletedBookingDetails()
        {
            await AppServices.BookingDetail.SetCompletedBookingDetail();
            return Ok();
        }

        /// <summary>
        ///     Dump trip
        /// </summary>
        /// <remarks>
        /// ```
        /// Sample request:
        ///     POST api/tests/trips
        ///     {
        ///         DriverId = 3, // 1: Lợi, 2: Đạt, 3: Khoa, 4: Duy
        ///         UserIds = [5,6], // 5: Lợi, 6: Đạt, 7: Khoa, 8: Duy
        ///     }
        /// ```
        /// </remarks>
        [HttpPost("dump/trips")]
        [AllowAnonymous]
        public async Task<IActionResult> DumpTrips([FromBody] DumpTripRequest request) 
        {
            var driver = await AppServices.User.GetUserViewModelById(request.DriverId);
            var bookerIds = new List<int>
            {
                5, // Loi,
                6, // Dat,
                7, // Khoa,
                8, // Duy
            };

            if (!request.UserIds.Any())
                return BadRequest();

            if (request.UserIds.Any(id => !bookerIds.Contains(id)))
                return BadRequest();

            if (driver == null || driver.RoleName != Roles.DRIVER.GetName())
                return BadRequest();

            var nowTimeOnly = DateTimeExtensions.NowTimeOnly.AddMinutes(5);

            var nowDateOnly = DateTimeExtensions.NowDateOnly;

            

            dynamic routes = (await AppServices.Route.GetAll(new(), new())).Data;

            var route = routes[0] as RouteViewModel;

            var routeRoutine = (await AppServices.RouteRoutine.CreateRouteRoutines(new List<RouteRoutine>
            {
                new RouteRoutine
                {
                    UserId = request.DriverId,
                    RouteId = route.Id,
                    StartTime = nowTimeOnly,
                    EndTime = nowTimeOnly.AddMinutes(route.Duration/60),
                    StartAt = nowDateOnly,
                    EndAt = nowDateOnly,
                }
            }))[0];

            if (routeRoutine == null)
                return Problem();

            var ids = request.UserIds.Distinct();

            var totalSuccess = 0;

            foreach (var userId in ids)
            {
                var bookingDto = new BookingDTO();

                bookingDto.PaymentMethod = Payments.PaymentMethods.Wallet;
                bookingDto.VehicleTypeCode = driver.Vehicle.VehicleTypeCode;
                bookingDto.StartAt = nowDateOnly;
                bookingDto.EndAt = nowDateOnly;
                bookingDto.Time = nowTimeOnly;
                bookingDto.UserId = userId;
                bookingDto.DayOfWeeks = new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday , DayOfWeek.Sunday};
                //bookingDto.Type = Bookings.Types.MonthTicket;
                bookingDto.IsShared = driver.Vehicle.VehicleTypeId != VehicleTypes.SpecificType.ViRide;
                bookingDto.RouteCode = route.Code;
                bookingDto.StartStationCode = route.Stations[0].Code;

                var endIndex = 1 + (new Random()).Next() % (route.Stations.Count - 1);

                bookingDto.EndStationCode = route.Stations[endIndex].Code;

                var result = await AppServices.Booking.Create(bookingDto, new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), true, routeRoutine.Id);

                dynamic booking = result.Data;

                if (booking != null)
                    totalSuccess++;
            } 

            return Ok(totalSuccess);
        }

        //[HttpPost("dump/drivers")]
        //[AllowAnonymous]
        //public async Task<IActionResult> DumpDrivers()
        //{

        //}

        [HttpGet("test-deploy")]
        [AllowAnonymous]
        public async Task<IActionResult> TestDeploy()
        {
            return Ok("Deploy OK");
        }
    }
}
