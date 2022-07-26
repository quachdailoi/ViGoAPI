﻿using Domain.Entities.Base;
using Domain.Shares.Classes;
using Domain.Shares.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Booking : BaseEntity
    {
        public Guid Code { get; set; } = Guid.NewGuid();
        public TimeOnly Time { get; set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get; set; }
        public Payments.PaymentMethods PaymentMethod { get; set; } = Payments.PaymentMethods.COD;
        public Bookings.Options Option { get; set; }
        //public Bookings.Types Type { get; set; }
        public List<DayOfWeek> DayOfWeeks { get; set; } = new();
        public bool IsShared { get; set; }
        public int StartRouteStationId { get; set; }
        public int EndRouteStationId { get; set; }
        public double Duration { get; set; }
        public double Distance { get; set; }

        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public int UserId { get; set; }
        public int? PromotionId { get; set; } = null;
        public VehicleTypes.SpecificType VehicleTypeId { get; set; }
        public Bookings.Status Status { get; set; } = Bookings.Status.Unpaid;

        public User User { get; set; }
        public VehicleType VehicleType { get; set; }
        public List<BookingDetail> BookingDetails { get; set; } = new();
        public List<WalletTransaction> WalletTransactions { get; set; } = new();

        //Promotion
        public Promotion? Promotion { get; set; } = null;

        public RouteStation StartRouteStation { get; set; }
        public RouteStation EndRouteStation { get; set; }

        ////virtual direct relation
        //[NotMapped]
        //public int StartStationId { get => StartRouteStation.StationId; set => StartRouteStationId = value; }
        //public Station StartStation { get; set; } = new();
        //[NotMapped]
        //public Station EndStation => EndRouteStation.Station;
        //[NotMapped]
        //public Route Route => StartRouteStation.Route;
    }
}
