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
    public class PromotionConditionSeeder
    {
        public PromotionConditionSeeder(ModelBuilder builder)
        {
            builder.Entity<PromotionCondition>().HasData(new PromotionCondition
            {
                Id = 1,
                PromotionId = 1,
                TotalUsage = null,
                UsagePerUser = 1,
                ValidFrom = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-01-01T00:00:01Z")),
                ValidUntil = null,
                MinTotalPrice = 500000,
                MinTickets = null,
                PaymentMethods = null
            });

            builder.Entity<PromotionCondition>().HasData(new PromotionCondition
            {
                Id = 2,
                PromotionId = 2,
                TotalUsage = 50,
                UsagePerUser = 4,
                ValidFrom = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-09-01T00:00:01Z")),
                ValidUntil = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-09-30T23:59:59Z")),
                MinTotalPrice = 200000,
                MinTickets = null,
                PaymentMethods = null
            });

            builder.Entity<PromotionCondition>().HasData(new PromotionCondition
            {
                Id = 3,
                PromotionId = 3,
                TotalUsage = 50,
                UsagePerUser = 1,
                ValidFrom = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-09-02T00:00:01Z")),
                ValidUntil = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-09-02T23:59:59Z")),
                MinTotalPrice = 1000000,
                MinTickets = null,
                PaymentMethods = null
            });

            builder.Entity<PromotionCondition>().HasData(new PromotionCondition
            {
                Id = 4,
                PromotionId = 4,
                TotalUsage = 50,
                UsagePerUser = 1,
                ValidFrom = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-09-02T00:00:01Z")),
                ValidUntil = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-09-30T23:59:59Z")),
                MinTotalPrice = 500000,
                MinTickets = 20,
                PaymentMethods = null
            });

            builder.Entity<PromotionCondition>().HasData(new PromotionCondition
            {
                Id = 5,
                PromotionId = 5,
                TotalUsage = 500,
                UsagePerUser = 3,
                ValidFrom = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-01-01T00:00:01Z")),
                ValidUntil = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-12-31T23:59:59Z")),
                MinTotalPrice = 300000,
                MinTickets = null,
                PaymentMethods = null,
                VehicleTypes = VehicleTypes.ViRide
            });

            builder.Entity<PromotionCondition>().HasData(new PromotionCondition
            {
                Id = 6,
                PromotionId = 6,
                TotalUsage = 500,
                UsagePerUser = 3,
                ValidFrom = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-01-01T00:00:01Z")),
                ValidUntil = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-12-31T23:59:59Z")),
                MinTotalPrice = 500000,
                MinTickets = null,
                PaymentMethods = null,
                VehicleTypes = VehicleTypes.ViCar_4
            });
        }
    }
}
