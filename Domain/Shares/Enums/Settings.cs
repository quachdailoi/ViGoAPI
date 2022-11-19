﻿using System;
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
        DriverRegistrationFileSizeLimit

    }

    public enum SettingTypes
    {
        Trip = 1,
        Penalty = 2,
        RouteRoutine = 3,
        Pricing = 4
    }
}
