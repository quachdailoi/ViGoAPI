﻿using Domain.Entities;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class VehicleTypeSeeder
    {
        public VehicleTypeSeeder(ModelBuilder builder)
        {
            builder.Entity<VehicleType>().HasData(new VehicleType
            {
                Id = VehicleTypes.SpecificType.ViRide,
                Name = "ViRide",
                Code = Guid.NewGuid(),
                Slot = 2,
                Type = VehicleTypes.Type.ViRide
            });

            builder.Entity<VehicleType>().HasData(new VehicleType
            {
                Id = VehicleTypes.SpecificType.ViCar4,
                Name = "ViCar-4",
                Code = Guid.NewGuid(),
                Slot = 4,
                Type = VehicleTypes.Type.ViCar
            });

            builder.Entity<VehicleType>().HasData(new VehicleType
            {
                Id = VehicleTypes.SpecificType.ViCar7,
                Name = "ViCar-7",
                Code = Guid.NewGuid(),
                Slot = 7,
                Type = VehicleTypes.Type.ViCar
            });
        }
    }
}
