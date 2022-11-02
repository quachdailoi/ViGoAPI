using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class PricingSeeder
    {
        public PricingSeeder(ModelBuilder builder)
        {
            builder.Entity<Pricing>().HasData(
                    new List<Pricing>
                    {
                        new Pricing
                        {
                            Id = 1,
                            UpperBound = 7,
                            Discount = 0
                        },
                        new Pricing
                        {
                            Id = 2,
                            LowerBound = 8,
                            UpperBound = 30,
                            Discount = 0.03
                        },
                        new Pricing
                        {
                            Id = 3,
                            LowerBound = 31,
                            UpperBound = 90,
                            Discount = 0.05
                        },
                        new Pricing
                        {
                            Id = 4,
                            LowerBound = 91,
                            Discount = 0.07
                        }
                    }
                );
        }
    }
}
