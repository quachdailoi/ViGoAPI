using Domain.Entities;

namespace API.Services.Constract
{
    public interface IPricingService
    {
        Task<List<Pricing>> Get();
        Task<double> CaculateBookingFee(int totalBookingDetails, double feePerTrip);
    }
}
