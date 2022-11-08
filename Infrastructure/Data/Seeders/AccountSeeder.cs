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
    public class AccountSeeder
    {
        public AccountSeeder(ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(new Account
            {
                Id = 1,
                Registration = "loiqdse140970@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = true,
                UserId = 1
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 2,
                Registration = "+84837226239",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.DRIVER,
                Verified = false,
                UserId = 1
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 3,
                Registration = "loiqdse140970@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = false,
                UserId = 5
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 4,
                Registration = "+84837226239",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.BOOKER,
                Verified = true,
                UserId = 5
            });

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
                Registration = "khoandse140977@fpt.edu.vn",
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

            builder.Entity<Account>().HasData(new Account
            {
                Id = 17,
                Registration = "+84376826328",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.ADMIN,
                Verified = true,
                UserId = 9
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 18,
                Registration = "loiqdse140970@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.ADMIN,
                Verified = true,
                UserId = 9
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 19,
                Registration = "khoandse140977@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.ADMIN,
                Verified = true,
                UserId = 11
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 20,
                Registration = "+84914669962",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.ADMIN,
                Verified = false,
                UserId = 11
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 21,
                Registration = "duyttse140971@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.ADMIN,
                Verified = true,
                UserId = 10
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 22,
                Registration = "+84376826328",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.ADMIN,
                Verified = false,
                UserId = 10
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 23,
                Registration = "datdtse140920@fpt.edu.vn",
                RegistrationType = RegistrationTypes.Gmail,
                RoleId = Domain.Shares.Enums.Roles.ADMIN,
                Verified = true,
                UserId = 12
            });

            builder.Entity<Account>().HasData(new Account
            {
                Id = 24,
                Registration = "+84377322919",
                RegistrationType = RegistrationTypes.Phone,
                RoleId = Domain.Shares.Enums.Roles.ADMIN,
                Verified = false,
                UserId = 12
            });

            int count = 100;
            for(int i = 100; i < 200; i ++)
            {
                builder.Entity<Account>().HasData(new Account
                {
                    Id = count,
                    Registration = $"+{i}",
                    RegistrationType = RegistrationTypes.Phone,
                    RoleId = Domain.Shares.Enums.Roles.BOOKER,
                    Verified = true,
                    UserId = i
                });

                builder.Entity<Account>().HasData(new Account
                {
                    Id = ++count,
                    Registration = $"@{i}",
                    RegistrationType = RegistrationTypes.Gmail,
                    RoleId = Domain.Shares.Enums.Roles.BOOKER,
                    Verified = false,
                    UserId = i
                });
                count++;
            }

            count = 400;
            for (int i = 400; i < 500; i++)
            {
                builder.Entity<Account>().HasData(new Account
                {
                    Id = count,
                    Registration = $"+{i}",
                    RegistrationType = RegistrationTypes.Phone,
                    RoleId = Domain.Shares.Enums.Roles.DRIVER,
                    Verified = false,
                    UserId = i
                });

                builder.Entity<Account>().HasData(new Account
                {
                    Id = ++count,
                    Registration = $"@{i}",
                    RegistrationType = RegistrationTypes.Gmail,
                    RoleId = Domain.Shares.Enums.Roles.DRIVER,
                    Verified = true,
                    UserId = i
                });
                count++;
            }
        }
    }
}
