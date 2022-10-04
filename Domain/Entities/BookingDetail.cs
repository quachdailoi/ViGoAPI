using Domain.Entities.Base;
using Domain.Shares.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BookingDetail : BaseEntity
    {
        public double Rating { get; set; }
        public string FeedBack { get; set; } = String.Empty;
        public DateOnly Date { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public StatusTypes.BookingDetail Status { get; set; } = StatusTypes.BookingDetail.Pending;
        public int BookingId { get; set; }
        public int? DriverId { get; set; } = null;
        public int? MessageRoomId { get; set; } = null;

        public Booking Booking { get; set; }
        public User? Driver { get; set; } = null;
        public Room? MessageRoom { get; set; } = null;
        public List<BookingDetailDriver> BookingDetailDrivers { get; set; } = new();
    }
}
