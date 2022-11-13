using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookingDetailDriver : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly? StartTime { get; set; } = null;
        public TimeOnly? EndTime { get; set; } = null;
        public string CancelledReason { get; set; } = string.Empty;
        public bool CompleteWithoutBooker { get; set; } = false;
        public BookingDetailDrivers.TripStatus TripStatus { get; set; } = BookingDetailDrivers.TripStatus.NotYet;

        public int BookingDetailId { get; set; }
        public int RouteRoutineId { get; set; }
        
        public BookingDetail BookingDetail { get; set; }
        public RouteRoutine RouteRoutine { get; set; }
    }
}
