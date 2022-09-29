using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
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

		[HttpGet("user")]
        public async Task<IActionResult> GetUser(string code)
        {
            var user = await _unitOfWork.Users.GetUserByCode(code).FirstOrDefaultAsync();
            return Ok(user);
        }

        [HttpGet("momo-link")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMomoLink()
        {
            //var req = Request;
            //var host = HttpContext.Request.Host;
            var api = $"{Request.Scheme}://{Request.Host}{Request.Path}";
            var result =
                await AppServices.Payment.GenerateMomoPaymentUrl(
                    orderId: 1,
                    amount: 100000,
                    items: new()
                    {
                        new()
                        {
                            Id = "1",
                            Name = "Items 1",
                            Category = "Cate 1",
                            Price = 50000,
                            Quantity = 2,
                            Unit = "Ticket"
                        }
                    },
                    userInfo: new()
                    {
                        Email = "test@gmail.com",
                        PhoneNumber = "0916220535",
                        Name = "Passenger 1"
                    }
                    );
            return Ok(result);
            //return Ok(api);
        }

        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult Test()
        //{
        //    var total = 5;
        //    var current = 0;
        //    var numbers = new List<Number>();

        //    while(current < total)
        //    {

        //    }

        //    return Ok();
        //}

        //class Number
        //{
        //    public int Value { get; set; }
        //    public Number? NextNumber { get; set; } = null;
        //}
    }
}
