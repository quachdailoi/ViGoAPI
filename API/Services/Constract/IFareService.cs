using API.Models;
using Domain.Shares.Enums;

namespace API.Services.Constract
{
    public interface IFareService
    {
        Task<FeeViewModel> CaculateFeeByDistance(int vehicleTypeId, double distance, TimeOnly time);
        Task<FeeViewModel> CaculateBookingFee(Bookings.Types bookingType, int vehicleTypeId, DateOnly startDate, DateOnly endDate, double distance, TimeOnly time, double discount = 0);
    }
}
