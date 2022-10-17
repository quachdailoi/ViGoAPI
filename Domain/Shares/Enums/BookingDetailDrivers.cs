using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class BookingDetailDrivers
    {
        public enum Status
        {
            Cancelled = -1,
            Pending = 0,
            Started = 1,
            Completed = 2
        }

        public enum TripStatus
        {
            NotYet = 0,
            RouteStarted = 1,
            PickingUp = 2,
            Arried = 3,
            Completed = 4
        }
    }
}
