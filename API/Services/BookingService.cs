using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using API.TaskQueues;
using API.TaskQueues.TaskResolver;
using API.Utils;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IPromotionService _promotionService;
        private readonly IFareService _fareService;
        private readonly IPaymentService _paymentService;
        private readonly IBookingDetailDriverService _bookingDetailDriverService;
        private readonly IRedisMQService _redisMQService;

        public BookingService
            (IUnitOfWork unitOfWork, IMapper mapper, IBookingDetailService bookingDetailService, 
            IPromotionService promotionService, IFareService fareService, IPaymentService paymentService, 
            IBookingDetailDriverService bookingDetailDriverService, IRedisMQService redisMQService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookingDetailService = bookingDetailService;
            _promotionService = promotionService;
            _fareService = fareService;
            _paymentService = paymentService;
            _bookingDetailDriverService = bookingDetailDriverService;
            _redisMQService = redisMQService;
        }
        private async Task<Booking> GenerateBooking(BookingDTO dto)
        {
            var booking = _mapper.Map<BookingDTO, Booking>(dto);

            var routeStations =
                await _unitOfWork.RouteStations
                .List(routeStation =>
                    routeStation.Station.Code == dto.StartStationCode ||
                    routeStation.Station.Code == dto.EndStationCode &&
                    routeStation.Route.Code == dto.RouteCode)
                .Include(routeStation => routeStation.Station)
                .ToListAsync();

            var route = await _unitOfWork.Routes
                .List(route => route.Code == dto.RouteCode && route.Status == StatusTypes.Route.Active)
                .FirstOrDefaultAsync();

            if (route != null && routeStations.GroupBy(e => e.StationId).Count() == 2)
            {
                booking.RouteId = route.Id;

                var startStation = routeStations.Where(routeStation => routeStation.Station.Code == dto.StartStationCode).First();
                var endStation = routeStations.Where(routeStation => routeStation.Station.Code == dto.EndStationCode).First();

                // estimate distance
                booking.Distance = (startStation.DistanceFromFirstStationInRoute <= endStation.DistanceFromFirstStationInRoute) ?
                    endStation.DistanceFromFirstStationInRoute - startStation.DistanceFromFirstStationInRoute :
                    route.Distance - (startStation.DistanceFromFirstStationInRoute - endStation.DistanceFromFirstStationInRoute);


                // estimate time
                booking.Duration = (startStation.DurationFromFirstStationInRoute <= endStation.DurationFromFirstStationInRoute) ?
                    endStation.DurationFromFirstStationInRoute - startStation.DurationFromFirstStationInRoute :
                    route.Duration - (startStation.DurationFromFirstStationInRoute - endStation.DurationFromFirstStationInRoute);

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
        public async Task<Response> Create(
            BookingDTO dto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response invalidRouteResponse, 
            Response duplicationResponse, Response invalidPromotionResponse, Response notAvailableResponse, Response errorReponse)
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

            if (duplicateBookings.Any()) return duplicationResponse;

            //// filter in server
            //if (duplicateBookings.Any())
            //{
            //    var bookingDetailDateHashSet = 
            //        duplicateBookings
            //        .Select(b => b.BookingDetails.Select(_b => _b.Date))
            //        .Aggregate((current, next) => current.Union(next))
            //        .ToHashSet();

            //    var insertedBookingDetailDateHashSet = 
            //        booking.BookingDetails.Select(b => b.Date).ToHashSet();

            //    insertedBookingDetailDateHashSet.IntersectWith(bookingDetailDateHashSet);

            //    if(insertedBookingDetailDateHashSet.Any())
            //        return duplicationResponse;
            //}

            // check for exist available driver for this trip 

            await _unitOfWork.CreateTransactionAsync();

            booking = await _unitOfWork.Bookings.Add(booking);

            if (booking == null) return errorReponse;

            var bookingViewModel = 
                await _unitOfWork.Bookings
                    .List(_booking => _booking.Id == booking.Id)
                    .MapTo<BookerBookingViewModel>(_mapper)
                    .FirstOrDefaultAsync();

            dynamic paymentUrl = String.Empty;
            try
            {
                switch (booking.PaymentMethod)
                {
                    case Payments.PaymentMethods.Momo:
                        ((MomoCollectionLinkRequestDTO)paymentDto).amount = (long)booking.TotalPrice;
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderId = booking.Code.ToString();
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderInfo = "Pay for ViGo booking";
                        var response = await _paymentService.GenerateMomoPaymentUrl((MomoCollectionLinkRequestDTO)paymentDto);
                        paymentUrl = new
                        {
                            PayUrl = response.payUrl,
                            Deeplink = response.deeplink,
                            DeeplinkMiniApp = response.deeplinkMiniApp
                        };
                        break;
                    case Payments.PaymentMethods.COD:
                        await _redisMQService.Publish(MappingBookingTask.BOOKING_QUEUE, booking.Id);
                        break;
                    default: break;
                }
            }
            catch(Exception ex)
            {
                await _unitOfWork.Rollback();
                return errorReponse.SetMessage(ex.Message);
            }
            
            await _unitOfWork.CommitAsync();

            return successResponse.SetData(new 
            { 
                Booking = bookingViewModel.ProcessStationOrder(),
                PaymentUrl = paymentUrl
            } 
            );
        }

        private bool IsSatisfiedTripInRouteRoutineOrderCondition(BookingDetail? prevBookingDetail, BookingDetail? nextBookingDetail, BookingDetail bookingDetail, Dictionary<Guid,RouteStation> routeStationDic)
        {
            var isSatisfiedPrevBookingDetail = true;
            var isSatisfiedNextBookingDetail = true;

            var curBookingDetailStartTime = bookingDetail.Booking.Time;
            var curBookingDetailEndTime = bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration / 60);

            var curStartStation = routeStationDic[bookingDetail.Booking.StartStationCode];
            var curEndStation = routeStationDic[bookingDetail.Booking.EndStationCode];

            if (prevBookingDetail != null)
            {
                var prevEndStation = routeStationDic[prevBookingDetail.Booking.EndStationCode];
                var prevBookingDetailEndTime = prevBookingDetail.Booking.Time.AddMinutes(prevBookingDetail.Booking.Duration);
                var timeArriveCur = prevBookingDetailEndTime.AddMinutes((curStartStation.DurationFromFirstStationInRoute - prevEndStation.DurationFromFirstStationInRoute) / 60);

                isSatisfiedPrevBookingDetail = timeArriveCur >= prevBookingDetailEndTime && timeArriveCur <= curBookingDetailStartTime;
            }

            if(nextBookingDetail != null)
            {
                var nextStartStation = routeStationDic[nextBookingDetail.Booking.StartStationCode];
                var nextBookingDetailStartTime = nextBookingDetail?.Booking.Time;
                var timeArriveNext = curBookingDetailEndTime.AddMinutes((nextStartStation.DurationFromFirstStationInRoute - curEndStation.DurationFromFirstStationInRoute) / 60);

                isSatisfiedNextBookingDetail = timeArriveNext <= nextBookingDetailStartTime && timeArriveNext >= curBookingDetailEndTime;
            }

            return isSatisfiedPrevBookingDetail && isSatisfiedNextBookingDetail;
        }
        private bool IsSatisfiedTimeCondition(TimeOnly? prevEndTime, TimeOnly? nextStartTime, TimeOnly curStartTime, TimeOnly curEndTime)
        {
            return (prevEndTime == null || prevEndTime < curStartTime) &&  (nextStartTime == null || nextStartTime > curEndTime);
        }
        private int? FindPositionInOrderMappingWithRouteRoutine(List<BookingDetail> bookingDetailMappeds, BookingDetail bookingDetail, Dictionary<Guid, RouteStation> routeStationDic)
        {
            BookingDetail? prevBookingDetail = null;
            for(var index = 0; index <= bookingDetailMappeds.Count; index++)
            {
                BookingDetail? nextBookingDetail = index < bookingDetailMappeds.Count ? bookingDetailMappeds[index] : null;

                TimeOnly? prevEndTime = prevBookingDetail?.Booking.Time.AddMinutes(prevBookingDetail.Booking.Duration / 60);
                TimeOnly? nextStartTime = nextBookingDetail?.Booking.Time;

                var curStartTime = bookingDetail.Booking.Time;
                var curEndTime = bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration/60);

                if (IsSatisfiedTimeCondition(prevEndTime, nextStartTime, curStartTime, curEndTime) &&
                    IsSatisfiedTripInRouteRoutineOrderCondition(prevBookingDetail, nextBookingDetail, bookingDetail, routeStationDic)){
                    return index;
                }
            }
            return null;
        }
        private bool IsSatisfiedRouteRoutineCondition(RouteRoutine routeRoutine, BookingDetail bookingDetail)
        {
            if (bookingDetail.Date < routeRoutine.StartAt || bookingDetail.Date > routeRoutine.EndAt) return false;

            var bookingStartTime = bookingDetail.Booking.Time;
            var bookingEndTime = bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration/60);

            var routeStationDic = bookingDetail.Booking.Route.RouteStations.ToDictionary(e => e.Station.Code);

            var bookingDetailMappedsInRouteRoutine = routeRoutine.User.BookingDetailDrivers.Select(bdr => bdr.BookingDetail).ToList();

            return FindPositionInOrderMappingWithRouteRoutine(bookingDetailMappedsInRouteRoutine, bookingDetail, routeStationDic) != null;
        }
        public async Task<Booking?> Mapping(int bookingId)
        {
            var booking =
                await _unitOfWork.Bookings
                .List(e => e.Id == bookingId && e.Status == Bookings.Status.PendingMapping)
                .Include(e => e.User)
                .Include(e => e.BookingDetails)
                .Include(e => e.Route)
                .ThenInclude(route => route.RouteStations)
                .ThenInclude(routeStation => routeStation.Station)
                .FirstOrDefaultAsync();

            if (booking == null) return null;

            var bookingDetails = booking.BookingDetails;
            var bookingDetailDrivers = new List<BookingDetailDriver>();

            var routeRoutines = 
                await _unitOfWork.RouteRoutines
                .List(routeRoutine => !(routeRoutine.StartAt > booking.EndAt || routeRoutine.EndAt < booking.StartAt) &&
                                      !(routeRoutine.EndTime < booking.Time || routeRoutine.StartTime > booking.Time.AddMinutes(booking.Duration/60)) &&
                                      routeRoutine.RouteId == booking.RouteId)
                .Include(e => e.User)
                .ThenInclude(u => u.BookingDetailDrivers)
                .ThenInclude(bdr => bdr.BookingDetail)
                .ThenInclude(bd => bd.Booking)
                .ToListAsync();

            foreach(var bookingDetail in bookingDetails)
            {
                routeRoutines.ForEach(routeRoutine =>
                {
                    routeRoutine.User.BookingDetailDrivers = routeRoutine.User.BookingDetailDrivers
                            .Where(bdr =>
                                bdr.BookingDetail.Date == bookingDetail.Date &&
                                bdr.BookingDetail.Booking.Time >= routeRoutine.StartTime &&
                                bdr.BookingDetail.Booking.Time <= routeRoutine.EndTime &&
                                bdr.Status == BookingDetailDrivers.Status.Pending)
                            .OrderBy(bdr => bdr.BookingDetail.Booking.Time)
                            .ToList();
                });

                //order by total number of mapped booking with driver in detail booking datetime
                var orderedRouteRoutines = routeRoutines
                    .OrderBy(routeRoutine => routeRoutine.User.BookingDetailDrivers.Count);

                //then order by driver point

                foreach (var routeRoutine in orderedRouteRoutines)
                {
                    if (IsSatisfiedRouteRoutineCondition(routeRoutine, bookingDetail))
                    {
                        bookingDetailDrivers.Add(new BookingDetailDriver
                        {
                            BookingDetail = bookingDetail,
                            Driver = routeRoutine.User
                        });
                        break;
                    }
                }
            }

            if (bookingDetailDrivers.Any()) bookingDetailDrivers = await _bookingDetailDriverService.Create(bookingDetailDrivers);

            booking.BookingDetails = bookingDetails.UnionBy(bookingDetailDrivers.Select(bdr => bdr.BookingDetail), e => e.Id).ToList();

            return booking;
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
        public Task<Booking?> GetByCode(Guid code) => _unitOfWork.Bookings.List(booking => booking.Code == code).Include(booking => booking.User).FirstOrDefaultAsync();
        public Task<bool> Update(Booking booking) => _unitOfWork.Bookings.Update(booking);
    }
}
