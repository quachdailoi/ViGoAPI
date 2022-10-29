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
    public class UserSeeder
    {
        public UserSeeder(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Quach Dai Loi",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = 1
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 2,
                Name = "Do Trong Dat",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = 2
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 3,
                Name = "Nguyen Dang Khoa",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = 3
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 4,
                Name = "Than Thanh Duy",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = 4
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 5,
                Name = "Loi Quach",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = 5
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 6,
                Name = "Dat Do",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = 6
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 7,
                Name = "Khoa Nguyen",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = 7
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 8,
                Name = "Thanh Duy",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = 8
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 9,
                Name = "Admin Quach Dai Loi",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = 13,
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 10,
                Name = "Admin Than Thanh Duy",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = null,
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 11,
                Name = "Admin Nguyen Dang Khoa",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = null,
            });

            builder.Entity<User>().HasData(new User
            {
                Id = 12,
                Name = "Admin Do Trong Dat",
                Code = Guid.NewGuid(),
                DateOfBirth = null,
                Gender = Users.Genders.Male,
                Status = Users.Status.Active,
                FileId = null,
            });

            for (int i = 100; i < 200; i++)
            {
                builder.Entity<User>().HasData(new User
                {
                    Id = i,
                    Name = $"Booker {i}",
                    Code = Guid.NewGuid(),
                    DateOfBirth = null,
                    Gender = Users.Genders.Male,
                    Status = Users.Status.Active,
                    FileId = null,
                });
            }


            for (int i = 400; i < 500; i++)
            {
                builder.Entity<User>().HasData(new User
                {
                    Id = i,
                    Name = $"Driver {i}",
                    Code = Guid.NewGuid(),
                    DateOfBirth = null,
                    Gender = Users.Genders.Male,
                    Status = Users.Status.Active,
                    FileId = null,
                });
            }
        }
    }
}
