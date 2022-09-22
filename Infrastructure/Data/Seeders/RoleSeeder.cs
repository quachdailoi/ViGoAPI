using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class RoleSeeder
    {
        public RoleSeeder(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role
            {
                Id = Domain.Shares.Enums.Roles.DRIVER,
                Name = "DRIVER",
                Description = "Role for driver"
            });

            builder.Entity<Role>().HasData(new Role
            {
                Id = Domain.Shares.Enums.Roles.BOOKER,
                Name = "BOOKER",
                Description = "Role for booker"
            });

            // admin
            builder.Entity<Role>().HasData(new Role
            {
                Id = Domain.Shares.Enums.Roles.ADMIN,
                Name = "ADMIN",
                Description = "Role for admin"
            });
        }
    }
}
