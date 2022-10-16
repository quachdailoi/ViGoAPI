using System.ComponentModel;

namespace Domain.Shares.Enums
{
    public  class WalletTransactions
    {
        public enum Types
        {
            [Description("Top up from Momo")]
            MomoIncome,
            [Description("Top up from ZaloPay")]
            ZaloPayIncome,
            [Description("Top up from VnPay")]
            VnPayIncome,
            [Description("Pay booking")]
            BookingPaid,
            [Description("Pay refund")]
            BookingRefund
        }
        public enum Status
        {
            Pending,
            Success,
            Fail,
        }
    }
}
