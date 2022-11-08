using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class TaskItems
    {
        public enum RefundItemTypes
        {
            Booking = 1,
            BookingDetail = 2
        }

        public enum MappingItemTypes
        {
            Booking = 1,
            RouteRoutine = 2,
            BookingDetail = 3
        }
    }
}
