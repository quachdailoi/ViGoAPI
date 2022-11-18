using API.Extensions;
using API.Models;
using API.Services.Constract;
using API.Utils;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;

namespace API.Services
{
    public class FareService : BaseService, IFareService
    {
        public FareService(IAppServices appServices) : base(appServices)
        {

        }

        public async Task<FeeViewModel> CaculateBookingFee(Bookings.Types bookingType, int vehicleTypeId, DateOnly startDate, DateOnly endDate, double distance, TimeOnly time, double discount = 0)
        {
            var feePerTrip = await CaculateFeeByDistance(vehicleTypeId, distance, time);

            var bookingFee = Fee.CaculateFeeByBookingType(bookingType, feePerTrip.TotalFee, startDate, endDate);
            
            var discountFee = discount;

            return new FeeViewModel
            {
                FeePerTrip = feePerTrip,
                Fee = bookingFee,
                DiscountFee = discountFee,
                TotalFee = bookingFee - discountFee
            };
        }

        public async Task<FeeViewModel> CaculateBookingFee(int vehicleTypeId, DateOnly startDate, DateOnly endDate, List<DayOfWeek> dayOfWeeks, double distance, TimeOnly time, double discount = 0)
        {
            var feePerTrip = await CaculateFeeByDistance(vehicleTypeId, distance, time);

            var dates = endDate.ToDates(startDate, dayOfWeeks); 

            var bookingFee = await AppServices.Pricing.CaculateBookingFee(dates.Count, feePerTrip);

            feePerTrip.TotalFee = Fee.RoundToThousands(bookingFee.TotalFee / dates.Count);

            bookingFee.TotalFee = feePerTrip.TotalFee * dates.Count;

            var discountFee = discount;

            return new FeeViewModel
            {
                FeePerTrip = feePerTrip,
                Fee = bookingFee.TotalFee,
                DiscountFee = bookingFee.DiscountFee + discountFee,
                TotalFee = bookingFee.TotalFee - (bookingFee.DiscountFee + discountFee)
            };
        }

        public async Task<FeeViewModel> CaculateFeeByDistance(int vehicleTypeId, double distance, TimeOnly time, bool includeBasePrice = true)
        {
            var vehicleTypeWithFare = await AppServices.VehicleType.GetWithFare();

            var fare = vehicleTypeWithFare.Find(vehicleType => vehicleType.Id == vehicleTypeId).Fare;

            var extraByTimeline = fare.FareTimelines.Find(timeline => timeline.StartTime.CompareTo(time) <= 0 && timeline.EndTime.CompareTo(time) > 0);

            var feePerTrip = distance / 1000 * fare.PricePerKm;

            if (includeBasePrice)
            {
                feePerTrip = fare.BasePrice;

                if (distance > fare.BaseDistance) feePerTrip += (distance - fare.BaseDistance) / 1000 * fare.PricePerKm;
            }

            feePerTrip = Fee.RoundToThousands(feePerTrip);

            var extraFee = extraByTimeline != null ? Fee.RoundToThousands(distance / 1000 * extraByTimeline.ExtraFeePerKm) : 0;

            if (extraFee > extraByTimeline?.CeilingExtraPrice) extraFee = extraByTimeline.CeilingExtraPrice;

            return new FeeViewModel
            {
                Fee = feePerTrip,
                ExtraFee = extraFee,
                TotalFee = feePerTrip + extraFee
            };
        }

        public async Task<FeeViewModel> CaculateFeePerTrip(int vehicleTypeId, DateOnly startDate, DateOnly endDate, List<DayOfWeek> dayOfWeeks, double distance, TimeOnly time)
        {
            var feePerTrip = await CaculateFeeByDistance(vehicleTypeId, distance, time);

            var dates = endDate.ToDates(startDate, dayOfWeeks);

            feePerTrip = (await AppServices.Pricing.CaculateBookingFee(dates.Count, feePerTrip)).FeePerTrip;

            //feePerTrip.TotalFee = Fee.RoundToThousands(bookingFee / dates.Count);

            return feePerTrip;
        }
    }
}
