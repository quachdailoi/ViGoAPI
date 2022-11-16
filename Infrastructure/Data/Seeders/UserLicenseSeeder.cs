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
    public class UserLicenseSeeder
    {
        public UserLicenseSeeder(ModelBuilder builder)
        {
            builder.Entity<UserLicense>().HasData(new UserLicense
            {
                Id = 1,
                Code = Guid.NewGuid().ToString(),
                UserId = 1,
                FrontSideFileId = 14,
                BackSideFileId = 15,
                LicenseTypeId = LicenseTypes.Identification
            });

            builder.Entity<UserLicense>().HasData(new UserLicense
            {
                Id = 2,
                Code = Guid.NewGuid().ToString(),
                UserId = 1,
                FrontSideFileId = 16,
                BackSideFileId = 17,
                LicenseTypeId = LicenseTypes.DriverLicense
            });

            builder.Entity<UserLicense>().HasData(new UserLicense
            {
                Id = 3,
                Code = Guid.NewGuid().ToString(),
                UserId = 1,
                FrontSideFileId = 18,
                BackSideFileId = 19,
                LicenseTypeId = LicenseTypes.VehicleRegistration
            });
        }
    }
}
