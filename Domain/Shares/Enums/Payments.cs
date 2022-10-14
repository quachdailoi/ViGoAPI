using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Payments
    {
        public enum PaymentMethods
        {
            COD = 0,
            Momo = 1,
            VNPay = 2,
            BankCard = 3,
            Wallet = 4
        }
        public enum MomoStatusCodes
        {
            Successed = 0,
            AccessDenied = 11,
            InvalidFormat = 20,
            InvalidAmount = 22,
            DuplicateOrderId = 41,
            Cancelled = 1003,
            SystemMaintance = 10,
            Unknown = 99
        }
        public enum MomoRequestTypes
        {
            [Description("linkWallet")]
            LinkWallet,
            [Description("captureWallet")]
            CaptureWallet
        }
    }  
}
