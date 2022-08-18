using Domain.Entities;
using Domain.Shares.Enums;
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

            new FileEntityConfiguration()
                .Configure(builder.Entity<AppFile>());

            new UserEntityConfiguration()
                .Configure(builder.Entity<User>());

            new AccountEntityConfiguration()
                .Configure(builder.Entity<Account>());

            new VerifiedCodeEntityConfiguration()
                .Configure(builder.Entity<VerifiedCode>());

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

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 1,
                Code = Guid.NewGuid(),
                Path = "abcabc",
                Type = FileTypes.Image,
                Status = true
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Quach Dai Loi",
                Code = Guid.NewGuid(),
                DateOfBirth = DateTime.UtcNow,
                Gender = 1,
                Status = 1,
                FileId = 1
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

            builder.Entity<User>().HasData(new User
            {
                Id = 3,
                Name = "Dat Do",
                Code = Guid.NewGuid(),
                DateOfBirth = DateTime.UtcNow,
                Gender = 1,
                Status = 1,
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 1,
                Registration = "loiqdse140970@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = true,
                UserId = 2
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 2,
                Registration = "+84837226239",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = false,
                UserId = 2
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 3,
                Registration = "+848372262391",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = true,
                UserId = 1
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 4,
                Registration = "loiqdse140970@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = false,
                UserId = 1
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 5,
                Registration = "+84377322919",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = true,
                UserId = 3
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 6,
                Registration = "trongdat2000@gmail.com",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = true,
                UserId = 3
            });
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VerifiedCode> VerifiedCodes { get; set; }
    }
}
