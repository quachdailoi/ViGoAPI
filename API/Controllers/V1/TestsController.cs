using API.Models.DTO;
using API.Models.Requests;
using API.TaskQueues;
using API.Utils;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Classes;
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

        [HttpGet("dump-routes")]
        [AllowAnonymous]
        public IActionResult DumpRoute([FromQuery] int numberOfRoute, int minStepPerRoute, int maxStepPerRoute, int numberOfStation)
        {
            var result = DumpData.DumpRoute(
                numberOfRoute, 
                minStepPerRoute, 
                maxStepPerRoute, 
                numberOfStation, 
                new Bound // HCM city bound (~~)
                {
                    South = 10.757931, 
                    West = 106.599666,
                    North = 10.858637,
                    East = 106.832535
                });
            return new JsonResult(new
            {
                Routes = result.Item1,
                Stations = result.Item3
            });
        }
    }
}
