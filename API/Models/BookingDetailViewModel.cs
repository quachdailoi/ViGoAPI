﻿using Domain.Entities;
using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class BookingDetailViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid Code { get; set; }
        public double Rating { get; set; }
        public string FeedBack { get; set; } = String.Empty;
        public DateOnly Date { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public BookingDetails.Status Status { get; set; }
        public string StatusName { get; set; }
        public Guid? ChattingRoomCode { get; set; }
        public TimeOnly Time { get; set; }
        public StationInRouteViewModel StartStation { get; set; }
        public StationInRouteViewModel EndStation { get; set; }
    }
    public class BookerBookingDetailViewModel : BookingDetailViewModel
    {
        public Guid BookingCode { get; set; }
        public string BookingType { get; set; }
        public DriverViewModel? Driver { get; set; } = null;
    }
    public class DriverBookingDetailViewModel : BookingDetailViewModel
    {
        public ContactUserViewModel User { get; set; }
    }

    public class ScheduleBookingDetailViewModel
    {
        public Guid BookingDetailDriverCode { get; set; }
        public TimeOnly Time { get; set; }
        public ScheduleStationViewModel StartStation { get; set; }
        public ScheduleStationViewModel EndStation { get; set; }
        public double Distance { get; set; }
        public BookingDetailDrivers.TripStatus TripStatus { get; set; }

        public List<ScheduleUserViewModel> Users { get; set; } = new();
    }
}
