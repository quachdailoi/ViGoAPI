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
    public class RoleSeeder
    {
        public RoleSeeder(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new Role
            {
                Id = Roles.DRIVER,
                Name = Roles.DRIVER.GetString(),
                Description = "Role for driver"
            });

            builder.Entity<Role>().HasData(new Role
            {
                Id = Roles.BOOKER,
                Name = Roles.BOOKER.GetString(),
                Description = "Role for booker"
            });

            // admin
            builder.Entity<Role>().HasData(new Role
            {
                Id = Roles.ADMIN,
                Name = Roles.ADMIN.GetString(),
                Description = "Role for admin"
            });
        }
    }
}
