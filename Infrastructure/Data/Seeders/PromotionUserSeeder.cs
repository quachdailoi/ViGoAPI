using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class PromotionUserSeeder
    {
        public PromotionUserSeeder(ModelBuilder builder)
        {
            builder.Entity<PromotionUser>().HasData(new PromotionUser
            {
                Id = 1,
                PromotionId = 1,
                UserId = 5,
                Used = 0,
                ExpiredTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-10-01T00:00:01Z")),
            });

            builder.Entity<PromotionUser>().HasData(new PromotionUser
            {
                Id = 2,
                PromotionId = 1,
                UserId = 6,
                Used = 1,
                ExpiredTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-10-01T00:00:01Z")),
            });

            builder.Entity<PromotionUser>().HasData(new PromotionUser
            {
                Id = 3,
                PromotionId = 1,
                UserId = 7,
                Used = 0,
                ExpiredTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("2022-09-01T00:00:01Z")),
            });

            builder.Entity<PromotionUser>().HasData(new PromotionUser
            {
                Id = 4,
                PromotionId = 2,
                UserId = 6,
                Used = 2
            });
        }
    }
}
