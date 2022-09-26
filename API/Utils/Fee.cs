using Domain.Shares.Enums;

namespace API.Utils
{
    public class Fee
    {
        private const double BASE_DISTANCE = 2000;
        private const int MAX_QUANTITY_DAY_IN_WEEK = 7;
        private const int MAX_QUANTITY_DAY_IN_MONTH = 31;
        private const int MAX_QUANTITY_DAY_IN_QUARTER = 92;
        private static readonly List<int> StartMonthInQuarter = new List<int> { 1, 4, 7, 10 };

        private static readonly Dictionary<VehicleTypes.Type, Fare> FaresByVehicle = new Dictionary<VehicleTypes.Type, Fare>
        {
            { VehicleTypes.Type.ViRide, new Fare { BasePrice =  10000, PricePerKilometers = 3000}},
            { VehicleTypes.Type.ViCar, new Fare { BasePrice =  17000, PricePerKilometers = 10000}},
            //{ VehicleTypes.ViCar_7, new Fare { BasePrice = 22000, PricePerKilometers = 11000 }}
        };

        private static readonly Dictionary<Bookings.Types, BookingTypeDetail> FeeDiscountByBookingType = new Dictionary<Bookings.Types, BookingTypeDetail>
        {
            { Bookings.Types.WeekTicket, new BookingTypeDetail { Discount = 0.01, TempTotalDate = 7, DateBoundary = 4}},
            { Bookings.Types.MonthTicket, new BookingTypeDetail { Discount = 0.02, TempTotalDate = 28, DateBoundary = 15}},
            { Bookings.Types.QuaterTicket, new BookingTypeDetail { Discount = 0.03, TempTotalDate = 28 * 3}}
        };
        public static double RoundToHundreds(double fee) => Math.Round(fee / 100) * 100;
        public static double CaculateFeeByBookingType(Bookings.Types bookingType, double feePerTrip, DateOnly startDate, DateOnly endDate)
        {
            var bookingTypeDetail = FeeDiscountByBookingType[bookingType];
            var totalTickets = CaculateTotalTicket(bookingType, startDate, endDate);
            return RoundToHundreds(feePerTrip * bookingTypeDetail.TempTotalDate * totalTickets * (1 - bookingTypeDetail.Discount));
        }

        public static double CaculateTotalTicket(Bookings.Types bookingType, DateOnly startDate, DateOnly endDate)
        {
            double totalTicket = 0;

            var totalDate = endDate.ToDateTime(TimeOnly.MinValue).Subtract(startDate.ToDateTime(TimeOnly.MinValue)).TotalDays;

            switch (bookingType)
            {
                case Bookings.Types.WeekTicket:
                    totalTicket = Math.Ceiling(totalDate / MAX_QUANTITY_DAY_IN_WEEK);
                    if ((int)startDate.DayOfWeek >= FeeDiscountByBookingType[bookingType].DateBoundary) totalTicket -= 0.5;
                    break;
                case Bookings.Types.MonthTicket:
                    totalTicket = Math.Ceiling(totalDate / MAX_QUANTITY_DAY_IN_MONTH);
                    if(startDate.Day >= FeeDiscountByBookingType[bookingType].DateBoundary) totalTicket -= 0.5;
                    break;
                case Bookings.Types.QuaterTicket:
                    totalTicket = Math.Ceiling(totalDate / MAX_QUANTITY_DAY_IN_QUARTER);
                    var startMonth = startDate.Month;
                    var startDay = startDate.Day;
                    var startMonthOfCurrentQuarter = StartMonthInQuarter.Where(month => month <= startMonth).OrderBy(month => month).Last();

                    totalTicket -= (startMonth - startMonthOfCurrentQuarter) / 4;
                    break;

                default: break;
            }
            return totalTicket;
        }

        public static double CaculateBookingFee(Bookings.Types bookingType, VehicleTypes.Type vehicleType,double distance, DateOnly startDate, DateOnly endDate)
        {
            double feePerTrip = FaresByVehicle.GetValueOrDefault(vehicleType).BasePrice;

            if (distance > BASE_DISTANCE) feePerTrip += (distance - BASE_DISTANCE) * (FaresByVehicle.GetValueOrDefault(vehicleType).PricePerKilometers / 1000);

            return CaculateFeeByBookingType(bookingType, feePerTrip, startDate, endDate);
        }

        class Fare
        {
            public double BasePrice { get; set; }
            public double PricePerKilometers { get; set; }
        }

        class BookingTypeDetail
        {
            public double Discount { get; set; }
            public int TempTotalDate { get; set; }
            public int DateBoundary { get; set; }
        }
    }

}
