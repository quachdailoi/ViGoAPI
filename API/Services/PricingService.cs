using API.Models;
using API.Services.Constract;
using API.Utils;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class PricingService : BaseService, IPricingService
    {
        public PricingService(IAppServices appServices) : base(appServices)
        {
        }

        public async Task<FeeViewModel> CaculateBookingFee(int totalBookingDetails, FeeViewModel feePerTrip)
        {
            var pricings = await Get();

            double fee = feePerTrip.TotalFee * totalBookingDetails;

            var pricing = pricings.Where(e => (e.LowerBound == null || totalBookingDetails >= e.LowerBound) && (e.UpperBound == null || totalBookingDetails <= e.UpperBound)).FirstOrDefault();

            if (pricing != null) 
            {
                feePerTrip.DiscountFee = Fee.FloorToThousands(feePerTrip.TotalFee * pricing.Discount);

                if (feePerTrip.DiscountFee < 1000 && pricing.Discount > 0) feePerTrip.DiscountFee = 1000;
            }  

            feePerTrip.TotalFee -= feePerTrip.DiscountFee;

            var totalFee = feePerTrip.TotalFee * totalBookingDetails;

            //foreach(var pricing in pricings)
            //{
            //    var lowerBound = pricing.LowerBound ?? 1;
            //    var upperBound = pricing.UpperBound ?? Int32.MaxValue;
            //    var discount = pricing.Discount;  

            //    if (totalBookingDetails < lowerBound)
            //        continue;

            //    var totalInRange = totalBookingDetails - lowerBound + 1;

            //    if (upperBound < totalBookingDetails)
            //    {
            //        totalInRange = upperBound - lowerBound + 1;
            //    }

            //    fee += totalInRange * feePerTrip * (1 - discount);
            //}

            return new FeeViewModel
            {
                FeePerTrip = feePerTrip,
                Fee = fee,
                DiscountFee = fee - totalFee,
                TotalFee = totalFee
            };
        }

        public Task<List<Pricing>> Get() => UnitOfWork.Pricings.Get();
    }
}
