﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Events
    {
        public enum SubTypes
        {
            Default = 0
        }
        public enum Types
        {
            MappingBooking = 1,
            PaidBooking = 2,
            RefundBooking = 3,
            RefundBookingDetail = 4,
            Promotion = 5,
        }

        public enum Status
        {
            Inactive,
            Active
        }
    }
}