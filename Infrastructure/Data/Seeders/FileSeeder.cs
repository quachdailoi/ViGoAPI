using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class FileSeeder
    {
        public FileSeeder(ModelBuilder builder)
        {
            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 1,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 2,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 3,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 4,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 5,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 6,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 7,
                Path = "user/avatar/default-user-avatar.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 8,
                Path = "user/avatar/default-user-avatar.png"
            });

            // banner files
            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 9,
                Path = "promotion/285640182_5344668362254863_4230282646432249568_n.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 10,
                Path = "promotion/292718124_1043378296364294_8747140355237126885_n.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 11,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 12,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png"
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 13,
                Path = "user/avatar/default-user-avatar.png"
            });
        }
    }
}
