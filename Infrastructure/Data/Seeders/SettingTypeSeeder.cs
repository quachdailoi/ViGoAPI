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
    public class SettingTypeSeeder
    {
        public SettingTypeSeeder(ModelBuilder builder)
        {
            builder.Entity<SettingType>().HasData(new SettingType
            {
                Id = SettingTypes.Default,
                Name = SettingTypes.Default.ToString(),
            });

            builder.Entity<SettingType>().HasData(new SettingType
            {
                Id = SettingTypes.Trip,
                Name = SettingTypes.Trip.ToString(),
            });

            builder.Entity<SettingType>().HasData(new SettingType
            {
                Id = SettingTypes.Penalty,
                Name = SettingTypes.Penalty.ToString(),
            });

            builder.Entity<SettingType>().HasData(new SettingType
            {
                Id = SettingTypes.RouteRoutine,
                Name = SettingTypes.RouteRoutine.ToString(),
            });

            builder.Entity<SettingType>().HasData(new SettingType
            {
                Id = SettingTypes.Pricing,
                Name = SettingTypes.Pricing.ToString(),
            });
        }
    }
}
