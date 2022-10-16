﻿using API.Models.DTO;
using API.TaskQueues;
using API.Utils;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace API.Controllers.V2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    [ApiVersion("2.0")]
    public class TestsController : BaseController<TestsController>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public IBackgroundTaskQueue _queue { get; }
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TestsController(IUnitOfWork unitOfWork, ILogger<TestsController> logger, IBackgroundTaskQueue queue, IServiceScopeFactory serviceScopeFactory)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

            _queue = queue;
            _serviceScopeFactory = serviceScopeFactory;
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
        
        [HttpGet("create-routes")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRoutes()
        {

            //_queue.QueueBackgroundWorkItem(CreateRouteTask); // background task

            await CreateRouteTask(); // must done

            return Ok("Please wait for adding new route.");
        }

        private async Task CreateRouteTask()
        {
            var listOfStationIds = DumpRoutes.GetListStationIdsToDumpRoutes();

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;

                foreach (var stationIds in listOfStationIds)
                {
                    var stationDtos = await AppServices.Station.GetStationDTOsByIds(stationIds);
                    var newRoute = await AppServices.RapidApi.CreateRouteByListOfStation(stationDtos);

                    Console.WriteLine($"Route added with ID: {newRoute.Id}");
                    await Task.Delay(TimeSpan.FromSeconds(2));
                }
            }
        }
    }
}
