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
    public class AffiliatePartyTypeSeeder
    {
        public AffiliatePartyTypeSeeder(ModelBuilder builder)
        {
            builder.Entity<AffiliatePartyType>()
                .HasData(new List<AffiliatePartyType>
                {
                    new AffiliatePartyType
                    {
                        Id = Payments.PaymentMethods.Momo,
                        Name = "Momo"
                    },
                    new AffiliatePartyType
                    {
                        Id = Payments.PaymentMethods.VNPay,
                        Name = "VNPay",
                    },
                    new AffiliatePartyType
                    {
                        Id = Payments.PaymentMethods.BankCard,
                        Name = "BankCard"
                    }
                });
        }
    }
}
