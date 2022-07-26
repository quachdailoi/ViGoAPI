﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shares.Enums
{
    public class Events
    {
        public enum SubTypes
        {
            Default = 0
        }
        public enum Types
        {
            MappingBooking = 1,
            PaidBooking = 2,
            RefundBooking = 3,
            RefundBookingDetail = 4,
            Promotion = 5,
            StartTrip = 6,
            PickedUp = 7,
            Completed = 8,
            HasNewRating = 9,
            HaveTripInDay = 10,
            CompletedRefund = 11,
            NearlyBan = 12,
            BanDriver = 13,
            HaveTripSuddenly = 14,
            TripIncome = 15,
            NewReport = 16,
            CancelByBooker = 17,
            SubmitRegistrationSuccess = 18,
            VerifyEmailByLinkNewDriver = 19,
            VerifyEmailByLinkOldDriver = 20,
            RejectDriverRegistration = 21,
            VerifyPhoneByLink = 22,
        }

        public enum Status
        {
            Inactive,
            Active
        }
    }
}
