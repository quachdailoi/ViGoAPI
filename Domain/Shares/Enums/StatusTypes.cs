using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class StatusTypes
    {
        public enum Room
        {
            InActive,
            Active,
        }

        public enum UserRoom
        {
            Active = 1
        }

        public enum Message
        {
            InActive,
            Active,
            Deleted
        }

        public enum Booking
        {
            Cancelled,
            Started,
            Completed
        }
        public enum BookingDetail
        {
            Cancelled,
            Pending,
            Ready,
            Started,
            Completed
        }
    }
}
