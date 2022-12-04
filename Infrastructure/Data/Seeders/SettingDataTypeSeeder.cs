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
    public class SettingDataTypeSeeder
    {
        public SettingDataTypeSeeder(ModelBuilder builder)
        {
            builder.Entity<SettingDataType>().HasData(new SettingDataType
            {
                Id = SettingDataTypes.Default,
                Name = SettingDataTypes.Default.ToString(),
            });

            builder.Entity<SettingDataType>().HasData(new SettingDataType
            {
                Id = SettingDataTypes.Integer,
                Name = SettingDataTypes.Integer.ToString(),
            });

            builder.Entity<SettingDataType>().HasData(new SettingDataType
            {
                Id = SettingDataTypes.Double,
                Name = SettingDataTypes.Double.ToString(),
            });

            builder.Entity<SettingDataType>().HasData(new SettingDataType
            {
                Id = SettingDataTypes.Time,
                Name = SettingDataTypes.Time.ToString(),
            });
        }
    }
}
