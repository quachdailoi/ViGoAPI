﻿using Domain.Entities.Base;
using Domain.Shares.Classes;
using Domain.Shares.Enums;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public int Option { get; set; }
        public BookingTypes Type { get; set; }
        public DaySchedule Days { get; set; } = new();
        public bool IsShared { get; set; }
        public Location From { get; set; } = new();
        public Location To { get; set; } = new();
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public int UserId { get; set; }
        public int PromotionId { get; set; }
        public StatusTypes.Booking Status { get; set; } = StatusTypes.Booking.Started;

        public User User { get; set; } = new();
        public List<BookingDetail> BookingDetails { get; set; } = new();

        //Promotion
        public Promotion Promotion { get; set; }
    }
}
