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
            Ready = 0,
            Started = 1,
            Completed = 2
        }

        public enum TripStatus
        {
            NotYet = 0,
            PickingUp = 1,
            Arried = 2,
            Completed = 3
        }

        public enum StepScheduleType
        {
            PickUp,
            DropOff
        }
    }
}
