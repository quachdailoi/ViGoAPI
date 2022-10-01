using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public TestsController(IUnitOfWork unitOfWork, ILogger<TestsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
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
        
        [HttpGet()]
        [AllowAnonymous]
        public IActionResult TestLogMultipleFiles()
        {
            _logger.LogError("ABC");
            return Ok();
        }
    }
}
