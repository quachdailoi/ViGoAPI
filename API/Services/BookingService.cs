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
                .List(route => route.Code == dto.RouteCode && route.Status == Routes.Status.Active)
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
                var fee = await AppServices.Fare.CaculateBookingFee(dto.Type, dto.VehicleTypeId, dto.StartAt, dto.EndAt, booking.Distance, dto.Time);
                booking.TotalPrice = fee.TotalFee;

                // generate booking detail by booking schedule
                booking.BookingDetails = AppServices.BookingDetail.GenerateBookingDetail(booking,fee.FeePerTrip);

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

        public async Task<bool> CheckIsConflictBooking(Booking booking)
        {
            var duplicateBookings =
                await UnitOfWork.Bookings
                .List(e =>
                    (e.Status == Bookings.Status.PendingMapping ||
                    e.Status == Bookings.Status.Started) &&
                    !(e.Time.AddMinutes(e.Duration / 60) < booking.Time ||
                    e.Time > booking.Time.AddMinutes(booking.Duration / 60)) &&
                    e.UserId == booking.UserId &&
                    !(e.StartAt > booking.EndAt || e.EndAt < booking.StartAt))
                .Include(e => e.BookingDetails)
                .ToListAsync();
            return duplicateBookings.Any();
        }

        public async Task<Response> Create(
            BookingDTO dto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response invalidStationResponse, Response invalidVehicleTypeResponse,
            Response invalidRouteResponse, Response duplicationResponse, Response invalidPromotionResponse, Response notAvailableResponse, Response insufficientBalanceResponse, Response errorResponse)
        {
            var pairOfStation = await AppServices.Station.GetPairOfStation(dto.StartStationCode, dto.EndStationCode);

            if (pairOfStation.Item1 == null || pairOfStation.Item2 == null) return invalidStationResponse;

            VehicleType? vehicleType = await AppServices.VehicleType.GetByCode(dto.VehicleTypeCode);

            if (vehicleType == null) return invalidVehicleTypeResponse;

            dto.VehicleTypeId = vehicleType.Id;

            var booking = await GenerateBooking(dto);

            if (booking.BookingDetails.Count == 0) return invalidRouteResponse;
            if (!booking.PromotionId.HasValue && !String.IsNullOrEmpty(dto.PromotionCode)) return invalidPromotionResponse; 

            if (CheckIsConflictBooking(booking).Result) return duplicationResponse;

            // check for exist available driver for this trip 

            await UnitOfWork.CreateTransactionAsync();

            booking = await UnitOfWork.Bookings.Add(booking);

            if (booking == null) return errorResponse;

            //booking = await Mapping(booking.Id);

            //if (!booking.BookingDetails.Any(bd => bd.BookingDetailDrivers.Any())) return notAvailableResponse;

            //if (!AppServices.RouteRoutine.GetRouteRoutineFitBookingCondition(booking).Result.Any()) return notAvailableResponse;

            string paymentUrl = String.Empty;

            try
            {
                switch (booking.PaymentMethod)
                {
                    case Payments.PaymentMethods.Momo:
                        ((MomoCollectionLinkRequestDTO)paymentDto).amount = (long)booking.TotalPrice;
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderId = booking.Code.ToString();
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderInfo = "Pay for ViGo booking";

                        var response = await AppServices.Payment.GenerateMomoPaymentUrl((MomoCollectionLinkRequestDTO)paymentDto);
                        if (response == null) throw new Exception("Fail to generate momo url.");

                        paymentUrl = response.deeplink;
                        break;
                    case Payments.PaymentMethods.Wallet:
                        var wallet = await AppServices.Wallet.GetWallet(booking.UserId);
                        
                        if (wallet == null) throw new Exception("Wallet is not exist.");
                        if (wallet.Balance < booking.TotalPrice) throw new Exception("Insufficient balance.");
                        
                        wallet = await AppServices.Wallet.UpdateBalance(new WalletTransactionDTO
                        {
                            Amount = -(long)booking.TotalPrice,
                            TxnId = booking.Id.ToString(),
                            Status = WalletTransactions.Status.Success,
                            WalletId = wallet.Id,
                            Type = WalletTransactions.Types.BookingPaid
                        });

                        if (wallet == null) throw new Exception("Fail to pay by wallet.");

                        await AppServices.RedisMQ.Publish(MappingBookingTask.BOOKING_QUEUE, booking.Id);

                        break;
                    case Payments.PaymentMethods.COD:
                        booking.Status = Bookings.Status.PendingMapping;

                        if (!UnitOfWork.Bookings.Update(booking).Result) throw new Exception("Fail to update booking status.");

                        await AppServices.RedisMQ.Publish(MappingBookingTask.BOOKING_QUEUE, booking.Id);
                        break;
                    default: break;
                }
            }
            catch(Exception ex)
            {
                await UnitOfWork.Rollback();
                if (ex.Message.Contains("Insufficient balance.")) return insufficientBalanceResponse;
                return errorResponse.SetMessage(ex.Message);
            }
            
            await UnitOfWork.CommitAsync();

            var bookingViewModel =
                await UnitOfWork.Bookings
                    .List(_booking => _booking.Id == booking.Id)
                    .MapTo<BookerBookingViewModel>(Mapper)
                    .FirstOrDefaultAsync();

            return successResponse.SetData(new 
            { 
                Booking = bookingViewModel.ProcessStationOrder(),
                PaymentUrl = paymentUrl
            } 
            );
        }


        private bool IsSatisfiedPositionCondition(BookingDetail mappedBookingDetail, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            var curBookingStartTime = bookingDetail.Booking.Time;
            var curBookingStartStation = routeStationDic[bookingDetail.Booking.StartRouteStationId];

            var mappedBookingStartTime = mappedBookingDetail.Booking.Time;
            var mappedBookingStartStation = routeStationDic[mappedBookingDetail.Booking.StartRouteStationId];

            var timeArriveCurBookingStartStation = mappedBookingStartTime.AddMinutes((curBookingStartStation.DurationFromFirstStationInRoute - mappedBookingStartStation.DurationFromFirstStationInRoute) / 60);

            return (timeArriveCurBookingStartStation - curBookingStartTime).TotalMinutes == 0; 
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
        private bool IsPossibleMappingWithRouteRoutineWithShare(List<BookingDetail> mappedBookingDetails, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            var curStartTime = bookingDetail.Booking.Time;
            var curEndTime = bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration / 60);

            var possibleSharingBookingDetails =
                    mappedBookingDetails
                    .Where(bookingDetailMapped =>
                        !(curStartTime >= bookingDetailMapped.Booking.Time.AddMinutes(bookingDetailMapped.Booking.Duration / 60) ||
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
                if (IsSatisfiedPositionCondition(possibleSharingBookingDetails.First(), bookingDetail, routeStationDic))
                {
                    //check is satisfied slots
                    if (IsSatisfiedSlotCondition(possibleSharingBookingDetails, bookingDetail)) return true;
                }
            }

            return false;
        }
        private bool IsPossibleMappingWithRouteRoutineWithoutShare(List<BookingDetail> mappedBookingDetails, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            if (!mappedBookingDetails.Any()) return true;

            var isShared = bookingDetail.Booking.IsShared;

            var curStartTime = bookingDetail.Booking.Time;
            var curEndTime = bookingDetail.Booking.Time.AddMinutes(bookingDetail.Booking.Duration / 60);


            var mappedBookingDetailConflictWithBookingDetailTimes = mappedBookingDetails
                .Where(mappedBookingDetail =>
                    !(mappedBookingDetail.Booking.Time >= curEndTime ||
                    mappedBookingDetail.Booking.Time.AddMinutes(mappedBookingDetail.Booking.Duration / 60) <= curStartTime))
                .ToList();

            if (!mappedBookingDetailConflictWithBookingDetailTimes.Any())
            {
                if(IsSatisfiedPositionCondition(mappedBookingDetails.First(),bookingDetail,routeStationDic)) return true;
            }
            return false;
        }
        public async Task<Booking?> Mapping(int bookingId)
        {
            var startTime = DateTimeOffset.UtcNow;
            var booking =
                await UnitOfWork.Bookings
                .List(e => e.Id == bookingId && e.Status == Bookings.Status.PendingMapping)
                .Include(e => e.User)
                .Include(e => e.BookingDetails)
                .ThenInclude(bd => bd.BookingDetailDrivers)
                .Include(e => e.VehicleType)
                .Include(e => e.StartRouteStation)
                .ThenInclude(srs => srs.Station)
                .Include(e => e.EndRouteStation)
                .ThenInclude(ers => ers.Station)
                .FirstOrDefaultAsync();

            if (booking == null) return null;

            var bookingDetails = booking.BookingDetails;
            var bookingDetailDrivers = new List<BookingDetailDriver>();

            var route =
                await UnitOfWork.Routes
                .List(e => e.Id == booking.StartRouteStation.RouteId && e.Status == Routes.Status.Active)
                .Include(e => e.RouteStations)
                .ThenInclude(rs => rs.Station)
                .FirstOrDefaultAsync();

            if(route == null) return null;

            var routeStationDic = route.RouteStations.ToDictionary(e => e.Id);

            var routeRoutines = 
                await UnitOfWork.RouteRoutines
                .List(routeRoutine => !(routeRoutine.StartAt > booking.EndAt || routeRoutine.EndAt < booking.StartAt) &&
                                      (routeRoutine.StartTime <= booking.Time && routeRoutine.EndTime > booking.Time) &&
                                      routeRoutine.RouteId == route.Id && routeRoutine.User.Vehicle.VehicleTypeId == booking.VehicleTypeId)
                .Include(e => e.User)
                .ThenInclude(u => u.BookingDetailDrivers)
                .ThenInclude(bdr => bdr.BookingDetail)
                .ThenInclude(bd => bd.Booking)
                .ToListAsync();

            foreach (var bookingDetail in bookingDetails)
            {
                //order by total number of mapped booking with driver in detail booking datetime
                var orderedRouteRoutines = routeRoutines
                    .OrderBy(routeRoutine =>
                        routeRoutine.User.BookingDetailDrivers
                        .Count(bdr =>
                                bdr.BookingDetail.Date == bookingDetail.Date &&
                                bdr.BookingDetail.Booking.Time >= routeRoutine.StartTime &&
                                bdr.BookingDetail.Booking.Time <= routeRoutine.EndTime &&
                                bdr.Status == BookingDetailDrivers.Status.Pending))
                    .ToList();

                //then order by driver point

                var mappedBookingDetailsDic = new Dictionary<int, List<BookingDetail>>();

                if (booking.IsShared)
                {
                    RouteRoutine fitRouteRoutine = null;

                    foreach (var routeRoutine in orderedRouteRoutines)
                    {
                        if (!mappedBookingDetailsDic.ContainsKey(routeRoutine.Id))
                        {
                            mappedBookingDetailsDic[routeRoutine.Id] =
                            routeRoutine.User.BookingDetailDrivers
                            .Where(bdr =>
                                bdr.BookingDetail.Date == bookingDetail.Date &&
                                bdr.BookingDetail.Booking.Time >= routeRoutine.StartTime &&
                                bdr.BookingDetail.Booking.Time < routeRoutine.EndTime &&
                                bdr.Status == BookingDetailDrivers.Status.Pending)
                            .OrderBy(bdr => bdr.BookingDetail.Booking.Time)
                            .ToList()
                            .Select(bdr => bdr.BookingDetail)
                            .ToList();
                        }

                        if (IsPossibleMappingWithRouteRoutineWithShare(mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic)) 
                        {
                            fitRouteRoutine = routeRoutine;
                            break;
                        } 
                    }

                    if(fitRouteRoutine == null)
                    {
                        foreach(var routeRoutine in orderedRouteRoutines)
                        {
                            if(IsPossibleMappingWithRouteRoutineWithoutShare(mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic))
                            {
                                fitRouteRoutine = routeRoutine;
                                break;
                            }
                        }
                    }

                    if(fitRouteRoutine != null)
                    {
                        bookingDetail.Status = BookingDetails.Status.Ready;
                        bookingDetail.BookingDetailDrivers.Add(
                            new BookingDetailDriver
                            {
                                BookingDetailId = bookingDetail.Id,
                                DriverId = fitRouteRoutine.User.Id,
                            });
                    }

                }
                else
                {
                    foreach (var routeRoutine in orderedRouteRoutines)
                    {
                        if (!mappedBookingDetailsDic.ContainsKey(routeRoutine.Id))
                        {
                            mappedBookingDetailsDic[routeRoutine.Id] =
                            routeRoutine.User.BookingDetailDrivers
                            .Where(bdr =>
                                bdr.BookingDetail.Date == bookingDetail.Date &&
                                bdr.BookingDetail.Booking.Time >= routeRoutine.StartTime &&
                                bdr.BookingDetail.Booking.Time < routeRoutine.EndTime &&
                                bdr.Status == BookingDetailDrivers.Status.Pending)
                            .OrderBy(bdr => bdr.BookingDetail.Booking.Time)
                            .ToList()
                            .Select(bdr => bdr.BookingDetail)
                            .ToList();
                        }

                        if (IsPossibleMappingWithRouteRoutineWithoutShare(mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic))
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
            }

            var endTime = DateTimeOffset.UtcNow;

            Console.WriteLine($"BookingId: {booking.Id} | Status: {bookingDetailDrivers.Any()} / {bookingDetailDrivers.Count} / {booking.BookingDetails.Count} | EndTime: {endTime} | Time: {endTime.Subtract(startTime).TotalMinutes} mins");

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

        public async Task<Response> GetProvision(BookingDTO dto, Response successResponse, Response invalidStationResponse,Response invalidRouteResponse, Response invalidVehicleTypeResponse, Response invalidPromotionResponse)
        {
            var pairOfStation = await AppServices.Station.GetPairOfStation(dto.StartStationCode, dto.EndStationCode);

            if (pairOfStation.Item1 == null || pairOfStation.Item2 == null) return invalidStationResponse;

            VehicleType? vehicleType = await AppServices.VehicleType.GetByCode(dto.VehicleTypeCode);

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
        public Task<Booking?> GetByCode(Guid code) => UnitOfWork.Bookings.List(booking => booking.Code == code).FirstOrDefaultAsync();
        public Task<bool> Update(Booking booking) => UnitOfWork.Bookings.Update(booking);
    }
}
