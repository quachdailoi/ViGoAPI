using API.Models;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IFareService
    {
        Task<FeeViewModel> CaculateFeeByDistance(VehicleTypes.SpecificType vehicleTypeId, double distance, TimeOnly time, bool includeBasePrice = true);
        Task<FeeViewModel> CaculateBookingFee(Bookings.Types bookingType, VehicleTypes.SpecificType vehicleTypeId, DateOnly startDate, DateOnly endDate, double distance, TimeOnly time, double discount = 0);
        Task<FeeViewModel> CaculateBookingFee(VehicleTypes.SpecificType vehicleTypeId, DateOnly startDate, DateOnly endDate, List<DayOfWeek> dayOfWeeks, double distance, TimeOnly time, double discount = 0);
        Task<FeeViewModel> CaculateFeePerTrip(VehicleTypes.SpecificType vehicleTypeId, DateOnly startDate, DateOnly endDate, List<DayOfWeek> dayOfWeeks, double distance, TimeOnly time);
    }
}
