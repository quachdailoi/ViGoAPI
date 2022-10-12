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
    public class BookingService : BaseService, IBookingService
    {
        public BookingService(IAppServices appServices) : base(appServices)
        {
        }

        private async Task<Booking> GenerateBooking(BookingDTO dto)
        {
            var booking = Mapper.Map<BookingDTO, Booking>(dto);

            var routeStations =
                await UnitOfWork.RouteStations
                .List(routeStation =>
                    routeStation.Station.Code == dto.StartStationCode ||
                    routeStation.Station.Code == dto.EndStationCode &&
                    routeStation.Route.Code == dto.RouteCode)
                .Include(routeStation => routeStation.Station)
                .ToListAsync();

            var route = await UnitOfWork.Routes
                .List(route => route.Code == dto.RouteCode && route.Status == StatusTypes.Route.Active)
                .FirstOrDefaultAsync();

            if (route != null && routeStations.GroupBy(e => e.StationId).Count() == 2)
            {
                booking.StartRouteStation.RouteId = route.Id;

                var startStation = routeStations.Where(routeStation => routeStation.Station.Code == dto.StartStationCode).First();
                var endStation = routeStations.Where(routeStation => routeStation.Station.Code == dto.EndStationCode).First();

                booking.StartRouteStation = startStation;
                booking.EndRouteStation = endStation;

                // estimate distance
                booking.Distance = (startStation.DistanceFromFirstStationInRoute <= endStation.DistanceFromFirstStationInRoute) ?
                    endStation.DistanceFromFirstStationInRoute - startStation.DistanceFromFirstStationInRoute :
                    route.Distance - (startStation.DistanceFromFirstStationInRoute - endStation.DistanceFromFirstStationInRoute);


                // estimate time
                booking.Duration = (startStation.DurationFromFirstStationInRoute <= endStation.DurationFromFirstStationInRoute) ?
                    endStation.DurationFromFirstStationInRoute - startStation.DurationFromFirstStationInRoute :
                    route.Duration - (startStation.DurationFromFirstStationInRoute - endStation.DurationFromFirstStationInRoute);

                // caculate price
                booking.TotalPrice = (await AppServices.Fare.CaculateBookingFee(dto.Type, dto.VehicleTypeId, dto.StartAt, dto.EndAt, booking.Distance, dto.Time)).TotalFee;

                // generate booking detail by booking schedule
                booking.BookingDetails = AppServices.BookingDetail.GenerateBookingDetail(booking);

                if (!String.IsNullOrEmpty(dto.PromotionCode))
                {
                    var promotion = await AppServices.Promotion.GetPromotionByCode(dto.PromotionCode, booking.UserId, booking.TotalPrice, booking.BookingDetails.Count, booking.PaymentMethod);

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
        public async Task<Response> Create(BookingDTO dto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response invalidRouteResponse, Response duplicationResponse, Response invalidPromotionResponse, Response notAvailableResponse, Response errorReponse)
        {
            var booking = await GenerateBooking(dto);

            if (booking.BookingDetails.Count == 0) return invalidRouteResponse;
            if (!booking.PromotionId.HasValue && !String.IsNullOrEmpty(dto.PromotionCode)) return invalidPromotionResponse; 

            // filter in database
            var duplicateBookings = 
                await UnitOfWork.Bookings
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

            await UnitOfWork.CreateTransactionAsync();

            booking = await UnitOfWork.Bookings.Add(booking);

            if (booking == null) return errorReponse;

            var bookingViewModel = 
                await UnitOfWork.Bookings
                    .List(_booking => _booking.Id == booking.Id)
                    .MapTo<BookerBookingViewModel>(Mapper, AppServices)
                    .FirstOrDefaultAsync();

            var paymentUrl = String.Empty;
            try
            {
                switch (booking.PaymentMethod)
                {
                    case PaymentMethods.Momo:
                        ((MomoCollectionLinkRequestDTO)paymentDto).amount = (long)booking.TotalPrice;
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderId = booking.Code.ToString();
                        paymentUrl = await AppServices.Payment.GenerateMomoPaymentUrl((MomoCollectionLinkRequestDTO)paymentDto);
                        break;
                    case PaymentMethods.COD:
                        await AppServices.RedisMQ.Publish(MappingBookingTask.BOOKING_QUEUE, booking.Id);
                        break;
                    default: break;
                }
            }
            catch(Exception ex)
            {
                Logger<BookingService>().LogError(ex.StackTrace);
                await UnitOfWork.Rollback();
                return errorReponse.SetMessage(ex.Message);
            }
            
            await UnitOfWork.CommitAsync();

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

            var curStartStation = routeStationDic[bookingDetail.Booking.StartRouteStation.Station.Code];
            var curEndStation = routeStationDic[bookingDetail.Booking.EndRouteStation.Station.Code];

            if (prevBookingDetail != null)
            {
                var prevEndStation = routeStationDic[prevBookingDetail.Booking.EndRouteStation.Station.Code];
                var prevBookingDetailEndTime = prevBookingDetail.Booking.Time.AddMinutes(prevBookingDetail.Booking.Duration);
                var timeArriveCur = prevBookingDetailEndTime.AddMinutes((curStartStation.DurationFromFirstStationInRoute - prevEndStation.DurationFromFirstStationInRoute) / 60);

                isSatisfiedPrevBookingDetail = timeArriveCur >= prevBookingDetailEndTime && timeArriveCur <= curBookingDetailStartTime;
            }

            if(nextBookingDetail != null)
            {
                var nextStartStation = routeStationDic[nextBookingDetail.Booking.StartRouteStation.Station.Code];
                var nextBookingDetailStartTime = nextBookingDetail?.Booking.Time;
                var timeArriveNext = curBookingDetailEndTime.AddMinutes((nextStartStation.DurationFromFirstStationInRoute - curEndStation.DurationFromFirstStationInRoute) / 60);

                isSatisfiedNextBookingDetail = timeArriveNext <= nextBookingDetailStartTime && timeArriveNext >= curBookingDetailEndTime;
            }

            return isSatisfiedPrevBookingDetail && isSatisfiedNextBookingDetail;
        }
        private bool IsSatisfiedTimeCondition(TimeOnly? prevEndTime, TimeOnly? nextStartTime, TimeOnly curStartTime, TimeOnly curEndTime)
        {
            return (prevEndTime == null || prevEndTime < curStartTime) &&  (nextStartTime ==null || nextStartTime > curEndTime);
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

            var bookingDetailMappedsInRouteRoutine = routeRoutine.User.BookingDetailDrivers
                .Select(bdr => bdr.BookingDetail)
                .Where(bd => 
                    bd.Date == bookingDetail.Date && 
                    bd.Booking.Time >= routeRoutine.StartTime &&
                    bd.Booking.Time <= routeRoutine.EndTime)
                //.Select(bd => new Tuple<TimeOnly,TimeOnly>(bd.Booking.Time, bd.Booking.Time.AddMinutes(bd.Booking.Duration/60)))
                .OrderBy(bd => bd.Booking.Time)
                .ToList();

            var bookingStartTime = bookingDetail.Booking.Time;
            var bookingEndTime = bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration/60);

            var routeStationDic = bookingDetail.Booking.StartRouteStation.Route.RouteStations.ToDictionary(e => e.Station.Code);

            return FindPositionInOrderMappingWithRouteRoutine(bookingDetailMappedsInRouteRoutine, bookingDetail, routeStationDic) != null;
        }
        public async Task<Booking?> Mapping(int bookingId)
        {
            var booking =
                await UnitOfWork.Bookings
                .List(e => e.Id == bookingId && e.Status == Bookings.Status.PendingMapping)
                .Include(e => e.User)
                .Include(e => e.BookingDetails)
                .Include(e => e.StartRouteStation.Route)
                .ThenInclude(route => route.RouteStations)
                .ThenInclude(routeStation => routeStation.Station)
                .FirstOrDefaultAsync();

            if (booking == null) return null;

            var bookingDetails = booking.BookingDetails;
            var bookingDetailDrivers = new List<BookingDetailDriver>();

            var routeRoutines = 
                await UnitOfWork.RouteRoutines
                .List(routeRoutine => !(routeRoutine.StartAt > booking.EndAt || routeRoutine.EndAt < booking.StartAt) &&
                                      !(routeRoutine.EndTime < booking.Time || routeRoutine.StartTime > booking.Time.AddMinutes(booking.Duration/60)) &&
                                      routeRoutine.RouteId == booking.StartRouteStation.RouteId)
                .Include(e => e.User)
                .ThenInclude(u => u.BookingDetailDrivers)
                .ThenInclude(bdr => bdr.BookingDetail)
                .ThenInclude(bd => bd.Booking)
                .ToListAsync();

            foreach(var bookingDetail in bookingDetails)
            {
                foreach (var routeRoutine in routeRoutines)
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

            if (bookingDetailDrivers.Any()) bookingDetailDrivers = await AppServices.BookingDetailDriver.Create(bookingDetailDrivers);

            booking.BookingDetails = bookingDetails.UnionBy(bookingDetailDrivers.Select(bdr => bdr.BookingDetail), e => e.Id).ToList();

            return booking;
        }

        public async Task<Response> GetAll(int userId, Response successReponse)
        {
            var bookings = UnitOfWork.Bookings
                .List(booking => booking.UserId == userId);

            var routes = UnitOfWork.Routes.List();

            var routeStations = UnitOfWork.RouteStations.List();

            var bookingViewModels = 
                await UnitOfWork.Bookings
                    .List(booking => booking.UserId == userId)
                    .MapTo<BookerBookingViewModel>(Mapper)
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
        public Task<Booking?> GetByCode(Guid code) => UnitOfWork.Bookings.List(booking => booking.Code == code).FirstOrDefaultAsync();
        public Task<bool> Update(Booking booking) => UnitOfWork.Bookings.Update(booking);
    }
}
