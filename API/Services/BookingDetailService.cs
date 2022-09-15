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

        public List<BookingDetail> GenerateBookingDetail(Booking booking)
        {
            List<BookingDetail> bookingDetails = new();
            if (booking.Type == Bookings.Type.Monthly)
            {
                var daysOfMonthHashSet = booking.Days.DaysOfMonth.ToHashSet();
                for (var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
                {
                    if (daysOfMonthHashSet.Contains(day.Day))
                    {
                        bool isIgnoreDate = false;

                        //if (booking.Days.IgnoreDaysByMonth.TryGetValue(day.Month, out List<int> ignoreDaysInMonth))
                        //{
                        //    if (ignoreDaysInMonth.Contains(day.Day))
                        //    {
                        //        isIgnoreDate = true;
                        //    }
                        //}

                        if(!isIgnoreDate)
                            bookingDetails.Add(new BookingDetail
                            {
                                Booking = booking,
                                Date = day,
                            });
                    }
                    else
                    {
                        if(booking.Days.AdditionalDaysByMonth.TryGetValue(day.Month, out List<int> additionalDaysInMonth))
                        {
                            if (additionalDaysInMonth.Contains(day.Day))
                            {
                                bookingDetails.Add(new BookingDetail
                                {
                                    Booking = booking,
                                    Date = day,
                                });
                            }
                        }
                    }
                }
            }
            else
            {
                var daysOfWeekHashSet = booking.Days.DaysOfWeek.ToHashSet();
                for (var day = booking.StartAt; day <= booking.EndAt; day = day.AddDays(1))
                {
                    if (daysOfWeekHashSet.Contains(day.DayOfWeek))
                    {
                        bookingDetails.Add(new BookingDetail
                        {
                            Booking = booking,
                            Date = day,
                        });
                    }
                };
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
