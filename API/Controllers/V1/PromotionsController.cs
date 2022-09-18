using API.Helpers.Attributes;
using API.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize("BOOKER")]
    public class PromotionsController : BaseController<PromotionsController>
    {
        public PromotionsController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetUserPromotions()
        {
            var loggedInUser = LoggedInUser;

            var promotions = 
                await AppServices.Promotion.GetAvailablePromotion(
                    loggedInUser.Id,
                    successResponse: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Get user's available promotions successfully."
                    },
                    emptyResponse: new()
                    {
                        StatusCode = StatusCodes.Status204NoContent,
                        Message = "Not found available promotions."
                    });

            return Ok(promotions);
        }

        [HttpGet("booking")]
        public async Task<IActionResult> GetBookingPromotions([FromQuery] BookingPromotionRequest request)
        {
            var loggedInUser = LoggedInUser;

            var promotions =
                await AppServices.Promotion.GetAvailablePromotion(
                    loggedInUser.Id,
                    request.TotalPrice,
                    request.TotalTickets,
                    successResponse: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Get user's available promotions successfully."
                    },
                    emptyResponse: new()
                    {
                        StatusCode = StatusCodes.Status204NoContent,
                        Message = "Not found available promotions."
                    });

            return Ok(promotions);
        }
    }
}
