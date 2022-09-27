using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using API.Utils;
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
        private readonly IFareService _fareService;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper, IBookingDetailService bookingDetailService, IPromotionService promotionService, IFareService fareService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookingDetailService = bookingDetailService;
            _promotionService = promotionService;
            _fareService = fareService;
        }
        private async Task<Booking> GenerateBooking(BookingDTO dto)
        {
            var booking = _mapper.Map<BookingDTO, Booking>(dto);

            var routeStations =
                await _unitOfWork.RouteStations
                .List(routeStation =>
                    routeStation.Station.Code == dto.StartStationCode ||
                    routeStation.Station.Code == dto.EndStationCode &&
                    routeStation.RouteId == dto.RouteId)
                .Include(routeStation => routeStation.Station)
                .ToListAsync();

            var route = await _unitOfWork.Routes
                .List(route => route.Id == dto.RouteId && route.Status == StatusTypes.Route.Active)
                .FirstOrDefaultAsync();

            if (route != null && routeStations.GroupBy(e => e.StationId).Count() == 2)
            {
                var startStation = routeStations.Where(routeStation => routeStation.Station.Code == dto.StartStationCode).First();
                var endStation = routeStations.Where(routeStation => routeStation.Station.Code == dto.EndStationCode).First();

                // estimate distance
                booking.Distance = (startStation.Index <= endStation.Index) ?
                    endStation.DistanceFromFirstStationInRoute - startStation.DistanceFromFirstStationInRoute :
                    route.Distance - (startStation.DistanceFromFirstStationInRoute - endStation.DistanceFromFirstStationInRoute);


                // estimate time
                booking.Duration = (startStation.Index <= endStation.Index) ?
                    endStation.DurationFromFirstStationInRoute - startStation.DurationFromFirstStationInRoute :
                    route.Distance - (startStation.DurationFromFirstStationInRoute - endStation.DurationFromFirstStationInRoute);

                // caculate price
                booking.TotalPrice = (await _fareService.CaculateBookingFee(dto.Type, dto.VehicleTypeId, dto.StartAt, dto.EndAt, booking.Distance, dto.Time)).TotalFee;

                // generate booking detail by booking schedule
                booking.BookingDetails = _bookingDetailService.GenerateBookingDetail(booking);

                if (!String.IsNullOrEmpty(dto.PromotionCode))
                {
                    var promotion = await _promotionService.GetPromotionByCode(dto.PromotionCode, booking.UserId, booking.TotalPrice, booking.BookingDetails.Count, booking.PaymentMethod);

                    //if (promotion == null) return invalidPromotionResponse;

                    if(promotion != null)
                    {
                        // get discount price by promotion
                        var discountPriceByPercentage = booking.TotalPrice * promotion.DiscountPercentage;

                        // compare with promotion max descrease
                        booking.DiscountPrice = discountPriceByPercentage < promotion.MaxDecrease ? discountPriceByPercentage : promotion.MaxDecrease;

                        booking.PromotionId = promotion.Id;
                    }                 
                }
            }

            return booking;
        }
        public async Task<Response> Create(BookingDTO dto, Response successResponse, Response invalidRouteResponse, Response duplicationResponse, Response invalidPromotionResponse, Response notAvailableResponse, Response errorReponse)
        {
            var booking = await GenerateBooking(dto);

            if (booking.BookingDetails.Count == 0) return invalidRouteResponse;
            if (!booking.PromotionId.HasValue && !String.IsNullOrEmpty(dto.PromotionCode)) return invalidPromotionResponse; 

            // filter in database
            var duplicateBookings = 
                await _unitOfWork.Bookings
                .List(e => 
                    !(e.Time.AddMinutes(e.Duration / 60) < booking.Time || 
                    e.Time > booking.Time.AddMinutes(booking.Duration / 60)) &&
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
                    return duplicationResponse;
            }

            // check for exist available driver for this trip 

            booking = await _unitOfWork.Bookings.Add(booking);

            if (booking == null) return errorReponse;

            var bookingViewModel = 
                await _unitOfWork.Bookings
                    .List(_booking => _booking.Id == booking.Id)
                    .MapTo<BookerBookingViewModel>(_mapper)
                    .FirstOrDefaultAsync();

            

            //add job queue to map with specific driver

            return successResponse.SetData(bookingViewModel.ProcessStationOrder());
        }

        public async Task<Response> GetAll(int userId, Response successReponse)
        {
            var bookings = _unitOfWork.Bookings
                .List(booking => booking.UserId == userId);

            var routes = _unitOfWork.Routes.List();

            var routeStations = _unitOfWork.RouteStations.List();

            var bookingViewModels = 
                await _unitOfWork.Bookings
                    .List(booking => booking.UserId == userId)
                    .MapTo<BookerBookingViewModel>(_mapper)
                    .ToListAsync();

            foreach(var booking in bookingViewModels)
            {
                booking.ProcessStationOrder();
            }

            return successReponse.SetData(bookingViewModels);
        }

        public async Task<Response> GetProvision(BookingDTO dto, Response successResponse, Response invalidRouteResponse, Response invalidPromotionResponse)
        {
            var booking = await GenerateBooking(dto);

            if (booking.BookingDetails.Count == 0) return invalidRouteResponse;
            if (!booking.PromotionId.HasValue && !String.IsNullOrEmpty(dto.PromotionCode)) return invalidPromotionResponse;

            return successResponse.SetData(new FeeViewModel
            {
                Fee = booking.TotalPrice,
                DiscountFee = booking.DiscountPrice,
                TotalFee = booking.TotalPrice - booking.DiscountPrice
            });
        }
    }
}
