using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class FareTimelineSeeder
    {
        public FareTimelineSeeder(ModelBuilder model)
        {
            var fareTimelines = new List<FareTimeline>
            {
                new()
                {
                    Id = 1,
                    FareId = 1,
                    StartTime = TimeOnly.Parse("06:00:00"),
                    EndTime = TimeOnly.Parse("08:00:00"),
                    ExtraFeePerKm = 2000,
                    CeilingExtraPrice = 7000
                },
                new()
                {
                    Id = 2,
                    FareId = 1,
                    StartTime = TimeOnly.Parse("08:00:00"),
                    EndTime = TimeOnly.Parse("10:00:00"),
                    ExtraFeePerKm = 1000,
                    CeilingExtraPrice = 5000
                },
                new()
                {
                    Id = 3,
                    FareId = 1,
                    StartTime = TimeOnly.Parse("15:00:00"),
                    EndTime = TimeOnly.Parse("17:00:00"),
                    ExtraFeePerKm = 2000,
                    CeilingExtraPrice = 7000
                },
                new()
                {
                    Id = 4,
                    FareId = 1,
                    StartTime = TimeOnly.Parse("17:00:00"),
                    EndTime = TimeOnly.Parse("19:00:00"),
                    ExtraFeePerKm = 1500,
                    CeilingExtraPrice = 5000
                },
                new()
                {
                    Id = 5,
                    FareId = 2,
                    StartTime = TimeOnly.Parse("06:00:00"),
                    EndTime = TimeOnly.Parse("08:00:00"),
                    ExtraFeePerKm = 2000,
                    CeilingExtraPrice = 7000
                },
                new()
                {
                    Id = 6,
                    FareId = 2,
                    StartTime = TimeOnly.Parse("08:00:00"),
                    EndTime = TimeOnly.Parse("10:00:00"),
                    ExtraFeePerKm = 1000,
                    CeilingExtraPrice = 5000
                },
                new()
                {
                    Id = 7,
                    FareId = 2,
                    StartTime = TimeOnly.Parse("15:00:00"),
                    EndTime = TimeOnly.Parse("17:00:00"),
                    ExtraFeePerKm = 1500,
                    CeilingExtraPrice = 5000
                },
                new()
                {
                    Id = 8,
                    FareId = 2,
                    StartTime = TimeOnly.Parse("17:00:00"),
                    EndTime = TimeOnly.Parse("19:00:00"),
                    ExtraFeePerKm = 2000,
                    CeilingExtraPrice = 7000
                },
                new()
                {
                    Id = 9,
                    FareId = 3,
                    StartTime = TimeOnly.Parse("06:00:00"),
                    EndTime = TimeOnly.Parse("08:00:00"),
                    ExtraFeePerKm = 2000,
                    CeilingExtraPrice = 7000
                },
                new()
                {
                    Id = 10,
                    FareId = 3,
                    StartTime = TimeOnly.Parse("08:00:00"),
                    EndTime = TimeOnly.Parse("10:00:00"),
                    ExtraFeePerKm = 1000,
                    CeilingExtraPrice = 5000
                },
                new()
                {
                    Id = 11,
                    FareId = 3,
                    StartTime = TimeOnly.Parse("15:00:00"),
                    EndTime = TimeOnly.Parse("17:00:00"),
                    ExtraFeePerKm = 1500,
                    CeilingExtraPrice = 6000
                },
                new()
                {
                    Id = 12,
                    FareId = 3,
                    StartTime = TimeOnly.Parse("17:00:00"),
                    EndTime = TimeOnly.Parse("19:00:00"),
                    ExtraFeePerKm = 2500,
                    CeilingExtraPrice = 10000
                },
                new()
                {
                    Id = 13,
                    FareId = 3,
                    StartTime = TimeOnly.Parse("14:00:00"),
                    EndTime = TimeOnly.Parse("15:00:00"),
                    ExtraFeePerKm = 1000,
                    CeilingExtraPrice = 5000
                },
            };

            model.Entity<FareTimeline>().HasData(fareTimelines);
        }
    }
}
