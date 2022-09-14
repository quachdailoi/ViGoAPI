﻿using Domain.Shares.Enums;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class BookingDetailViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public double Rating { get; set; }
        public string FeedBack { get; set; } = String.Empty;
        public DateOnly Date { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public StatusTypes.BookingDetail Status { get; set; }
        public MessageRoomViewModel MessageRoom { get; set; }
        public BookingViewModel Booking { get; set; }
    }
    public class BookerBookingDetailViewModel : BookingDetailViewModel
    {
        public DriverViewModel Driver { get; set; }
    }
    public class DriverBookingDetailViewModel : BookingDetailViewModel
    {

    }
}