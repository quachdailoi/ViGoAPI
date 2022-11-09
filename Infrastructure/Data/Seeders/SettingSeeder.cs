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
                }
            });
        }
    }
}
