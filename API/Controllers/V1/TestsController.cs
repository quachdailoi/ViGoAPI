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
        public async Task<IActionResult> Test([FromQuery] int number)
        {
            //var uri = GetControllerContextUri();
            //var routers = ControllerContext.RouteData.Routers;
            //await _redisMQMessage.Publish("number",number);

            TimeOnly startTime = new TimeOnly(12, 10);
            TimeOnly endTime = new TimeOnly(12, 15);



            //var momoRequestType = Payments.MomoRequestType.CaptureWallet.DisplayName();

            return Ok((startTime - endTime).TotalMinutes);
        }

        [HttpPost("dump/drivers")]
        [AllowAnonymous]
        public async Task<IActionResult> DumpDrivers([FromQuery] DumpDriverRequest request)
        {
            dynamic vehicleTypes = (await AppServices.VehicleType.GetAll(new())).Data;

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
                        VehicleTypeId = vehicleTypeVM.Id,
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
            dynamic vehicleTypes = (await AppServices.VehicleType.GetAll(new())).Data;

            dynamic routes = (await AppServices.Route.GetAll(new(),new())).Data;

            var users = await AppServices.User.GetByRole(Roles.BOOKER);

            var route = routes[0];

            var routeRoutines = await AppServices.RouteRoutine.GetByRouteId((int)route.Id);

            var totalSuccessBooking = 0;

            foreach(var user in users)
            {
                foreach (dynamic type in vehicleTypes)
                {
                    foreach (dynamic vehicleType in type.VehicleTypes)
                    {
                        if (vehicleType.Type == VehicleTypes.Type.ViRide) continue;

                        var fitRouteRoutines = routeRoutines
                            .Where(routeRoutine =>
                                routeRoutine.User.Vehicle.VehicleTypeId == vehicleType.Id)
                            .ToList();

                        foreach (var routeRoutine in fitRouteRoutines)
                        {
                            var timeDuration = (routeRoutine.EndTime.ToTimeSpan() - routeRoutine.StartTime.ToTimeSpan()).TotalMinutes;

                            var time = routeRoutine.StartTime.AddMinutes(((new Random()).Next() % 4) * 5);

                            var dateDuration = routeRoutine.EndAt.ToDateTime(TimeOnly.MinValue).Subtract(routeRoutine.StartAt.ToDateTime(TimeOnly.MinValue)).TotalDays;

                            var startDate = routeRoutine.StartAt.AddDays(((new Random()).Next() % (int)Math.Floor(dateDuration)));
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
                            bookingDto.Type = Bookings.Types.MonthTicket;
                            bookingDto.IsShared = (new Random()).Next() % 10 < 9;
                            bookingDto.RouteCode = route.Code;
                            bookingDto.StartStationCode = stations[startIndex].Code;
                            bookingDto.EndStationCode = stations[endIndex].Code;

                            dynamic booking = (await AppServices.Booking.Create(bookingDto, new(), new(), new(), new(), new(), new(), new(),new(), new(), new())).Data;

                            if (booking != null) totalSuccessBooking++;
                        }
                    }
                }
            }

            return Ok(totalSuccessBooking);
        }

        [HttpGet("checking-mapping")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckMapping()
        {
            var result = await AppServices.RouteRoutine.GetMappedBookingDetailDriverByRouteRoutine();

            return Ok(result);
        }

        //[HttpPost("dump/drivers")]
        //[AllowAnonymous]
        //public async Task<IActionResult> DumpDrivers()
        //{

        //}
    }
}
