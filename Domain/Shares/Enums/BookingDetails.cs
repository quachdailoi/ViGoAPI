using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class BookingDetails
    {
        public enum Status
        {
            Cancelled,
            Pending,
            Ready,
            Started,
            Completed,
            PendingRefund,
            CompletedRefund
        }

        public enum RefundTypes
        {
            NotFoundDriver = 1,
            SharingTrip = 2
        }
    }
}
