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

            new UserRoomEntityConfiguration()
                .Configure(builder.Entity<UserRoom>());

            new RoomEntityConfiguration()
                .Configure(builder.Entity<Room>());

            new MessageEntityConfiguration()
                .Configure(builder.Entity<Message>());

            new BookingEntityConfiguration()
                .Configure(builder.Entity<Booking>());

            new BookingDetailEntityConfiguration()
                .Configure(builder.Entity<BookingDetail>());

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
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Quach Dai Loi",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Genders.Male,
                Status = StatusTypes.User.Active,
                FileId = 1,
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 2,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Do Trong Dat",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Genders.Male,
                Status = StatusTypes.User.Active,
                FileId = 2,
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 3,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 3,
                Name = "Nguyen Dang Khoa",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Genders.Male,
                Status = StatusTypes.User.Active,
                FileId = 3,
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 4,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 4,
                Name = "Than Thanh Duy",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Genders.Male,
                Status = StatusTypes.User.Active,
                FileId = 4,
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 5,
                Path = "user/avatar/default-user-avatar.png"
            });

            //builder.Entity<User>().HasData(new User
            //{
            //    Id = 5,
            //    Name = "Loi Quach",
            //    Code = Guid.NewGuid(),
            //    DateOfBirth = null,
            //    Gender = Genders.Male,
            //    Status = StatusTypes.User.Active,
            //    FileId = 5,
            //});

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 6,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 6,
                Name = "Dat Do",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Genders.Male,
                Status = StatusTypes.User.Active,
                FileId = 6,
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 7,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 7,
                Name = "Khoa Nguyen",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Genders.Male,
                Status = StatusTypes.User.Active,
                FileId = 7,
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 8,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 8,
                Name = "Thanh Duy",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Genders.Male,
                Status = StatusTypes.User.Active,
                FileId = 8,
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

            //builder.Entity<Account>().HasData(new Account
            //{
            //    Id = 3,
            //    Registration = "loiqdse140970@fpt.edu.vn",
            //    RegistrationType = RegistrationTypes.Gmail,
            //    RoleId = Domain.Shares.Enums.Roles.BOOKER,
            //    Verified = false,
            //    UserId = 5
            //});

            //builder.Entity<Account>().HasData(new Account
            //{
            //    Id = 4,
            //    Registration = "+84837226239",
            //    RegistrationType = RegistrationTypes.Phone,
            //    RoleId = Domain.Shares.Enums.Roles.BOOKER,
            //    Verified = true,
            //    UserId = 5
            //});

            builder.Entity<Account>().HasData(new Account
            {
                Id = 5,
                Registration = "datdtse140920@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = true,
                UserId = 2
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 6,
                Registration = "+84377322919",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = false,
                UserId = 2
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 7,
                Registration = "datdtse140920@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = false,
                UserId = 6
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 8,
                Registration = "+84377322919",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = true,
                UserId = 6
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 9,
                Registration = "khoandse1409770@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = true,
                UserId = 3
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 10,
                Registration = "+84914669962",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = false,
                UserId = 3
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 11,
                Registration = "khoandse140977@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = false,
                UserId = 7
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 12,
                Registration = "+84914669962",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = true,
                UserId = 7
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 13,
                Registration = "duyttse140971@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = true,
                UserId = 4
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 14,
                Registration = "+84376826328",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = false,
                UserId = 4
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 15,
                Registration = "duyttse140971@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = false,
                UserId = 8
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 16,
                Registration = "+84376826328",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = true,
                UserId = 8
            });
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VerifiedCode> VerifiedCodes { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
    }
}
