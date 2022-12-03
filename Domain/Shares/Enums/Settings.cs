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
        Percent,
        Minutes,
        Hours,
        Days,
        Meters,
        Turn,
        Time
    }

    public static class SettingExtension
    {
        public static Tuple<SettingDataTypes, string> GetUnitAndDataType(this Settings setting)
        {
            switch (setting)
            {
                case Settings.TradeDiscount:
                case Settings.MaxCancelledTripRate:
                case Settings.NotifiedCancelledTripRate:
                case Settings.DiscountPerEachSharingCase:
                case Settings.ThresholdDiscountPerEachSharingCase:
                case Settings.TradeDisountForBookerCancelTrip:
                    return new Tuple<SettingDataTypes, string>(SettingDataTypes.Double, "%");
                case Settings.AllowedMappingTimeRange:
                case Settings.TimeAfterComplete:
                case Settings.TimeBeforePickingUp:
                case Settings.TimeSpanRounded:
                case Settings.TimeSpanBufferToCreateRoutine:
                case Settings.AllowedCancelAfterCreateBookingTime:
                    return new Tuple<SettingDataTypes, string>(SettingDataTypes.Integer, "minutes");
                case Settings.TimeRatingAfterComplete:
                    return new Tuple<SettingDataTypes, string>(SettingDataTypes.Integer, "hours");
                case Settings.LastDayNumberForNextMonthRoutine:
                    return new Tuple<SettingDataTypes, string>(SettingDataTypes.Integer, "days");
                case Settings.RadiusNearbyStation:
                case Settings.RadiusToComplete:
                    return new Tuple<SettingDataTypes, string>(SettingDataTypes.Integer, "meters");
                case Settings.TotalTripsCalculateRating:
                    return new Tuple<SettingDataTypes, string>(SettingDataTypes.Integer, "turn");
                case Settings.CheckingMappingStatusTime:
                case Settings.NotifyTripInDayTime:
                case Settings.AllowedDriverCancelTripTime:
                case Settings.TimeToCreateTomorrowRoutine:
                case Settings.AllowedBookerCancelTripTime:
                    return new Tuple<SettingDataTypes, string>(SettingDataTypes.Time, "time");
                default:
                    return new Tuple<SettingDataTypes, string>(SettingDataTypes.Default, String.Empty);
            }
        }
    }
    
}
