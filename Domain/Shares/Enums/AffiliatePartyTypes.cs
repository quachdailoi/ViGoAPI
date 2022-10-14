using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class AffiliatePartyTypes
    { 
        public enum Types
        {
            Momo = 1,
            VNPay = 2,
            ZaloPay = 3
        }
        public enum Status
        {
            Active,
            Inactive
        }
    }
}
