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
    public class UserLicenseTypeSeeder
    {
        public UserLicenseTypeSeeder(ModelBuilder builder)
        {
            builder.Entity<LicenseType>().HasData(new LicenseType
            {
                Id = LicenseTypes.Identification,
                Name = "Identification",
                Code = Guid.NewGuid()
            });

            builder.Entity<LicenseType>().HasData(new LicenseType
            {
                Id = LicenseTypes.DriverLicense,
                Name = "Driver License",
                Code = Guid.NewGuid()
            });

            builder.Entity<LicenseType>().HasData(new LicenseType
            {
                Id = LicenseTypes.VehicleRegistration,
                Name = "Vehicle Registration Certificate",
                Code = Guid.NewGuid()
            });
        }
    }
}
