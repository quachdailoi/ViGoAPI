using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Seeders
{
    public class EventSeeder
    {
        public EventSeeder(ModelBuilder builder)
        {
            var events = new List<Event>()
            {
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.MappingBooking,
                    Tittle = "FINDING DRIVER IS DONE",
                    Content = "The process of finding drivers for your booking is done. Don't worry if there is not any trips without driver, we continue to find driver for you. A trip without driver will be refunded on 20:00 of the day before the trip occurs.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.PaidBooking,
                    Tittle = "BOOKING WAS PAID SUCCESSFULLY",
                    Content = "Thanks for using our service, your booking is in the process of finding drivers.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.Promotion,
                    Tittle = "YOU HAVE A VOUCHER",
                    Content = "Hot voucher is waiting for you. Use now lest miss it.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.RefundBooking,
                    Tittle = "NOT FOUND ANY DRIVERS FOR YOUR NEXT TRIP",
                    Content = "There's not any suitable drivers for your next trip, sorry for this omission. We will refund for it.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.RefundBookingDetail,
                    Tittle = "YOUR DRIVER HAS PROBLEM",
                    Content = "Your driver has problem and he/she cannot come to pick you up, sorry for this omission. We will refund for it.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.StartTrip,
                    Tittle = "DRIVER IS COMING",
                    Content = "Your driver is on the way to pick you up, get ready please.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.PickedUp,
                    Tittle = "TRIP BEGINS",
                    Content = "Have a nice trip. Wish you have a good experience in your trip.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.Completed,
                    Tittle = "TRIP COMPLETED",
                    Content = "You have arrived, see you again in a next trip. Thanks for using our service.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.HasNewRating,
                    Tittle = "NEW RATING AND FEEDBACK",
                    Content = "You receive a new rating and feedback. Click for details.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.HaveTripInDay,
                    Tittle = "DON'T FORGET TODAY TRIP",
                    Content = "Today, you have trip(s) to complete. Good luck.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.CompletedRefund,
                    Tittle = "REFUND COMPLETE",
                    Content = "We have refunded for you successfully.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.NearlyBan,
                    Tittle = "BE CAUTIONS!!!",
                    Content = "Be careful with the rate of cancelled trip, you reach 80% of permission of cancelled trip rate.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.BanDriver,
                    Tittle = "YOU WERE BANNED!!!",
                    Content = "You reach the limit of permission of cannceled trip rate, you were banned now. Contact with our office for handling this problem.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.HaveTripSuddenly,
                    Tittle = "NEW TRIP",
                    Content = "You have new trip at this time, please check your schedule today.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.TripIncome,
                    Tittle = "TRIP INCOME",
                    Content = "You have received your earning for completed trip.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.NewReport,
                    Tittle = "NEW REPORT",
                    Content = "You have received new report that need to processing.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.CancelByBooker,
                    Tittle = "BOOKER CANCEL YOUR TRIP",
                    Content = "Booker canceled your trips, don't worry we will find new trip for you.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                }
            };

            builder.Entity<Event>().HasData(events);
        }
    }
}
