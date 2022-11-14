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
                        Balance = 0
                    },
                    new Wallet
                    {
                        Id = 2,
                        UserId = 2
                    },
                    new Wallet
                    {
                        Id = 3,
                        UserId = 3
                    },
                    new Wallet
                    {
                        Id = 4,
                        UserId = 4
                    },
                    new Wallet
                    {
                        Id = 5,
                        UserId = 5
                    },
                    new Wallet
                    {
                        Id = 6,
                        UserId = 6
                    },
                    new Wallet
                    {
                        Id = 7,
                        UserId = 7
                    },
                    new Wallet
                    {
                        Id = 8,
                        UserId = 8
                    },
                    new Wallet
                    {
                        Id = 9,
                        Type = Domain.Shares.Enums.Wallets.Types.System
                    }
                });
        }
    }
}
