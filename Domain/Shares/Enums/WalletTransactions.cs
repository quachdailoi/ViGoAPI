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
            [Description("Pay booking by Wallet")]
            BookingPaid,
            [Description("Booking refund")]
            BookingRefund,
            [Description("Pay booking by Momo")]
            BookingPaidByMomo,
            [Description("Pay booking by ZaloPay")]
            BookingPaidByZaloPay,
            [Description("Pay booking by VnPay")]
            BookingPaidByVnPay,
            [Description("Refund booking by Momo")]
            BookingRefundMomo,
            [Description("Refund booking by ZaloPay")]
            BookingRefundZaloPay,
            [Description("Get income from trip")]
            TripIncome,
            [Description("Pay for driver")]
            PayForDriver
        }
        public enum Status
        {
            Pending,
            Success,
            Fail,
        }
    }
}
