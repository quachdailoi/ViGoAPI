using API.Models;
using API.Services.Constract;
using API.Utils;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;

namespace API.Services
{
    public class FareService : IFareService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVehicleTypeService _vehicleTypeService;

        public FareService(IMapper mapper, IUnitOfWork unitOfWork, IVehicleTypeService vehicleTypeService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _vehicleTypeService = vehicleTypeService;
        }
        public async Task<FeeViewModel> CaculateBookingFee(Bookings.Types bookingType, int vehicleTypeId, DateOnly startDate, DateOnly endDate, double distance, TimeOnly time, double discount = 0)
        {
            var feePerTrip = await CaculateFeeByDistance(vehicleTypeId, distance, time);

            var bookingFee = Fee.CaculateFeeByBookingType(bookingType, feePerTrip.TotalFee, startDate, endDate);

            var discountFee = discount;

            return new FeeViewModel
            {
                FeePerTrip = feePerTrip.TotalFee,
                Fee = bookingFee,
                DiscountFee = discountFee,
                TotalFee = bookingFee - discountFee
            };
        }

        public async Task<FeeViewModel> CaculateFeeByDistance(int vehicleTypeId, double distance, TimeOnly time)
        {
            var vehicleTypeWithFare = await _vehicleTypeService.GetWithFare();

            var fare = vehicleTypeWithFare.Find(vehicleType => vehicleType.Id == vehicleTypeId).Fare;

            var extraByTimeline = fare.FareTimelines.Find(timeline => timeline.StartTime.CompareTo(time) <= 0 && timeline.EndTime.CompareTo(time) > 0);

            var feePerTrip = fare.BasePrice;

            if(distance > fare.BaseDistance) feePerTrip += (distance - fare.BaseDistance) / 1000 * fare.PricePerKm;

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
    }
}
