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
    public class SettingDataUnitSeeder
    {
        public SettingDataUnitSeeder(ModelBuilder builder)
        {
            builder.Entity<SettingDataUnit>().HasData(new SettingDataUnit
            {
                Id = SettingDataUnits.Default,
                Name = SettingDataUnits.Default.ToString(),
            });

            builder.Entity<SettingDataUnit>().HasData(new SettingDataUnit
            {
                Id = SettingDataUnits.Percent,
                Name = SettingDataUnits.Percent.ToString(),
            });

            builder.Entity<SettingDataUnit>().HasData(new SettingDataUnit
            {
                Id = SettingDataUnits.Minutes,
                Name = SettingDataUnits.Minutes.ToString(),
            });

            builder.Entity<SettingDataUnit>().HasData(new SettingDataUnit
            {
                Id = SettingDataUnits.Hours,
                Name = SettingDataUnits.Hours.ToString(),
            });

            builder.Entity<SettingDataUnit>().HasData(new SettingDataUnit
            {
                Id = SettingDataUnits.Days,
                Name = SettingDataUnits.Days.ToString(),
            });

            builder.Entity<SettingDataUnit>().HasData(new SettingDataUnit
            {
                Id = SettingDataUnits.Meters,
                Name = SettingDataUnits.Meters.ToString(),
            });

            builder.Entity<SettingDataUnit>().HasData(new SettingDataUnit
            {
                Id = SettingDataUnits.Turn,
                Name = SettingDataUnits.Turn.ToString(),
            });

            builder.Entity<SettingDataUnit>().HasData(new SettingDataUnit
            {
                Id = SettingDataUnits.Time,
                Name = SettingDataUnits.Time.ToString(),
            });

            builder.Entity<SettingDataUnit>().HasData(new SettingDataUnit
            {
                Id = SettingDataUnits.MB,
                Name = SettingDataUnits.MB.ToString(),
            });
        }
    }
}
