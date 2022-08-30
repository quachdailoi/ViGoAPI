using Domain.Entities.Base;
using Domain.Shares.Enums;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public int Option { get; set; }
        public BookingType Type { get; set; }
        public DaySchedule Days { get; set; }
        public bool IsShared { get; set; }
        public Location From { get; set; }
        public Location To { get; set; }
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public int UserId { get; set; }
        public int PromotionId { get; set; }
        public StatusTypes.Booking Status { get; set; } = StatusTypes.Booking.Started;

        public User User { get; set; }
        public List<BookingDetail> BookingDetails { get; set; }

        //Promotion

    }
    public class Location
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string LocationName { get; set; }
    }
    public class DaySchedule
    {
        public List<int> DaysOfWeek { get; set; }
        public List<int> DaysOfMonth { get; set; }
        Dictionary<int,List<int>> IgnoreDaysByMonth { get; set; }
    }
}
