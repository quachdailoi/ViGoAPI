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
    public class FileSeeder
    {
        public FileSeeder(ModelBuilder builder)
        {
            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 1,
                Path = "user/avatar/default-user-avatar.png",
                Type = FileTypes.AvatarImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 2,
                Path = "user/avatar/default-user-avatar.png",
                Type = FileTypes.AvatarImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 3,
                Path = "user/avatar/default-user-avatar.png",
                Type = FileTypes.AvatarImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 4,
                Path = "user/avatar/default-user-avatar.png",
                Type = FileTypes.AvatarImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 5,
                Path = "user/avatar/default-user-avatar.png",
                Type = FileTypes.AvatarImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 6,
                Path = "user/avatar/default-user-avatar.png",
                Type = FileTypes.AvatarImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 7,
                Path = "user/avatar/default-user-avatar.png",
                Type = FileTypes.AvatarImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 8,
                Path = "user/avatar/default-user-avatar.png",
                Type = FileTypes.AvatarImage
            });

            // banner and promotion files
            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 9,
                Path = "promotion/285640182_5344668362254863_4230282646432249568_n.png",
                Type = FileTypes.PromotionImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 10,
                Path = "promotion/292718124_1043378296364294_8747140355237126885_n.png",
                Type = FileTypes.PromotionImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 11,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png",
                Type = FileTypes.PromotionImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 12,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png",
                Type = FileTypes.PromotionImage
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 13,
                Path = "user/avatar/default-user-avatar.png",
                Type = FileTypes.AvatarImage
            });

            //license

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 14,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png",
                Type = FileTypes.IdentificationImageFront
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 15,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png",
                Type = FileTypes.IdentificationImageBack
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 16,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png",
                Type = FileTypes.DriverLicenceFront
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 17,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png",
                Type = FileTypes.DriverLicenceBack
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 18,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png",
                Type = FileTypes.VehicleRegistrationFront
            });

            builder.Entity<AppFile>().HasData(new AppFile
            {
                Id = 19,
                Path = "promotion/300978304_2290809087749954_8259423704505319939_n.png",
                Type = FileTypes.VehicleRegistrationBack
            });
        }
    }
}
