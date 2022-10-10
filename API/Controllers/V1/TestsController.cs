using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.TaskQueues;
using API.Utils;
using AutoMapper;
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

            var momoRequestType = Payments.MomoRequestType.CaptureWallet.DisplayName();

            return Ok(number);
        }

        [HttpPost("dump/bookings")] // dump bookings
        [AllowAnonymous]
        public async Task<IActionResult> DumpBookings()
        {
            dynamic vehicleTypes = (await AppServices.VehicleType.GetAll(new())).Data;

            dynamic routes = (await AppServices.Route.GetAll(new())).Data;

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
                        var fitRouteRoutines = routeRoutines
                            .Where(routeRoutine =>
                                routeRoutine.User.Vehicle.VehicleTypeId == vehicleType.Id)
                            .ToList();

                        foreach (var routeRoutine in fitRouteRoutines)
                        {
                            var timeDuration = (routeRoutine.EndTime.ToTimeSpan() - routeRoutine.StartTime.ToTimeSpan()).TotalMinutes;

                            var time = routeRoutine.StartTime.AddMinutes(((new Random()).Next() % Math.Floor(timeDuration)));

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
                            bookingDto.IsShared = (vehicleType.Type == VehicleTypes.Type.ViRide) ? false : (new Random()).Next() % 10 < 9;
                            bookingDto.RouteCode = route.Code;
                            bookingDto.StartStationCode = stations[startIndex].Code;
                            bookingDto.EndStationCode = stations[endIndex].Code;

                            dynamic booking = (await AppServices.Booking.Create(bookingDto, new(), new(), new(), new(), new(), new(), new(), new(), new())).Data;

                            if (booking != null) totalSuccessBooking++;
                        }
                    }
                }
            }

            return Ok(totalSuccessBooking);
        }
    }
}
