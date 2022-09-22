using API.Models;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BookingDetailService: IBookingDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public List<BookingDetail> GenerateBookingDetail(Booking booking)
        //{
        //    List<BookingDetail> bookingDetails = new();
        //    if (booking.Type == Bookings.Types.Monthly)
        //    {
        //        var daysOfMonthHashSet = booking.Days.DaysOfMonth.ToHashSet();

        //        var startYear = booking.StartAt.Year;
        //        var endYear = booking.EndAt.Year;

        //        var bookingDetailsDic = new Dictionary<DateOnly, BookingDetail>();

        //        for(var year = startYear; year <= endYear; year++)
        //        {
        //            var startMonth = booking.StartAt.Month;
        //            var endMonth = booking.EndAt.Month;
        //            if (year != endYear)
        //            {
        //                endMonth = 12;
        //            }

        //            if(year != startYear)
        //            {
        //                startMonth = 1;
        //            }

        //            for(var month = startMonth; month <= endMonth; month++)
        //            {
        //                var totalApplyChangeInNextMonth = 0;
        //                foreach (var day in daysOfMonthHashSet)
        //                {                         
        //                    try
        //                    {
        //                        DateOnly date = new DateOnly(year, month, day);
        //                        bookingDetailsDic.Add(date,new BookingDetail
        //                        {
        //                            Booking = booking,
        //                            Date = date,
        //                        });
        //                    }
        //                    catch
        //                    {
        //                        if(booking.Option == Bookings.Options.ChangeToNextDayOfNextMonth)
        //                        {
        //                            totalApplyChangeInNextMonth++;
        //                        }
        //                    }                            
        //                }

        //                for (var day = 1; day <= totalApplyChangeInNextMonth; day++)
        //                {
        //                    DateOnly date = new DateOnly(year, month + 1, day);                               
        //                    bookingDetailsDic.Add(date, new BookingDetail
        //                    {
        //                        Booking = booking,
        //                        Date = date,
        //                    });
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        var daysOfWeekHashSet = booking.Days.DaysOfWeek.ToHashSet();
        //        for (var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
        //        {
        //            if (daysOfWeekHashSet.Contains(day.DayOfWeek))
        //            {
        //                bookingDetails.Add(new BookingDetail
        //                {
        //                    Booking = booking,
        //                    Date = day,
        //                });
        //            }
        //        };
        //    }
        //    return bookingDetails;
        //}

        public List<BookingDetail> GenerateBookingDetail(Booking booking)
        {
            List<BookingDetail> bookingDetails = new();
            for(var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
            {
                bookingDetails.Add(new BookingDetail
                {
                    Booking = booking,
                    Date = day
                });
            }
            return bookingDetails;
        }
        public async Task<Response> GetNextBookingDetail(int userId, Response successResponse)
        {
            var bookingDetailsIQueryable = _unitOfWork.BookingDetails.List(b => b.Booking.UserId == userId && b.Status != StatusTypes.BookingDetail.Completed)
                                                                .OrderBy(b => b.Date)
                                                                .ThenBy(b => b.Booking.Time);


            var bookingDetail = await _mapper.ProjectTo<BookerBookingDetailViewModel>(bookingDetailsIQueryable).FirstOrDefaultAsync();

            return successResponse.SetData(bookingDetail);
        }
    }
}
