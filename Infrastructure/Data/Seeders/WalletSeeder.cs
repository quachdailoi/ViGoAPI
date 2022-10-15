using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class WalletSeeder
    {
        public WalletSeeder(ModelBuilder builder)
        {
            builder.Entity<Wallet>()
                .HasData(new List<Wallet>
                {
                    new Wallet
                    {
                        Id = 1,
                        UserId = 1,
                        Balance = 500000
                    },
                    new Wallet
                    {
                        Id = 2,
                        UserId = 2,
                        Balance = 500000
                    },
                    new Wallet
                    {
                        Id = 3,
                        UserId = 3,
                        Balance = 500000
                    },
                    new Wallet
                    {
                        Id = 4,
                        UserId = 4,
                        Balance = 500000
                    },
                    new Wallet
                    {
                        Id = 5,
                        UserId = 5,
                        Balance = 500000
                    },
                    new Wallet
                    {
                        Id = 6,
                        UserId = 6,
                        Balance = 500000
                    },
                    new Wallet
                    {
                        Id = 7,
                        UserId = 7,
                        Balance = 500000
                    },
                    new Wallet
                    {
                        Id = 8,
                        UserId = 8,
                        Balance = 500000
                    },
                });
        }
    }
}
