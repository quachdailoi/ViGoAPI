﻿using Domain.Shares.Enums;

namespace API.Models.Requests
{
    public class UpdateBookingDetailDriverTripStatusRequest
    {
        public string BookingDetailDriverCode { get; set; }
        public BookingDetailDrivers.TripStatus TripStatus { get; set; } 
    }

    public class StartBookingDetailDriversRequest
    {
        public string[] BookingDetailDriverCodes { get; set; }
    }
}
