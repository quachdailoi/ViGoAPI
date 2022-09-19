using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class BannerSeeder
    {
        public BannerSeeder(ModelBuilder builder)
        {
            List<Banner> banners = new();

            banners.Add(new Banner
            {
                FileId = 9,
                Content = "Banner 1",
                Priority = 1,
                Active = true,
            });

            banners.Add(new Banner
            {
                FileId = 10,
                Content = "Banner 2",
                Priority = 2,
                Active = true,
            });

            banners.Add(new Banner
            {
                FileId = 11,
                Content = "Banner 3",
                Priority = 3,
                Active = true,
            });

            banners.Add(new Banner
            {
                FileId = 12,
                Content = "Banner 4",
                Priority = null,
                Active = true,
            });

            for (int i = 1; i <= banners.Count; i++)
            {
                banners[i-1].Id = i;
            }

            builder.Entity<Banner>().HasData(banners);
        }
    }
}
