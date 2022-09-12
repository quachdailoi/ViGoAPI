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
    public class PromotionSeeder
    {
        public PromotionSeeder(ModelBuilder builder)
        {
            builder.Entity<Promotion>().HasData(new Promotion
            {
                Id = 1,
                Name = "New User Promotion",
                Code = "HELLO2022",
                Details = "Promotion for new user: Discount 20% with max decrease 200k for the booking with minimum total price 500k.",
                DiscountPercentage = 0.2,
                MaxDecrease = 200000,
                Status = Promotions.Status.Available,
                Type = Promotions.Types.NewUser,
                FileId = 9
            });

            builder.Entity<Promotion>().HasData(new Promotion
            {
                Id = 2,
                Name = "Beautiful Month",
                Code = "BDAY2022",
                Details = "Promotion for September: Discount 10% with max decrease 150k for the booking with minimum total price 200k.",
                DiscountPercentage = 0.1,
                MaxDecrease = 150000,
                Status = Promotions.Status.Available,
                Type = Promotions.Types.Holiday,
                FileId = 10
            });

            builder.Entity<Promotion>().HasData(new Promotion
            {
                Id = 3,
                Name = "Holiday Promotion",
                Code = "HOLIDAY",
                Details = "Promotion for 2/9 Holiday: Discount 30% with max decrease 300k for the booking with minimum total price 1000k.",
                DiscountPercentage = 0.3,
                MaxDecrease = 300000,
                Status = Promotions.Status.Available,
                Type = Promotions.Types.Holiday,
            });

            builder.Entity<Promotion>().HasData(new Promotion
            {
                Id = 4,
                Name = "ABC Promotion",
                Code = "ABC",
                Details = "Promotion for users booking alot: Discount 10% with max decrease 300k for the booking with minimum total price 500k.",
                DiscountPercentage = 0.1,
                MaxDecrease = 300000,
                Status = Promotions.Status.Available,
                Type = Promotions.Types.MoreAndMore,
                FileId = 11
            });
        }
    }
}
