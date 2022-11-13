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
                    Tittle = "Finding driver done.",
                    Content = "Your booking has mapped completely.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.PaidBooking,
                    Tittle = "Your booking was paid successfully.",
                    Content = "Now you just wait for finding driver. Don't worry, if not found any driver for you, we will refund.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.Promotion,
                    Tittle = "You have a voucher!!.",
                    Content = "This is the voucher of November.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.RefundBooking,
                    Tittle = "We don't find any driver for you.",
                    Content = "Not found any driver for you, so we will refund money for you.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.RefundBookingDetail,
                    Tittle = "Suddenly refund",
                    Content = "The next trip was cancelled by driver, we tried to find a new one but do not find anyone. Sorry for this. The fee will refund for you.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.StartTrip,
                    Tittle = "The driver is coming.",
                    Content = "Your driver is coming to pick you up, get ready please.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.PickedUp,
                    Tittle = "Your trip start.",
                    Content = "Have a nice trip.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.Completed,
                    Tittle = "Complete trip",
                    Content = "You have arrived, see you again in a next trip.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.HasNewRating,
                    Tittle = "New Rating And Feedback",
                    Content = "You have new rating and feedback",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.HaveTripInDay,
                    Tittle = "You have a trip today.",
                    Content = "Today, you have a trip to complete. Good luck.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.CompletedRefund,
                    Tittle = "Complete Refund",
                    Content = "We have refunded for you successfully. Sorry for not serving you in the best way.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.HaveTripSuddenly,
                    Tittle = "You have a new trip.",
                    Content = "You have been mapped with new booker at this time.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                }
            };

            builder.Entity<Event>().HasData(events);
        }
    }
}
