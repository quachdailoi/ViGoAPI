using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class AffiliateParties
    { 
        public enum Status
        {
            Active,
            Inactive
        }

        public enum PartyTypes
        {
            Momo = 1,
            VNPay = 3,
            ZaloPay = 2
        }
    }
}
