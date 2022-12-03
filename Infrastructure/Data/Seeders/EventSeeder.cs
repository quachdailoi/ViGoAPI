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
                    Title = "FINDING DRIVER IS DONE",
                    Content = "The process of finding drivers for your booking is done. Don't worry if there is not any trips without driver, we continue to find driver for you. A trip without driver will be refunded on 20:00 of the day before the trip occurs.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.PaidBooking,
                    Title = "BOOKING WAS PAID SUCCESSFULLY",
                    Content = "Thanks for using our service, your booking is in the process of finding drivers.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.Promotion,
                    Title = "YOU HAVE A VOUCHER",
                    Content = "Hot voucher is waiting for you. Use now lest miss it.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.RefundBooking,
                    Title = "NOT FOUND ANY DRIVERS FOR YOUR NEXT TRIP",
                    Content = "There's not any suitable drivers for your next trip, sorry for this omission. We will refund for it.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.RefundBookingDetail,
                    Title = "YOUR DRIVER HAS PROBLEM",
                    Content = "Your driver has problem and he/she cannot come to pick you up, sorry for this omission. We will refund for it.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.StartTrip,
                    Title = "DRIVER IS COMING",
                    Content = "Your driver is on the way to pick you up, get ready please.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.PickedUp,
                    Title = "TRIP BEGINS",
                    Content = "Have a nice trip. Wish you have a good experience in your trip.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.Completed,
                    Title = "TRIP COMPLETED",
                    Content = "You have arrived, see you again in a next trip. Thanks for using our service.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.HasNewRating,
                    Title = "NEW RATING AND FEEDBACK",
                    Content = "You receive a new rating and feedback. Click for details.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.HaveTripInDay,
                    Title = "DON'T FORGET TODAY TRIP",
                    Content = "Today, you have trip(s) to complete. Good luck.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.CompletedRefund,
                    Title = "REFUND COMPLETE",
                    Content = "We have refunded for you successfully.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.NearlyBan,
                    Title = "BE CAUTIONS!!!",
                    Content = "Be careful with the rate of cancelled trip, you reach 80% of permission of cancelled trip rate.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.BanDriver,
                    Title = "YOU WERE BANNED!!!",
                    Content = "You reach the limit of permission of cannceled trip rate, you were banned now. Contact with our office for handling this problem.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.HaveTripSuddenly,
                    Title = "NEW TRIP",
                    Content = "You have new trip at this time, please check your schedule today.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.TripIncome,
                    Title = "TRIP INCOME",
                    Content = "You have received your earning for completed trip.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.NewReport,
                    Title = "NEW REPORT",
                    Content = "You have received new report that need to processing.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.CancelByBooker,
                    Title = "BOOKER CANCEL YOUR TRIP",
                    Content = "Booker canceled your trips, don't worry we will find new trip for you.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.SubmitRegistrationSuccess,
                    Title = "VIGO: Submit Registration Successfully.",
                    Content = "Hi {0}, We received your driver registration and we will reponse to you the result as soon as posible.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.VerifyEmailByLinkNewDriver,
                    Title = "VIGO: Final Step To Become Our Driver.",
                    Content = "Hi {0}, All your information was approved. Now verify your email to login into our system by click this link: {1}",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.VerifyEmailByLinkOldDriver,
                    Title = "VIGO: Verify Your Email.",
                    Content = "Hi {0}, In order to verify your mail, please click to this link: {1}",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.RejectDriverRegistration,
                    Title = "VIGO: Your Driver Registration Was Rejected.",
                    Content = "Hi {0}, some information of your driver registration was not correct so it was rejected. Please go to our office to support.",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                },
                new()
                {
                    Id = Domain.Shares.Enums.Events.Types.VerifyPhoneByLink,
                    Title = "VIGO: Verify Your Phone Number.",
                    Content = "Hi {0}, In order to verify your mail, please click to this link: {1}",
                    Status = Domain.Shares.Enums.Events.Status.Active,
                    Type = Domain.Shares.Enums.Events.SubTypes.Default
                }
            };

            builder.Entity<Event>().HasData(events);
        }
    }
}
