using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBookingDetailService _bookingDetailService;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper, IBookingDetailService bookingDetailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookingDetailService = bookingDetailService;
        }

        public async Task<Response> Create(BookingDTO dto, Response successResponse, Response duplicateResponse, Response errorReponse)
        {
            var booking = _mapper.Map<BookingDTO, Booking>(dto);

            // fake data

            Random random = new Random();

            booking.TotalPrice =  100000 + random.NextDouble() * 150000.0;
            booking.DiscountPrice = 10000 + random.NextDouble() * 15000.0;
            booking.Distance = random.Next(3000, 10000);
            booking.Duration = booking.Distance / 12;
            
            // fake data

            booking.BookingDetails = _bookingDetailService.GenerateBookingDetail(booking);

            // filter in database server
            var duplicateBookings = await _unitOfWork.Bookings.List(e => !(e.Time.ToTimeSpan().TotalSeconds + e.Duration < booking.Time.ToTimeSpan().TotalSeconds || e.Time.ToTimeSpan().TotalSeconds > booking.Time.ToTimeSpan().TotalSeconds + booking.Duration) &&
                                                                        e.UserId == booking.UserId && !(e.StartAt > booking.EndAt || e.EndAt < booking.StartAt))
                                                              .Include(e => e.BookingDetails)
                                                              .ToListAsync();

            // filter in app client
            if (duplicateBookings.Any())
            {
                var bookingDetailDateHashSet = duplicateBookings.Select(b => b.BookingDetails.Select(_b => _b.Date))
                                                               .Aggregate((current, next) => current.Union(next))
                                                               .ToHashSet();
                var insertedBookingDetailDateHashSet = booking.BookingDetails.Select(b => b.Date).ToHashSet();

                insertedBookingDetailDateHashSet.IntersectWith(bookingDetailDateHashSet);

                if(insertedBookingDetailDateHashSet.Any())
                    return duplicateResponse;
            }

            booking = await _unitOfWork.Bookings.Add(booking);

            var bookingViewModel = await _unitOfWork.Bookings.List(booking => booking.Id == booking.Id).MapTo<BookerBookingViewModel>(_mapper).FirstOrDefaultAsync();

            if (bookingViewModel == null) return errorReponse;

            //add job queue to map with specific driver

            return successResponse.SetData(bookingViewModel);
        }
        public async Task<List<Booking>> GetAll()
        {
            var booking = await _unitOfWork.Bookings.List(booking => EF.Functions.JsonContains(booking.Days.DaysOfMonth, "4")).FirstOrDefaultAsync();

            var result = await _unitOfWork.BookingDetails.List(bookingDetail => bookingDetail.Booking.Status == StatusTypes.Booking.Started)
                                                                     .Where(bookingDetail =>
                                                                                    booking.BookingDetails.Any(b =>
                                                                                                        (b.Booking.Time.ToTimeSpan().TotalSeconds + b.Booking.Duration) < booking.Time.ToTimeSpan().TotalSeconds ||
                                                                                                        b.Booking.Time.ToTimeSpan().TotalSeconds > booking.Time.ToTimeSpan().TotalSeconds + booking.Duration))
                                                                     .Select(bookingDetail => bookingDetail.Date)
                                                                     .Where(date => booking.BookingDetails.Select(bookingDetail => bookingDetail.Date).Contains(date))
                                                                     .ToListAsync();
            return new();
        }
        public async Task<Response> GetAll(int userId, Response successReponse, Response notFoundResponse)
        {
            var bookingViewModels = await _unitOfWork.Bookings.List(booking => booking.UserId == userId).MapTo<BookerBookingViewModel>(_mapper).ToListAsync();

            if (!bookingViewModels.Any()) return notFoundResponse;

            return successReponse.SetData(bookingViewModels);
        }
    }
}
