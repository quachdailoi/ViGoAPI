using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class SettingSeeder
    {
        public SettingSeeder(ModelBuilder builder)
        {
            builder.Entity<Setting>().HasData(new List<Setting>
            {
                new Setting
                {
                    Id = Settings.AllowedMappingTimeRange,
                    Key = Settings.AllowedMappingTimeRange.ToString(),
                    Value = "3"
                },
                new Setting
                {
                    Id = Settings.TradeDiscount,
                    Key = Settings.TradeDiscount.ToString(),
                    Value = "0.2"
                },
                new Setting
                {
                    Id = Settings.AllowedCancelTripPercent,
                    Key = Settings.AllowedCancelTripPercent.ToString(),
                    Value = "0.1"
                },
                new Setting
                {
                    Id = Settings.TimeAfterComplete,
                    Key = Settings.TimeAfterComplete.ToString(),
                    Value = "3"
                },
                new Setting
                {
                    Id = Settings.TimeBeforePickingUp,
                    Key = Settings.TimeBeforePickingUp.ToString(),
                    Value = "10"
                },
                new Setting
                {
                    Id = Settings.DefaultPageSize,
                    Key = Settings.DefaultPageSize.ToString(),
                    Value = "5"
                },
                new Setting
                {
                    Id = Settings.TimeRatingAfterComplete,
                    Key = Settings.TimeRatingAfterComplete.ToString(),
                    Value = "24"
                },
                new Setting
                {
                    Id = Settings.CheckingMappingStatusTime,
                    Key = Settings.CheckingMappingStatusTime.ToString(),
                    Value = new TimeOnly(20,00).ToString()
                },
                new Setting
                {
                    Id = Settings.NotifyTripInDayTime,
                    Key = Settings.NotifyTripInDayTime.ToString(),
                    Value = new TimeOnly(6,00).ToString()
                },
                new Setting
                {
                    Id = Settings.AllowedDriverCancelTripTime,
                    Key = Settings.AllowedDriverCancelTripTime.ToString(),
                    Value = new TimeOnly(19,45).ToString()
                },
                new Setting
                {
                    Id = Settings.TotalTripsCalculateRating,
                    Key = Settings.TotalTripsCalculateRating.ToString(),
                    Value = "100"
                },
                new Setting
                {
                    Id = Settings.MaxCancelledTripRate,
                    Key = Settings.MaxCancelledTripRate.ToString(),
                    Value = "0.1"
                },
                new Setting
                {
                    Id = Settings.NotifiedCancelledTripRate,
                    Key = Settings.NotifiedCancelledTripRate.ToString(),
                    Value = "0.08"
                },
                new Setting
                {
                    Id = Settings.TimeSpanRounded,
                    Key = Settings.TimeSpanRounded.ToString(),
                    Value = "5"
                },
                new Setting
                {
                    Id = Settings.TimeSpanBufferToCreateRoutine,
                    Key = Settings.TimeSpanBufferToCreateRoutine.ToString(),
                    Value = "5"
                },
                new Setting
                {
                    Id = Settings.TimeToCreateTomorrowRoutine,
                    Key = Settings.TimeToCreateTomorrowRoutine.ToString(),
                    Value = "20:00:00"
                },
                new Setting
                {
                    Id = Settings.RadiusNearbyStation,
                    Key = Settings.RadiusNearbyStation.ToString(),
                    Value = "6000"
                },
                new Setting
                {
                    Id = Settings.RadiusToComplete,
                    Key = Settings.RadiusToComplete.ToString(),
                    Value = "100"
                },
                new Setting
                {
                    Id = Settings.LastDayNumberForNextMonthRoutine,
                    Key = Settings.LastDayNumberForNextMonthRoutine.ToString(),
                    Value = "7"
                },
                new Setting
                {
                    Id = Settings.DiscountPerEachSharingCase,
                    Key = Settings.DiscountPerEachSharingCase.ToString(),
                    Value = "0.1"
                }
            });
        }
    }
}
