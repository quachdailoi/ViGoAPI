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
        private readonly IPromotionService _promotionService;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper, IBookingDetailService bookingDetailService, IPromotionService promotionService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookingDetailService = bookingDetailService;
            _promotionService = promotionService;
        }

        public async Task<Response> Create(BookingDTO dto, Response successResponse, Response duplicateResponse, Response invalidResponse, Response errorReponse)
        {
            var booking = _mapper.Map<BookingDTO, Booking>(dto);

            // generate booking detail by booking schedule
            booking.BookingDetails = _bookingDetailService.GenerateBookingDetail(booking);

            if (!String.IsNullOrEmpty(dto.PromotionCode))
            {
                var promotion = await _promotionService.GetPromotionByCode(dto.PromotionCode, booking.UserId, booking.TotalPrice, booking.BookingDetails.Count);

                if (promotion == null) return invalidResponse;

                // get discount price by promotion
                var discountPriceByPercentage = booking.TotalPrice * (1 - promotion.DiscountPercentage);

                // compare with promotion max descrease
                booking.DiscountPrice = discountPriceByPercentage < promotion.MaxDecrease ? discountPriceByPercentage : promotion.MaxDecrease;

                booking.PromotionId = promotion.Id;
            }

            // filter in database
            var duplicateBookings = 
                await _unitOfWork.Bookings
                .List(e => 
                    !(e.Time.ToTimeSpan().TotalSeconds + e.Duration < booking.Time.ToTimeSpan().TotalSeconds || 
                    e.Time.ToTimeSpan().TotalSeconds > booking.Time.ToTimeSpan().TotalSeconds + booking.Duration) &&
                    e.UserId == booking.UserId && !(e.StartAt > booking.EndAt || e.EndAt < booking.StartAt))
                .Include(e => e.BookingDetails)
                .ToListAsync();

            // filter in server
            if (duplicateBookings.Any())
            {
                var bookingDetailDateHashSet = 
                    duplicateBookings
                    .Select(b => b.BookingDetails.Select(_b => _b.Date))
                    .Aggregate((current, next) => current.Union(next))
                    .ToHashSet();

                var insertedBookingDetailDateHashSet = 
                    booking.BookingDetails.Select(b => b.Date).ToHashSet();

                insertedBookingDetailDateHashSet.IntersectWith(bookingDetailDateHashSet);

                if(insertedBookingDetailDateHashSet.Any())
                    return duplicateResponse;
            }

            booking = await _unitOfWork.Bookings.Add(booking);

            var bookingViewModel = 
                await _unitOfWork.Bookings
                    .List(booking => booking.Id == booking.Id)
                    .MapTo<BookerBookingViewModel>(_mapper)
                    .FirstOrDefaultAsync();

            if (bookingViewModel == null) return errorReponse;

            //add job queue to map with specific driver

            return successResponse.SetData(bookingViewModel);
        }
        public async Task<List<Booking>> GetAll()
        {
            return new();
        }
        public async Task<Response> GetAll(int userId, Response successReponse)
        {
            var bookingViewModels = 
                await _unitOfWork.Bookings
                    .List(booking => booking.UserId == userId)
                    .MapTo<BookerBookingViewModel>(_mapper)
                    .ToListAsync();


            return successReponse.SetData(bookingViewModels);
        }
    }
}
