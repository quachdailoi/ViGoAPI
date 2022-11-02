using API.Services.Constract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class PricingService : BaseService, IPricingService
    {
        public PricingService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<double> CaculateBookingFee(int totalBookingDetails, double feePerTrip)
        {
            var pricings = await Get();

            double fee = 0;

            foreach(var pricing in pricings)
            {
                var lowerBound = pricing.LowerBound ?? 1;
                var upperBound = pricing.UpperBound ?? Int32.MaxValue;
                var discount = pricing.Discount;  

                if (totalBookingDetails < lowerBound)
                    continue;

                var totalInRange = totalBookingDetails - lowerBound + 1;

                if (upperBound < totalBookingDetails)
                {
                    totalInRange = upperBound - lowerBound + 1;
                }

                fee += totalInRange * feePerTrip * (1 - discount);
            }

            return fee;
        }

        public Task<List<Pricing>> Get() => UnitOfWork.Pricings.Get();
    }
}
