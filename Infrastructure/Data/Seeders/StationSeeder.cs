using Domain.Entities;
using Domain.Shares.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class StationSeeder 
    {
        public StationSeeder(ModelBuilder builder)
        {
            builder.Entity<Station>().HasData(
                    DumpData.DumpStations()
                );
        }
    }
}
