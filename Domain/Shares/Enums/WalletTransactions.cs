using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public  class WalletTransactions
    {
        public enum Types
        {
            MomoIncome,
            ZaloPayIncome,
            VnPayIncome,
            BookingPaid,
            BookingRefund
        }
        public enum Status
        {
            Success,
            Fail
        }
    }
}
