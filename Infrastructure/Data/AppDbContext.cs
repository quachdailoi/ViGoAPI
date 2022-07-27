using Domain.Entities;
using Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new RoleEntityConfiguration()
                .Configure(builder.Entity<Role>());

            new UserEntityConfiguration()
                .Configure(builder.Entity<User>());

            new AccountEntityConfiguration()
                .Configure(builder.Entity<Account>());

            new VerifiedCodeEntityConfiguration()
                .Configure(builder.Entity<VerifiedCode>());

            builder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = "DRIVER",
                Description = "Role for driver"
            });

            builder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "BOOKER",
                Description = "Role for booker"
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Quach Dai Loi",
                Code = Guid.NewGuid(),
                DateOfBirth = DateTime.UtcNow,
                Gender = 1,
                Status = 1
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Olivier",
                Code = Guid.NewGuid(),
                DateOfBirth = DateTime.UtcNow,
                Gender = 1,
                Status = 1
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 1,
                Registration = "loiqdse140970@fpt.edu.vn",
                RegistrationType = 0,
                RoleId = 2,
                Verified = true,
                UserId = 2
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 2,
                Registration = "+84837226239",
                RegistrationType = 1,
                RoleId = 2,
                Verified = true,
                UserId = 2
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 3,
                Registration = "+84837226239",
                RegistrationType = 1,
                RoleId = 1,
                Verified = true,
                UserId = 1
            });
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VerifiedCode> VerifiedCodes { get; set; }
    }
}
