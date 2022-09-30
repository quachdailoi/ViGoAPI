using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public enum PaymentMethods
    {
        COD = 0,
        Momo = 1,
        VNPay = 2,
        BankCard = 3
    }
    public class MomoStatusCodes
    {
        public readonly static int Successed = 0;
        public readonly static int AccessDenied = 11;
        public readonly static int InvalidFormat = 20;
        public readonly static int InvalidAmount = 22;
        public readonly static int DuplicateOrderId = 41;
        public readonly static int Cancelled = 1003;
        public readonly static int SystemMaintance = 10;
        public readonly static int Unknown = 99;
    }
}
