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
        public TimeOnly? StartTime { get; set; } = null;
        public TimeOnly? EndTime { get; set; } = null;
        public BookingDetailDrivers.Status Status { get; set; } = BookingDetailDrivers.Status.Pending;
        public int BookingDetailId { get; set; }
        public int DriverId { get; set; }
        
        public BookingDetail BookingDetail { get; set; }
        public User Driver { get; set; }
    }
}
