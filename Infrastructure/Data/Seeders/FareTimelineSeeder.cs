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
                    ExtraFeePerKm = 0.12
                },
                new()
                {
                    Id = 2,
                    FareId = 1,
                    StartTime = TimeOnly.Parse("08:00:00"),
                    EndTime = TimeOnly.Parse("10:00:00"),
                    ExtraFeePerKm = 0.1
                },
                new()
                {
                    Id = 3,
                    FareId = 1,
                    StartTime = TimeOnly.Parse("15:00:00"),
                    EndTime = TimeOnly.Parse("17:00:00"),
                    ExtraFeePerKm = 0.15
                },
                new()
                {
                    Id = 4,
                    FareId = 1,
                    StartTime = TimeOnly.Parse("17:00:00"),
                    EndTime = TimeOnly.Parse("19:00:00"),
                    ExtraFeePerKm = 0.1
                },
                new()
                {
                    Id = 5,
                    FareId = 2,
                    StartTime = TimeOnly.Parse("06:00:00"),
                    EndTime = TimeOnly.Parse("08:00:00"),
                    ExtraFeePerKm = 0.12
                },
                new()
                {
                    Id = 6,
                    FareId = 2,
                    StartTime = TimeOnly.Parse("08:00:00"),
                    EndTime = TimeOnly.Parse("10:00:00"),
                    ExtraFeePerKm = 0.1
                },
                new()
                {
                    Id = 7,
                    FareId = 2,
                    StartTime = TimeOnly.Parse("15:00:00"),
                    EndTime = TimeOnly.Parse("17:00:00"),
                    ExtraFeePerKm = 0.15
                },
                new()
                {
                    Id = 8,
                    FareId = 2,
                    StartTime = TimeOnly.Parse("17:00:00"),
                    EndTime = TimeOnly.Parse("19:00:00"),
                    ExtraFeePerKm = 0.1
                },
                new()
                {
                    Id = 9,
                    FareId = 3,
                    StartTime = TimeOnly.Parse("06:00:00"),
                    EndTime = TimeOnly.Parse("08:00:00"),
                    ExtraFeePerKm = 0.12
                },
                new()
                {
                    Id = 10,
                    FareId = 3,
                    StartTime = TimeOnly.Parse("08:00:00"),
                    EndTime = TimeOnly.Parse("10:00:00"),
                    ExtraFeePerKm = 0.1
                },
                new()
                {
                    Id = 11,
                    FareId = 3,
                    StartTime = TimeOnly.Parse("15:00:00"),
                    EndTime = TimeOnly.Parse("17:00:00"),
                    ExtraFeePerKm = 0.15
                },
                new()
                {
                    Id = 12,
                    FareId = 3,
                    StartTime = TimeOnly.Parse("17:00:00"),
                    EndTime = TimeOnly.Parse("19:00:00"),
                    ExtraFeePerKm = 0.1
                },
            };

            model.Entity<FareTimeline>().HasData(fareTimelines);
        }
    }
}
