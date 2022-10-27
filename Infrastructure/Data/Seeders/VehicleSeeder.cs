using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class VehicleSeeder
    {
        public VehicleSeeder(ModelBuilder builder)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Id = 1, 
                    Name = "Wave Alpha",
                    LicensePlate= "51B.000.01",
                    VehicleTypeId = 1,
                    UserId = 2
                },
                new Vehicle
                {
                    Id = 2,
                    Name = "BMW I8",
                    LicensePlate = "51B.000.02",
                    VehicleTypeId = 2,
                    UserId = 1
                },
                new Vehicle
                {
                    Id = 3,
                    Name = "Mazda CX-8",
                    LicensePlate = "51B.000.03",
                    VehicleTypeId = 3,
                    UserId = 3
                },
                new Vehicle
                {
                    Id = 4,
                    Name = "Honda CR-V",
                    LicensePlate = "51B.000.04",
                    VehicleTypeId = 3,
                    UserId = 4
                }
            };

            for (int i = 400; i < 500; i++)
            {
                vehicles.Add(new Vehicle
                {
                    Id = i,
                    Name = $"Vehicle {i}",
                    LicensePlate = $"51B.000.{i}",
                    VehicleTypeId = 3,
                    UserId = i
                });
            }

            builder.Entity<Vehicle>().HasData(vehicles);

            
        }
    }
}
