﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class BookingDetailDrivers
    {
        public enum TripStatus
        {
            Cancelled = -1,
            NotYet = 0,
            Start = 1,
            PickedUp = 2,
            Completed = 3
        }

        public enum StepScheduleType
        {
            PickUp,
            DropOff
        }
    }
}
