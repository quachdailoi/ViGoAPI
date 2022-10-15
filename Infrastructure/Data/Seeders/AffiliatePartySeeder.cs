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
    public class AffiliatePartySeeder
    {
        public AffiliatePartySeeder(ModelBuilder builder)
        {
            builder.Entity<AffiliateParty>()
                .HasData(new List<AffiliateParty>
                {
                    new AffiliateParty
                    {
                        Id = AffiliateParties.PartyTypes.Momo,
                        Name = "Momo"
                    },
                    new AffiliateParty
                    {
                        Id = AffiliateParties.PartyTypes.VNPay,
                        Name = "VNPay",
                    },
                    new AffiliateParty
                    {
                        Id = AffiliateParties.PartyTypes.ZaloPay,
                        Name = "ZaloPay"
                    }
                });
        }
    }
}
