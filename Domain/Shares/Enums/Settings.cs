using Domain.Interfaces.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public enum Settings
    {
        AllowedMappingTimeRange,
        TimeBeforePickingUp,
        TimeAfterComplete,
        TradeDiscount,
        DefaultPageSize,
        TimeRatingAfterComplete,
        CheckingMappingStatusTime,
        NotifyTripInDayTime,
        AllowedDriverCancelTripTime,
        TotalTripsCalculateRating,
        TotalTripsCalculateCancelledRate,
        MaxCancelledTripRate,
        NotifiedCancelledTripRate,
        TimeSpanRounded,
        TimeSpanBufferToCreateRoutine,
        TimeToCreateTomorrowRoutine,
        RadiusNearbyStation,
        RadiusToComplete,
        LastDayNumberForNextMonthRoutine,
        DiscountPerEachSharingCase,
        ThresholdDiscountPerEachSharingCase,
        AllowedCancelAfterCreateBookingTime,
        AllowedBookerCancelTripTime,
        TradeDisountForBookerCancelTrip,
        DriverRegistrationFileSizeLimit,
        BannerFileSizeLimit,
        PromotionFileSizeLimit,
        TimeBeforeStartTrip
    }

    public enum SettingTypes
    {
        Default = 0,
        Trip = 1,
        Penalty = 2,
        RouteRoutine = 3,
        Pricing = 4
    }

    public enum SettingDataTypes
    {
        Integer = 1, 
        Double = 2,
        Time = 3,
        Default = 0
    }

    public enum SettingDataUnits
    {
        Default = 0,
        Percent = 1,
        Minutes = 2,
        Hours = 3,
        Days = 4,
        Meters = 5,
        Turn = 6,
        Time = 7,
        MB = 8
    }
}
