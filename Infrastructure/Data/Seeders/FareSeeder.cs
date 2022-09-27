﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class FareSeeder
    {
        public FareSeeder(ModelBuilder model)
        {
            var fares = new List<Fare>
            {
                new()
                {
                    Id = 1,
                    VehicleTypeId = 1,
                    BaseDistance = 2000,
                    BasePrice = 12000,
                    PricePerKm = 4000
                },
                new()
                {
                    Id = 2,
                    VehicleTypeId = 2,
                    BaseDistance = 2000,
                    BasePrice = 20000,
                    PricePerKm = 10000
                },
                new()
                {
                    Id = 3,
                    VehicleTypeId = 3,
                    BaseDistance = 2000,
                    BasePrice = 30000,
                    PricePerKm = 12000
                }
            };

            model.Entity<Fare>().HasData(fares);
        }
    }
}
