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
        AllowedMappingTimeRange = 1,
        AllowedCancelTripPercent = 2,
        TimeBeforePickingUp = 3,
        TimeAfterComplete = 4,
        TradeDiscount = 5,
        DefaultPageSize = 6,
        TimeRatingAfterComplete = 7,
        CheckingMappingStatusTime = 8,
        NotifyTripInDayTime = 9,
        AllowedDriverCancelTripTime = 10,
        DiscountPerEachSharingCase = 11,

    }
}
