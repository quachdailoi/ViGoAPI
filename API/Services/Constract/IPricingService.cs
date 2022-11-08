using API.Models;
using Domain.Entities;

namespace API.Services.Constract
{
    public interface IPricingService
    {
        Task<List<Pricing>> Get();
        Task<FeeViewModel> CaculateBookingFee(int totalBookingDetails, FeeViewModel feePerTrip);
    }
}
