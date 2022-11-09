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
            });
        }
    }
}
