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
        AllowedCancelTripPercent,
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
        DriverRegistrationFileSizeLimit
    }
}
