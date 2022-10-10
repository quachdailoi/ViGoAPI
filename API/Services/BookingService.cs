using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Response;
using API.Services.Constract;
using API.TaskQueues;
using API.TaskQueues.TaskResolver;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class BookingService : BaseService<BookingService>,IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBookingDetailService _bookingDetailService;
        private readonly IPromotionService _promotionService;
        private readonly IFareService _fareService;
        private readonly IPaymentService _paymentService;
        private readonly IBookingDetailDriverService _bookingDetailDriverService;
        private readonly IVehicleTypeService _vehicleTypeService;
        private readonly IStationService _stationService;
        private readonly IRedisMQService _redisMQService;

        public BookingService(
            IUnitOfWork unitOfWork, IMapper mapper, IBookingDetailService bookingDetailService, 
            IPromotionService promotionService, IFareService fareService, IPaymentService paymentService, 
            IBookingDetailDriverService bookingDetailDriverService, IRedisMQService redisMQService, 
            IVehicleTypeService vehicleTypeService, IStationService stationService, ILogger<BookingService> logger):base(logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bookingDetailService = bookingDetailService;
            _promotionService = promotionService;
            _fareService = fareService;
            _paymentService = paymentService;
            _bookingDetailDriverService = bookingDetailDriverService;
            _redisMQService = redisMQService;
            _vehicleTypeService = vehicleTypeService;
            _stationService = stationService;
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
                var fee = await _fareService.CaculateBookingFee(dto.Type, dto.VehicleTypeId, dto.StartAt, dto.EndAt, booking.Distance, dto.Time);
                booking.TotalPrice = fee.TotalFee;

                // generate booking detail by booking schedule
                booking.BookingDetails = _bookingDetailService.GenerateBookingDetail(booking,fee.FeePerTrip);

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
            BookingDTO dto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response invalidStationResponse, Response invalidVehicleTypeResponse,
            Response invalidRouteResponse, Response duplicationResponse, Response invalidPromotionResponse, Response notAvailableResponse, Response errorReponse)
        {
            var pairOfStation = await _stationService.GetPairOfStation(dto.StartStationCode, dto.EndStationCode);

            if (pairOfStation.Item1 == null || pairOfStation.Item2 == null) return invalidStationResponse;

            VehicleType? vehicleType = await _vehicleTypeService.GetByCode(dto.VehicleTypeCode);

            if (vehicleType == null) return invalidVehicleTypeResponse;

            dto.VehicleTypeId = vehicleType.Id;

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
                        if (response == null) throw new Exception();
                        paymentUrl = new
                        {
                            PayUrl = response.payUrl,
                            Deeplink = response.deeplink,
                            DeeplinkMiniApp = response.deeplinkMiniApp
                        };
                        break;
                    case Payments.PaymentMethods.COD:
                        booking.Status = Bookings.Status.PendingMapping;
                        if (!_unitOfWork.Bookings.Update(booking).Result) throw new Exception();
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

            //if(booking.PaymentMethod == Payments.PaymentMethods.COD) await _redisMQService.Publish(MappingBookingTask.BOOKING_QUEUE, booking.Id);

            var bookingViewModel =
                await _unitOfWork.Bookings
                    .List(_booking => _booking.Id == booking.Id)
                    .MapTo<BookerBookingViewModel>(_mapper)
                    .FirstOrDefaultAsync();

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
                var prevBookingDetailEndTime = prevBookingDetail.Booking.Time.AddMinutes(prevBookingDetail.Booking.Duration / 60);
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
        private bool IsSatisfiedSharingTripInRouteRoutineOrderCondition(BookingDetail mappedBookingDetail, BookingDetail bookingDetail, Dictionary<Guid, RouteStation> routeStationDic)
        {
            var curBookingDetailStartTime = bookingDetail.Booking.Time;
            var curBookingDetailEndTime = bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration / 60);

            var curStartStation = routeStationDic[bookingDetail.Booking.StartStationCode];
            var curEndStation = routeStationDic[bookingDetail.Booking.EndStationCode];

            if(mappedBookingDetail.Booking.Time <= bookingDetail.Booking.Time)
            {
                var mappedEndStation = routeStationDic[mappedBookingDetail.Booking.EndStationCode];
                var mappedBookingDetailEndTime = mappedBookingDetail.Booking.Time.AddMinutes(mappedBookingDetail.Booking.Duration / 60);
                var timeArriveMappedEndStationFromCurStartStation = curBookingDetailStartTime.AddMinutes((mappedEndStation.DurationFromFirstStationInRoute - curStartStation.DurationFromFirstStationInRoute) / 60);

                return Math.Abs((mappedBookingDetailEndTime - timeArriveMappedEndStationFromCurStartStation).TotalMinutes) <= 5;
            }
            else
            {
                var mappedStartStation = routeStationDic[mappedBookingDetail.Booking.StartStationCode];
                var mappedBookingDetailStartTime = mappedBookingDetail.Booking.Time;
                var timeArriveCurEndStationFromMappedStartStation = mappedBookingDetailStartTime.AddMinutes((curEndStation.DurationFromFirstStationInRoute - mappedStartStation.DurationFromFirstStationInRoute) / 60);

                return Math.Abs((timeArriveCurEndStationFromMappedStartStation - curBookingDetailEndTime).TotalMinutes) <= 5;
            }
        }
        private bool IsSatisfiedTimeCondition(TimeOnly? prevEndTime, TimeOnly? nextStartTime, TimeOnly curStartTime, TimeOnly curEndTime)
        {
            return (prevEndTime == null || prevEndTime < curStartTime) &&  (nextStartTime == null || nextStartTime > curEndTime);
        }
        private bool IsSatisfiedSlotCondition(List<BookingDetail> mappedBookingDetails, BookingDetail bookingDetail)
        {
            var slot = bookingDetail.Booking.VehicleType.Slot - 1;
            foreach(var mappedBookingDetail in mappedBookingDetails)
            {
                var mappedBookingDetailStartTime = mappedBookingDetail.Booking.Time;
                var mappedBookingDetailEndtime = mappedBookingDetail.Booking.Time.AddMinutes(mappedBookingDetail.Booking.Duration / 60);

                var totalSharingBookingDetail = 
                    mappedBookingDetails
                    .Where(_mappedBookingDetail => 
                        _mappedBookingDetail.Id != mappedBookingDetail.Id &&
                        !(_mappedBookingDetail.Booking.Time >= mappedBookingDetailEndtime ||
                          _mappedBookingDetail.Booking.Time.AddMinutes(_mappedBookingDetail.Booking.Duration / 60) <= mappedBookingDetailStartTime))
                    .Count();
                if (totalSharingBookingDetail >= slot) return false;
            }
            return true;
        }
        private bool IsPossibleMappingWithRouteRoutine(List<BookingDetail> mappedBookingDetails, BookingDetail bookingDetail, Dictionary<Guid, RouteStation> routeStationDic)
        {
            var isShared = bookingDetail.Booking.IsShared;

            var curStartTime = bookingDetail.Booking.Time;
            var curEndTime = bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration / 60);

            if (isShared)
            {
                var possibleSharingBookingDetails =
                    mappedBookingDetails
                    .Where(bookingDetailMapped => 
                        !(curStartTime >= bookingDetailMapped.Booking.Time.AddMinutes(bookingDetailMapped.Booking.Duration/60) || 
                          curEndTime <= bookingDetailMapped.Booking.Time))
                    .OrderBy(bookingDetailMapped => bookingDetailMapped.Booking.Time)
                    .ToList();

                var deniedSharingBookingDetails =
                    possibleSharingBookingDetails
                    .Where(bookingDetailMapped => !bookingDetailMapped.Booking.IsShared)
                    .ToList();

                if (!deniedSharingBookingDetails.Any() && possibleSharingBookingDetails.Any())
                {
                    //check is satisfied position
                    if(IsSatisfiedSharingTripInRouteRoutineOrderCondition(possibleSharingBookingDetails.First(), bookingDetail, routeStationDic))
                    {
                        //check is satisfied slots
                        if (IsSatisfiedSlotCondition(possibleSharingBookingDetails, bookingDetail)) return true;
                    }
                } 
            }

            BookingDetail? prevBookingDetail = null;
            for(var index = 0; index <= mappedBookingDetails.Count; index++)
            {
                BookingDetail? nextBookingDetail = index < mappedBookingDetails.Count ? mappedBookingDetails[index] : null;

                TimeOnly? prevEndTime = prevBookingDetail?.Booking.Time.AddMinutes(prevBookingDetail.Booking.Duration / 60);
                TimeOnly? nextStartTime = nextBookingDetail?.Booking.Time;

                if (IsSatisfiedTimeCondition(prevEndTime, nextStartTime, curStartTime, curEndTime) &&
                    IsSatisfiedTripInRouteRoutineOrderCondition(prevBookingDetail, nextBookingDetail, bookingDetail, routeStationDic)){
                    return true;
                }
            }
            return false;
        }
        private bool IsSatisfiedRouteRoutineCondition(RouteRoutine routeRoutine, BookingDetail bookingDetail)
        {
            //if (bookingDetail.Date < routeRoutine.StartAt || bookingDetail.Date > routeRoutine.EndAt) return false;

            var bookingStartTime = bookingDetail.Booking.Time;
            var bookingEndTime = bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration/60);

            var routeStationDic = bookingDetail.Booking.Route.RouteStations.ToDictionary(e => e.Station.Code);

            var bookingDetailMappedsInRouteRoutine = 
                routeRoutine.User.BookingDetailDrivers
                .Where(bdr =>
                    bdr.BookingDetail.Date == bookingDetail.Date &&
                    bdr.BookingDetail.Booking.Time >= routeRoutine.StartTime &&
                    bdr.BookingDetail.Booking.Time <= routeRoutine.EndTime &&
                    bdr.Status == BookingDetailDrivers.Status.Pending)
                .OrderBy(bdr => bdr.BookingDetail.Booking.Time)
                .ToList()
                .Select(bdr => bdr.BookingDetail).ToList();

            return IsPossibleMappingWithRouteRoutine(bookingDetailMappedsInRouteRoutine, bookingDetail, routeStationDic);
        }
        public async Task<Booking?> Mapping(int bookingId)
        {
            var startTime = DateTimeOffset.UtcNow;
            var booking =
                await _unitOfWork.Bookings
                .List(e => e.Id == bookingId && e.Status == Bookings.Status.PendingMapping)
                .Include(e => e.User)
                .Include(e => e.BookingDetails)
                .ThenInclude(bd => bd.BookingDetailDrivers)
                .Include(e => e.VehicleType)
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
                                      (routeRoutine.StartTime <= booking.Time && routeRoutine.EndTime > booking.Time) &&
                                      routeRoutine.RouteId == booking.RouteId && routeRoutine.User.Vehicle.VehicleTypeId == booking.VehicleTypeId)
                .Include(e => e.User)
                .ThenInclude(u => u.BookingDetailDrivers)
                .ThenInclude(bdr => bdr.BookingDetail)
                .ThenInclude(bd => bd.Booking)
                .ToListAsync();

            foreach(var bookingDetail in bookingDetails)
            {
                //order by total number of mapped booking with driver in detail booking datetime
                var orderedRouteRoutines = routeRoutines
                    .OrderBy(routeRoutine =>
                        routeRoutine.User.BookingDetailDrivers
                        .Count(bdr =>
                                bdr.BookingDetail.Date == bookingDetail.Date &&
                                bdr.BookingDetail.Booking.Time >= routeRoutine.StartTime &&
                                bdr.BookingDetail.Booking.Time <= routeRoutine.EndTime &&
                                bdr.Status == BookingDetailDrivers.Status.Pending));

                //then order by driver point

                foreach (var routeRoutine in orderedRouteRoutines)
                {
                    if (IsSatisfiedRouteRoutineCondition(routeRoutine, bookingDetail))
                    {

                        bookingDetail.Status = BookingDetails.Status.Ready;
                        bookingDetail.BookingDetailDrivers.Add(
                            new BookingDetailDriver
                        {
                            BookingDetailId = bookingDetail.Id,
                            DriverId = routeRoutine.User.Id,
                        });
                        break;
                    }
                }
            }

            var endTime = DateTimeOffset.UtcNow;

            Console.WriteLine($"BookingId: {booking.Id} | Status: {bookingDetailDrivers.Any()} / {bookingDetailDrivers.Count} / {booking.BookingDetails.Count} | EndTime: {endTime} | Time: {endTime.Subtract(startTime).TotalMinutes} mins");

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

        public async Task<Response> GetProvision(BookingDTO dto, Response successResponse, Response invalidStationResponse,Response invalidRouteResponse, Response invalidVehicleTypeResponse, Response invalidPromotionResponse)
        {
            var pairOfStation = await _stationService.GetPairOfStation(dto.StartStationCode, dto.EndStationCode);

            if (pairOfStation.Item1 == null || pairOfStation.Item2 == null) return invalidStationResponse;

            VehicleType? vehicleType = await _vehicleTypeService.GetByCode(dto.VehicleTypeCode);

            if (vehicleType == null) return invalidVehicleTypeResponse;

            dto.VehicleTypeId = vehicleType.Id;

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
