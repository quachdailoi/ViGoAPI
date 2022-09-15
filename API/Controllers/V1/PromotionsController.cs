using API.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(Roles = "BOOKER")]
    public class PromotionsController : BaseController<PromotionsController>
    {
        public PromotionsController()
        {
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserPromotions()
        {
            var loggedInUser = LoggedInUser;

            var userPromotionsResponse = 
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

            return ApiResult(userPromotionsResponse);
        }

        [HttpGet("booking")]
        public async Task<IActionResult> GetBookingPromotions([FromQuery] BookingPromotionRequest request)
        {
            var loggedInUser = LoggedInUser;

            var bookingPromotionsResponse =
                await AppServices.Promotion.GetAvailablePromotion(
                    loggedInUser.Id,
                    request,
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

            return ApiResult(bookingPromotionsResponse);
        }

        [HttpGet("banner")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBannerPromotions()
        {
            var bannerPromotionsResponse = 
                await AppServices.Promotion.GetBannerPromotion(
                    successResponse: new()
                    {
                        StatusCode = StatusCodes.Status200OK,
                        Message = "Get banner promotions successfully."
                    },
                    emptyResponse: new()
                    {
                        StatusCode = StatusCodes.Status204NoContent,
                        Message = "Not found banner promotions."
                    }
                );

            return ApiResult(bannerPromotionsResponse);
        }
    }
}
