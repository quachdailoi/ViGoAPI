﻿using Domain.Entities;
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
                    Value = "3",
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Minutes
                },
                new Setting
                {
                    Id = Settings.TradeDiscount,
                    Key = Settings.TradeDiscount.ToString(),
                    Value = "0.2",
                    TypeId = SettingTypes.Pricing,
                    DataTypeId = SettingDataTypes.Double,
                    DataUnitId = SettingDataUnits.Percent
                },
                new Setting
                {
                    Id = Settings.TimeAfterComplete,
                    Key = Settings.TimeAfterComplete.ToString(),
                    Value = "3",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Minutes
                },
                new Setting
                {
                    Id = Settings.TimeBeforeToPickUp,
                    Key = Settings.TimeBeforeToPickUp.ToString(),
                    Value = "10",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Minutes
                },
                new Setting
                {
                    Id = Settings.DefaultPageSize,
                    Key = Settings.DefaultPageSize.ToString(),
                    Value = "5",
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Default
                },
                new Setting
                {
                    Id = Settings.TimeRatingAfterComplete,
                    Key = Settings.TimeRatingAfterComplete.ToString(),
                    Value = "24",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Hours
                },
                new Setting
                {
                    Id = Settings.CheckingMappingStatusTime,
                    Key = Settings.CheckingMappingStatusTime.ToString(),
                    Value = "20:00:00",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Time,
                    DataUnitId = SettingDataUnits.Time
                },
                new Setting
                {
                    Id = Settings.NotifyTripInDayTime,
                    Key = Settings.NotifyTripInDayTime.ToString(),
                    Value = "06:00:00",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Time,
                    DataUnitId = SettingDataUnits.Time
                },
                new Setting
                {
                    Id = Settings.AllowedDriverCancelTripTime,
                    Key = Settings.AllowedDriverCancelTripTime.ToString(),
                    Value = "19:45:00",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Time,
                    DataUnitId = SettingDataUnits.Time
                },
                new Setting
                {
                    Id = Settings.TotalTripsCalculateRating,
                    Key = Settings.TotalTripsCalculateRating.ToString(),
                    Value = "100",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Turn
                },
                new Setting
                {
                    Id = Settings.MaxCancelledTripRate,
                    Key = Settings.MaxCancelledTripRate.ToString(),
                    Value = "0.1",
                    TypeId = SettingTypes.Penalty,
                    DataTypeId = SettingDataTypes.Double,
                    DataUnitId = SettingDataUnits.Percent
                },
                new Setting
                {
                    Id = Settings.NotifiedCancelledTripRate,
                    Key = Settings.NotifiedCancelledTripRate.ToString(),
                    Value = "0.08",
                    TypeId = SettingTypes.Penalty,
                    DataTypeId = SettingDataTypes.Double,
                    DataUnitId = SettingDataUnits.Percent
                },
                new Setting
                {
                    Id = Settings.TimeSpanRounded,
                    Key = Settings.TimeSpanRounded.ToString(),
                    Value = "5",
                    TypeId = SettingTypes.Default,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Minutes
                },
                new Setting
                {
                    Id = Settings.TimeSpanBufferToCreateRoutine,
                    Key = Settings.TimeSpanBufferToCreateRoutine.ToString(),
                    Value = "5",
                    TypeId = SettingTypes.Default,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Minutes
                },
                new Setting
                {
                    Id = Settings.TimeToCreateTomorrowRoutine,
                    Key = Settings.TimeToCreateTomorrowRoutine.ToString(),
                    Value = "20:00:00",
                    TypeId = SettingTypes.RouteRoutine,
                    DataTypeId = SettingDataTypes.Time,
                    DataUnitId = SettingDataUnits.Time
                },
                new Setting
                {
                    Id = Settings.RadiusNearbyStation,
                    Key = Settings.RadiusNearbyStation.ToString(),
                    Value = "6000",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Meters
                },
                new Setting
                {
                    Id = Settings.RadiusToComplete,
                    Key = Settings.RadiusToComplete.ToString(),
                    Value = "100",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Meters
                },
                new Setting
                {
                    Id = Settings.LastDayNumberForNextMonthRoutine,
                    Key = Settings.LastDayNumberForNextMonthRoutine.ToString(),
                    Value = "7",
                    TypeId = SettingTypes.RouteRoutine,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Days
                },
                new Setting
                {
                    Id = Settings.DiscountPerEachSharingCase,
                    Key = Settings.DiscountPerEachSharingCase.ToString(),
                    Value = "0.1",
                    TypeId = SettingTypes.Pricing,
                    DataTypeId = SettingDataTypes.Double,
                    DataUnitId = SettingDataUnits.Percent
                },
                new Setting
                {
                    Id = Settings.DriverRegistrationFileSizeLimit,
                    Key = Settings.DriverRegistrationFileSizeLimit.ToString(),
                    Value = "20",
                    TypeId = SettingTypes.Default,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.MB
                },
                new Setting
                {
                    Id = Settings.ThresholdDiscountPerEachSharingCase,
                    Key = Settings.ThresholdDiscountPerEachSharingCase.ToString(),
                    Value = "0.5",
                    TypeId = SettingTypes.Pricing,
                    DataTypeId = SettingDataTypes.Double,
                    DataUnitId = SettingDataUnits.Percent
                },
                new Setting
                {
                    Id = Settings.AllowedCancelAfterCreateBookingTime,
                    Key = Settings.AllowedCancelAfterCreateBookingTime.ToString(),
                    Value = "30",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Double,
                    DataUnitId = SettingDataUnits.Percent
                },
                new Setting
                {
                    Id = Settings.AllowedBookerCancelTripTime,
                    Key = Settings.AllowedBookerCancelTripTime.ToString(),
                    Value = "19:45:00",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Time,
                    DataUnitId = SettingDataUnits.Time
                },
                new Setting
                {
                    Id = Settings.TradeDisountForBookerCancelTrip,
                    Key = Settings.TradeDisountForBookerCancelTrip.ToString(),
                    Value = "0.1",
                    TypeId = SettingTypes.Pricing,
                    DataTypeId = SettingDataTypes.Double,
                    DataUnitId = SettingDataUnits.Percent
                },
                new Setting
                {
                    Id = Settings.BannerFileSizeLimit,
                    Key = Settings.BannerFileSizeLimit.ToString(),
                    Value = "20",
                    TypeId = SettingTypes.Default,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.MB
                },
                new Setting
                {
                    Id = Settings.PromotionFileSizeLimit,
                    Key = Settings.PromotionFileSizeLimit.ToString(),
                    Value = "20",
                    TypeId = SettingTypes.Default,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.MB
                },
                new Setting
                {
                    Id = Settings.TimeBeforeToStartTrip,
                    Key = Settings.TimeBeforeToStartTrip.ToString(),
                    Value = "60",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Minutes
                },
                new Setting
                {
                    Id = Settings.TimeAfterToStartTrip,
                    Key = Settings.TimeAfterToStartTrip.ToString(),
                    Value = "5",
                    TypeId = SettingTypes.Trip,
                    DataTypeId = SettingDataTypes.Integer,
                    DataUnitId = SettingDataUnits.Minutes
                },
            });
        }
    }
}
