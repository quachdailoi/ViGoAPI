using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Bookings
    {
        public enum Types{
            WeekTicket,
            MonthTicket,
            QuaterTicket
        }
        
        public enum Options
        {
            StartAtFollowingTime,
            StartAtNextDay
        }
        public enum Status
        {
            Unpaid,
            PendingMapping,
            Started,
            Completed,
            CancelledByBooker,
            CancelledBySystem,
            RefundCompleted
        }

        public static readonly double AllowedMappingTimeRange = 3; //minutes
    }
}
