using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
using API.Models.Response;
using API.Services.Constract;
using API.SignalR;
using API.TaskQueues;
using API.TaskQueues.TaskResolver;
using API.Utils;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using System.Runtime.InteropServices;

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
                   (routeStation.Station.Code == dto.StartStationCode ||
                    routeStation.Station.Code == dto.EndStationCode) &&
                    routeStation.Route.Code == dto.RouteCode)
                .Include(routeStation => routeStation.Station)
                .ToListAsync();

            var route = await UnitOfWork.Routes
                .List(route => route.Code == dto.RouteCode && route.Status == Routes.Status.Active)
                .FirstOrDefaultAsync();

            if (route != null && routeStations.GroupBy(e => e.StationId).Count() == 2)
            {
                //booking.StartRouteStation.RouteId = route.Id;

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
                var fee = await AppServices.Fare.CaculateBookingFee(dto.VehicleTypeId, dto.StartAt, dto.EndAt, dto.DayOfWeeks, booking.Distance, dto.Time);
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
            var bookings = await UnitOfWork.Bookings
                .List(e =>
                    (e.Status == Bookings.Status.PendingMapping ||
                    e.Status == Bookings.Status.Started) &&
                    !(e.Time.AddMinutes(e.Duration / 60) < booking.Time ||
                    e.Time > booking.Time.AddMinutes(booking.Duration / 60)) &&
                    e.UserId == booking.UserId &&
                    !(e.StartAt > booking.EndAt || e.EndAt < booking.StartAt))
                .Include(e => e.BookingDetails)
                .ToListAsync();

            //// filter in server
            if (bookings.Any())
            {
                var bookingDetailDateHashSet =
                    bookings
                    .Select(b => b.BookingDetails.Select(_b => _b.Date))
                    .Aggregate((current, next) => current.Union(next))
                    .ToHashSet();

                var insertedBookingDetailDateHashSet =
                    booking.BookingDetails.Select(b => b.Date).ToHashSet();

                insertedBookingDetailDateHashSet.IntersectWith(bookingDetailDateHashSet);

                if (insertedBookingDetailDateHashSet.Any())
                    return true;
            }

            return false;
        }

        public async Task<Response> Create(
            BookingDTO dto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response invalidStationResponse, Response invalidVehicleTypeResponse,
            Response invalidRouteResponse, Response duplicationResponse, Response invalidPromotionResponse, Response notAvailableResponse, Response insufficientBalanceResponse, Response errorResponse, bool isDummy = false)
        {
            var pairOfStation = await AppServices.Station.GetPairOfStation(dto.StartStationCode, dto.EndStationCode);

            if (pairOfStation.Item1 == null || pairOfStation.Item2 == null) return invalidStationResponse;

            VehicleType? vehicleType = await AppServices.VehicleType.GetByCode(dto.VehicleTypeCode);

            if (vehicleType == null) return invalidVehicleTypeResponse;

            if (dto.IsShared && vehicleType.Type == VehicleTypes.Type.ViRide) 
                return invalidVehicleTypeResponse.SetMessage("This vehicle type can not be applied sharing condition.");

            dto.VehicleTypeId = vehicleType.Id;

            var booking = await GenerateBooking(dto);

            if (booking.BookingDetails.Count == 0) return invalidRouteResponse;
            if (!booking.PromotionId.HasValue && !String.IsNullOrEmpty(dto.PromotionCode)) return invalidPromotionResponse; 

            if (CheckIsConflictBooking(booking).Result) return duplicationResponse;

            // check for exist available driver for this trip

            if (isDummy && !AppServices.RouteRoutine.GetRouteRoutineFitBookingCondition(booking).Result.Any()) return notAvailableResponse;
 

            await UnitOfWork.CreateTransactionAsync();

            dynamic responseData = new ExpandoObject();

            try
            {
                booking = await UnitOfWork.Bookings.Add(booking);

                if (booking == null) throw new Exception("Fail to create booking.");

                var wallet = await AppServices.Wallet.GetWallet(booking.UserId);
                if (wallet == null) throw new Exception("Wallet is not exist.");

                var walletTransaction = new WalletTransaction
                {
                    Amount = booking.TotalPrice,
                    Status = WalletTransactions.Status.Pending,
                    WalletId = wallet.Id,
                    BookingId = booking.Id
                };

                booking.WalletTransactions.Add(walletTransaction);

                //var walletTransactionDto = Mapper.Map<WalletTransactionDTO>(walletTransaction);

                switch (booking.PaymentMethod)
                {
                    case Payments.PaymentMethods.Momo:
                        walletTransaction.Type = WalletTransactions.Types.BookingPaidByMomo;

                        ((MomoCollectionLinkRequestDTO)paymentDto).amount = (long)booking.TotalPrice;
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderId = booking.Code.ToString();
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderInfo = $"Vigo - Pay Booking # {booking.Code}";
                        ((MomoCollectionLinkRequestDTO)paymentDto).extraData = Encryption.EncodeBase64(Mapper.Map<WalletTransactionDTO>(walletTransaction));

                        var momoResponse = await AppServices.Payment.GenerateMomoPaymentUrl((MomoCollectionLinkRequestDTO)paymentDto);
                        if (momoResponse == null) throw new Exception("Fail to generate momo url.");

                        responseData.PaymentUrl = momoResponse.deeplink;
                        responseData.WebUrl = momoResponse.payUrl;

                        break;
                    case Payments.PaymentMethods.ZaloPay:

                        walletTransaction.Type = WalletTransactions.Types.BookingPaidByZaloPay;

                        var rawItem = Mapper.Map<PaymentBookingViewModel>(booking);
                        rawItem.WalletTransaction = Mapper.Map<WalletTransactionDTO>(walletTransaction);

                        ((ZaloCollectionLinkRequestDTO)paymentDto).amount = (long)booking.TotalPrice;
                        ((ZaloCollectionLinkRequestDTO)paymentDto).raw_item = new List<object>{rawItem};
                        ((ZaloCollectionLinkRequestDTO)paymentDto).description = $"Vigo - Pay Booking # {((ZaloCollectionLinkRequestDTO)paymentDto).app_trans_id}";

                        var zaloPayResponse = await AppServices.Payment.GenerateZaloPaymentUrl((ZaloCollectionLinkRequestDTO)paymentDto);
                        if (zaloPayResponse == null) throw new Exception("Fail to generate zalopay url.");

                        responseData.PaymentUrl = zaloPayResponse.order_url;
                        responseData.ZpTransToken = zaloPayResponse.zp_trans_token;

                        break;
                    case Payments.PaymentMethods.Wallet:
                        if (wallet.Balance < booking.TotalPrice) throw new Exception("Insufficient balance.");

                        walletTransaction.Type = WalletTransactions.Types.BookingPaid;
                        walletTransaction.Status = WalletTransactions.Status.Success;

                        wallet = await AppServices.Wallet.UpdateBalance(booking.UserId, -booking.TotalPrice);

                        if (wallet == null) throw new Exception("Fail to pay by wallet.");

                        booking.Status = Bookings.Status.PendingMapping;

                        if (!UnitOfWork.Bookings.Update(booking).Result) throw new Exception("Fail to update booking status."); 

                        break;
                    case Payments.PaymentMethods.COD:
                        booking.Status = Bookings.Status.PendingMapping;
                        break;
                    default: break;
                }

                if (!UnitOfWork.Bookings.Update(booking).Result) throw new Exception("Fail to create booking.");
            }
            catch(Exception ex)
            {
                await UnitOfWork.Rollback();
                if (ex.Message.Contains("Insufficient balance.")) return insufficientBalanceResponse;
                if (ex.Message.Contains("Fail to create booking.")) return errorResponse;
                return errorResponse.SetMessage(ex.Message);
            }
            
            await UnitOfWork.CommitAsync();

            switch (booking.PaymentMethod)
            {
                case Payments.PaymentMethods.COD:
                case Payments.PaymentMethods.Wallet:
                    await AppServices.RedisMQ.Publish(MappingBookingTask.MAPPING_QUEUE, new MappingItemDTO { Id = booking.Id, Type = TaskItems.MappingItemTypes.Booking });
                    break;
            }

            responseData.Booking =
                await UnitOfWork.Bookings
                    .List(_booking => _booking.Id == booking.Id)
                    .MapTo<BookerBookingViewModel>(Mapper)
                    .FirstOrDefaultAsync();

            return successResponse.SetData(responseData);
        }


        private bool IsSatisfiedTimeCondition(TimeOnly routeRoutineStartTime, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            var curBookingStartStation = routeStationDic[bookingDetail.Booking.StartRouteStationId];
            var timeArriveCurBookingStartStation = routeRoutineStartTime.AddMinutes(curBookingStartStation.DurationFromFirstStationInRoute / 60);

            var allowedMappingTimeRange = double.Parse(AppServices.Setting.GetValue(Settings.AllowedMappingTimeRange).Result ?? "3");

            return timeArriveCurBookingStartStation.ToTimeSpan(bookingDetail.Booking.Time).TotalMinutes <= allowedMappingTimeRange;
        }

        private bool IsSatisfiedSlotCondition(List<BookingDetail> mappedBookingDetails, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            var slot = bookingDetail.Booking.VehicleType.Slot;

            foreach(var mappedBookingDetail in mappedBookingDetails)
            {
                var mappedStartStation = routeStationDic[mappedBookingDetail.Booking.StartRouteStationId];
                var mappedEndStation = routeStationDic[mappedBookingDetail.Booking.EndRouteStationId];

                var totalSharingBookingDetail = 
                    mappedBookingDetails
                    .Where(_mappedBookingDetail => 
                        _mappedBookingDetail.Id == mappedBookingDetail.Id ||
                        !(routeStationDic[_mappedBookingDetail.Booking.StartRouteStationId].DistanceFromFirstStationInRoute >= mappedEndStation.DistanceFromFirstStationInRoute ||
                          routeStationDic[_mappedBookingDetail.Booking.EndRouteStationId].DistanceFromFirstStationInRoute <= mappedStartStation.DistanceFromFirstStationInRoute))
                    .Count() + 1;

                if (totalSharingBookingDetail >= slot) return false;
            }
            return true;
        }

        

        private bool IsPossibleMappingWithRouteRoutineWithShare(TimeOnly routeRoutineStartTime,List<BookingDetail> mappedBookingDetails, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            var possibleSharingBookingDetails = AppServices.BookingDetail.PossibleSharingBookingDetails(mappedBookingDetails, bookingDetail, routeStationDic);

            var deniedSharingBookingDetails =
                possibleSharingBookingDetails
                .Where(mappedBookingDetail => !mappedBookingDetail.Booking.IsShared)
                .ToList();

            return (!deniedSharingBookingDetails.Any() && possibleSharingBookingDetails.Any() &&
                    //check is satisfied position
                    IsSatisfiedTimeCondition(routeRoutineStartTime, bookingDetail, routeStationDic) &&
                    //check is satisfied slots
                    IsSatisfiedSlotCondition(possibleSharingBookingDetails, bookingDetail, routeStationDic));
        }
        private bool IsPossibleMappingWithRouteRoutineWithoutShare(TimeOnly routeRoutineStartTime, List<BookingDetail> mappedBookingDetails, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            var mappedBookingDetailConflictWithBookingDetail = AppServices.BookingDetail.PossibleSharingBookingDetails(mappedBookingDetails, bookingDetail, routeStationDic);

            return (!mappedBookingDetailConflictWithBookingDetail.Any() &&
                    IsSatisfiedTimeCondition(routeRoutineStartTime, bookingDetail, routeStationDic));
        }
        private async Task MapBookingDetailWithRouteRoutine(BookingDetail bookingDetail, RouteRoutine routeRoutine, Dictionary<Guid,Room> driverUserMessageRoomDic)
        {
            bookingDetail.Status = BookingDetails.Status.Ready;
            bookingDetail.BookingDetailDrivers.Add(
                new BookingDetailDriver
                {
                    BookingDetailId = bookingDetail.Id,
                    RouteRoutineId = routeRoutine.Id,
                });

            if (!driverUserMessageRoomDic.TryGetValue(routeRoutine.User.Code, out var room))
            {
                room = await AppServices.Room.GetByMemberCode(new List<Guid> { routeRoutine.User.Code, bookingDetail.Booking.User.Code });

                if (room == null)
                {
                    room = await AppServices.Room.Create(new List<Guid> { routeRoutine.User.Code, bookingDetail.Booking.User.Code }, Rooms.RoomTypes.Conversation);
                    driverUserMessageRoomDic[routeRoutine.User.Code] = room;
                }
                else
                {
                    room.Status = Rooms.Status.Active;

                    foreach (var userRoom in room.UserRooms)
                    {
                        userRoom.Status = Rooms.UserRoomStatus.Active;
                    }

                    driverUserMessageRoomDic[routeRoutine.User.Code] = room;

                    bookingDetail.MessageRoomId = room.Id;
                    //bookingDetail.MessageRoom = room;

                    return;
                }
            }

            bookingDetail.MessageRoomId = room.Id;
        }

        public async Task<Booking?> MappingBooking(int bookingId)
        {
            var startTime = DateTimeOffset.UtcNow;

            var booking =
                await UnitOfWork.Bookings
                .List(e => e.Id == bookingId && e.Status == Bookings.Status.PendingMapping)
                .Include(e => e.User)
                .Include(e => e.BookingDetails)
                .ThenInclude(bd => bd.MessageRoom)
                .Include(e => e.BookingDetails)
                .ThenInclude(bd => bd.BookingDetailDrivers)
                .Include(e => e.VehicleType)
                .Include(e => e.StartRouteStation)
                .FirstOrDefaultAsync();

            if (booking == null) 
                return null;

            var routeStationDic =
                (await UnitOfWork.Routes
                .List(e => e.Id == booking.StartRouteStation.RouteId && e.Status == Routes.Status.Active)
                .Include(e => e.RouteStations)
                .ThenInclude(rs => rs.Station)
                .FirstOrDefaultAsync())?
                .RouteStations
                .ToDictionary(e => e.Id);

            if (routeStationDic == null) 
                return null;

            var routeRoutines =
                UnitOfWork.RouteRoutines
                .List(routeRoutine => (routeRoutine.StartTime <= booking.Time && routeRoutine.EndTime > booking.Time) &&
                                      routeRoutine.RouteId == booking.StartRouteStation.RouteId && routeRoutine.User.Vehicle.VehicleTypeId == booking.VehicleTypeId);

            var driverUserMessageRoomDic = new Dictionary<Guid, Room>();

            foreach (var bookingDetail in booking.BookingDetails)
            {

                var rawOrderedRouteRoutines =
                    (await routeRoutines
                    .Where(routeRoutine => !(routeRoutine.StartAt > bookingDetail.Date || routeRoutine.EndAt < bookingDetail.Date))
                    .Include(e => e.User)
                    .Include(e => e.BookingDetailDrivers.Where(bdr => 
                                bdr.BookingDetail.Date == bookingDetail.Date &&
                                bdr.TripStatus == BookingDetailDrivers.TripStatus.NotYet))
                    .ThenInclude(bdr => bdr.BookingDetail)
                    .ThenInclude(bd => bd.Booking)
                    .ToListAsync());

                var orderedRouteRoutines = rawOrderedRouteRoutines
                    .OrderBy(routeRoutine => routeRoutine.BookingDetailDrivers.Count)
                    .ThenByDescending(routeRoutine => routeRoutine.User.Rating)
                    .ThenBy(routeRoutine => routeRoutine.User.CancelledTripRate)
                    .ToList();


                var mappedBookingDetailsDic = orderedRouteRoutines.ToDictionary(
                    key => key.Id, 
                    value => value.BookingDetailDrivers
                        .OrderBy(bdr => bdr.BookingDetail.Booking.Time)    
                        .Select(bdr => bdr.BookingDetail)
                        .ToList());

                if (booking.IsShared)
                {
                    RouteRoutine fitRouteRoutine = null;

                    foreach (var routeRoutine in orderedRouteRoutines)
                    {
                        if (IsPossibleMappingWithRouteRoutineWithShare(routeRoutine.StartTime,mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic)) 
                        {
                            fitRouteRoutine = routeRoutine;
                            break;
                        } 
                    }

                    if(fitRouteRoutine == null)
                    {
                        foreach(var routeRoutine in orderedRouteRoutines)
                        {
                            if(IsPossibleMappingWithRouteRoutineWithoutShare(routeRoutine.StartTime,mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic))
                            {
                                fitRouteRoutine = routeRoutine;
                                break;
                            }
                        }
                    }

                    if (fitRouteRoutine != null)
                        await MapBookingDetailWithRouteRoutine(bookingDetail, fitRouteRoutine, driverUserMessageRoomDic);
                }
                else
                {
                    foreach (var routeRoutine in orderedRouteRoutines)
                    {
                        if (IsPossibleMappingWithRouteRoutineWithoutShare(routeRoutine.StartTime,mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic))
                        {
                            await MapBookingDetailWithRouteRoutine(bookingDetail, routeRoutine, driverUserMessageRoomDic);
                            break;
                        }
                    }
                }
            }



            var endTime = DateTimeOffset.UtcNow;

            var mappedBookingDetails = booking.BookingDetails.Where(bd => bd.Status == BookingDetails.Status.Ready).ToList();
            Console.WriteLine($"BookingId: {booking.Id} | Status: {mappedBookingDetails.Any()} / {mappedBookingDetails.Count} / {booking.BookingDetails.Count} | EndTime: {endTime} | Time: {endTime.Subtract(startTime).TotalMilliseconds} ms");

            return booking;
        }

        public async Task<RouteRoutine?> MappingRouteRoutine(int routeRoutineId)
        {
            var routeRoutine =
                await UnitOfWork.RouteRoutines
                .List(e => e.Id == routeRoutineId && e.Status == RouteRoutines.Status.Active)
                .Include(e => e.User)
                .ThenInclude(u => u.Vehicle)
                .ThenInclude(v => v.VehicleType)
                .Include(e => e.BookingDetailDrivers)
                .ThenInclude(bdr => bdr.BookingDetail)
                .ThenInclude(bd => bd.Booking)
                .FirstOrDefaultAsync();

            if (routeRoutine == null)
                //throw new Exception("Not exist booking");
                return null;

            var routeStationDic =
                (await UnitOfWork.Routes
                .List(e => e.Id == routeRoutine.RouteId && e.Status == Routes.Status.Active)
                .Include(e => e.RouteStations)
                .ThenInclude(rs => rs.Station)
                .FirstOrDefaultAsync())?
                .RouteStations
                .ToDictionary(e => e.Id);

            if (routeStationDic == null)
                //throw new Exception("Not exist route station");
                return null;

            var slot = routeRoutine.User.Vehicle.VehicleType.Slot;

            for (var date = routeRoutine.StartAt; date <= routeRoutine.EndAt; date = date.AddDays(1))
            {
                var notMappedBookingDetails =
                    await UnitOfWork.BookingDetails
                    .List(e => e.Status == BookingDetails.Status.Pending &&
                               e.Date == date &&
                               e.Booking.Time < routeRoutine.EndTime && e.Booking.Time >= routeRoutine.StartTime &&
                               e.Booking.Status == Bookings.Status.Started &&
                               e.Booking.VehicleTypeId == routeRoutine.User.Vehicle.VehicleTypeId)
                    .Include(e => e.BookingDetailDrivers)
                    .Include(e => e.Booking)
                    .ThenInclude(b => b.User)
                    .OrderByDescending(e => e.Booking.IsShared)
                    .ThenBy(e => e.Booking.Time)
                    .ToListAsync();

                var filterBookingDetails = notMappedBookingDetails
                    .Where(e => routeRoutine.StartTime.AddMinutes(routeStationDic[e.Booking.StartRouteStationId].DurationFromFirstStationInRoute)
                                                      .ToTimeSpan(e.Booking.Time)
                                                      .TotalMinutes <= Bookings.AllowedMappingTimeRange)
                    .ToList();

                var mappedBookingDetails = routeRoutine.BookingDetailDrivers
                    .Select(bdr => bdr.BookingDetail)
                    .Where(bd => bd.Date == date)
                    .ToList();

                foreach (var bookingDetail in filterBookingDetails)
                {
                    var isShared = bookingDetail.Booking.IsShared;

                    if (isShared && IsPossibleMappingWithRouteRoutineWithShare(routeRoutine.StartTime, mappedBookingDetails, bookingDetail, routeStationDic) || 
                        IsPossibleMappingWithRouteRoutineWithoutShare(routeRoutine.StartTime, mappedBookingDetails, bookingDetail, routeStationDic))
                    {
                        bookingDetail.Status = BookingDetails.Status.Ready;
                        mappedBookingDetails.Add(bookingDetail);
                    }
                        
                }

                var driverUserMessageRoomDic = new Dictionary<Guid, Room>();

                foreach (var bookingDetail in mappedBookingDetails)
                    await MapBookingDetailWithRouteRoutine(bookingDetail, routeRoutine, driverUserMessageRoomDic);
            }

            return routeRoutine;
        }

        private async Task MappingBookingDetail(BookingDetail bookingDetail, List<RouteRoutine> routeRoutines)
        {
            if (!routeRoutines.Any())
                return;

            var routeStationDic =
                (await UnitOfWork.Routes
                .List(e => e.Id == bookingDetail.Booking.StartRouteStation.RouteId && e.Status == Routes.Status.Active)
                .Include(e => e.RouteStations)
                .ThenInclude(rs => rs.Station)
                .FirstAsync())
                .RouteStations
                .ToDictionary(e => e.Id);

            var mappedBookingDetailsDic = routeRoutines.ToDictionary(
                key => key.Id,
                value => value.BookingDetailDrivers
                    .OrderBy(bdr => bdr.BookingDetail.Booking.Time)
                    .Select(bdr => bdr.BookingDetail)
                    .ToList());

            var driverUserMessageRoomDic = new Dictionary<Guid, Room>();

            if (bookingDetail.Booking.IsShared)
            {
                RouteRoutine fitRouteRoutine = null;

                foreach (var routeRoutine in routeRoutines)
                {
                    if (IsPossibleMappingWithRouteRoutineWithShare(routeRoutine.StartTime, mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic))
                    {
                        fitRouteRoutine = routeRoutine;
                        break;
                    }
                }

                if (fitRouteRoutine == null)
                {
                    foreach (var routeRoutine in routeRoutines)
                    {
                        if (IsPossibleMappingWithRouteRoutineWithoutShare(routeRoutine.StartTime, mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic))
                        {
                            fitRouteRoutine = routeRoutine;
                            break;
                        }
                    }
                }

                if (fitRouteRoutine != null)
                    await MapBookingDetailWithRouteRoutine(bookingDetail, fitRouteRoutine, driverUserMessageRoomDic);
            }
            else
            {
                foreach (var routeRoutine in routeRoutines)
                {
                    if (IsPossibleMappingWithRouteRoutineWithoutShare(routeRoutine.StartTime, mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic))
                    {
                        await MapBookingDetailWithRouteRoutine(bookingDetail, routeRoutine, driverUserMessageRoomDic);
                        break;
                    }
                }
            }
        }
        public async Task<BookingDetail?> MappingBookingDetail(int bookingDetailId)
        {
            var bookingDetail =
                await UnitOfWork.BookingDetails
                .List(e => e.Id == bookingDetailId &&
                           e.Status == BookingDetails.Status.Pending)
                .Include(e => e.BookingDetailDrivers)
                .Include(e => e.Booking)
                .ThenInclude(b => b.StartRouteStation)
                .Include(e => e.Booking)
                .ThenInclude(b => b.User)
                .FirstOrDefaultAsync();

            if (bookingDetail == null) return null;

            var cancelledRouteRoutineIds = bookingDetail.BookingDetailDrivers.Where(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.Cancelled).Select(bdr => bdr.RouteRoutineId).ToList();

            var routeRoutines =
                await UnitOfWork.RouteRoutines
                .List(routeRoutine => (routeRoutine.StartTime <= bookingDetail.Booking.Time && routeRoutine.EndTime > bookingDetail.Booking.Time) &&
                                      routeRoutine.RouteId == bookingDetail.Booking.StartRouteStation.RouteId && routeRoutine.User.Vehicle.VehicleTypeId == bookingDetail.Booking.VehicleTypeId &&
                                      !cancelledRouteRoutineIds.Contains(routeRoutine.Id))
                .Where(routeRoutine => !(routeRoutine.StartAt > bookingDetail.Date || routeRoutine.EndAt < bookingDetail.Date))
                    .Include(e => e.User)
                    .Include(e => e.BookingDetailDrivers.Where(bdr =>
                                bdr.BookingDetail.Date == bookingDetail.Date &&
                                bdr.TripStatus == BookingDetailDrivers.TripStatus.NotYet))
                    .ThenInclude(bdr => bdr.BookingDetail)
                    .ThenInclude(bd => bd.Booking)
                    .ToListAsync();

            var orderedRouteRoutines = routeRoutines
                    .OrderBy(routeRoutine => routeRoutine.BookingDetailDrivers.Count)
                    .ThenByDescending(routeRoutine => routeRoutine.User.Rating)
                    .ThenBy(routeRoutine => routeRoutine.User.CancelledTripRate)
                    .ToList();

            await MappingBookingDetail(bookingDetail, orderedRouteRoutines);

            return bookingDetail;
        }

        public async Task<BookingDetail?> MappingBookingDetailSuddenly(Guid code)
        {
            var bookingDetail =
                await UnitOfWork.BookingDetails
                .List(e => e.Code == code &&
                           e.Status == BookingDetails.Status.Pending)
                .Include(e => e.BookingDetailDrivers)
                .ThenInclude(bdr => bdr.RouteRoutine)
                .ThenInclude(r => r.User)
                .Include(e => e.Booking)
                .ThenInclude(b => b.StartRouteStation)
                .ThenInclude(srs => srs.Station)
                .Include(e => e.Booking)
                .ThenInclude(b => b.User)
                .FirstOrDefaultAsync();

            if (bookingDetail == null) return null;

            bookingDetail.BookingDetailDrivers.Last().TripStatus = BookingDetailDrivers.TripStatus.Cancelled;

            var cancelledRouteRoutineIds = bookingDetail.BookingDetailDrivers.Where(bdr => bdr.TripStatus == BookingDetailDrivers.TripStatus.Cancelled).Select(bdr => bdr.RouteRoutineId).ToList();

            var cancelledDriverCode = bookingDetail.BookingDetailDrivers.Select(bdr => bdr.RouteRoutine.User.Code).ToList();

            var startStation = bookingDetail.Booking.StartRouteStation.Station;

            var availableDrivers = new List<Guid>();

            if (GpsTrackingStream.dic.TryGetValue(Roles.DRIVER.ToString(), out var dictionary))
            {
                foreach(var driverCode in dictionary.Keys)
                {
                    if (!cancelledDriverCode.Contains(driverCode))
                    {
                        var coordinate = dictionary[driverCode];
                        if (ILocationService.CalculateDistanceAsTheCrowFlies(
                        coordinate.Latitude, coordinate.Longitude,
                        startStation.Latitude, startStation.Longitude) <= GpsTrackingStream.radiusLimit)
                        {
                            availableDrivers.Add(driverCode);
                        }
                    }
                }
            }

            var routeRoutines =
                await UnitOfWork.RouteRoutines
                .List(routeRoutine => (routeRoutine.StartTime <= bookingDetail.Booking.Time && routeRoutine.EndTime > bookingDetail.Booking.Time) &&
                                      routeRoutine.RouteId == bookingDetail.Booking.StartRouteStation.RouteId && routeRoutine.User.Vehicle.VehicleTypeId == bookingDetail.Booking.VehicleTypeId &&
                                      !cancelledRouteRoutineIds.Contains(routeRoutine.Id) && availableDrivers.Contains(routeRoutine.User.Code))
                .Where(routeRoutine => !(routeRoutine.StartAt > bookingDetail.Date || routeRoutine.EndAt < bookingDetail.Date))
                    .Include(e => e.User)
                    .Include(e => e.BookingDetailDrivers.Where(bdr =>
                                bdr.BookingDetail.Date == bookingDetail.Date &&
                                (bdr.TripStatus == BookingDetailDrivers.TripStatus.NotYet || bdr.TripStatus == BookingDetailDrivers.TripStatus.PickedUp || bdr.TripStatus == BookingDetailDrivers.TripStatus.Start)))
                    .ThenInclude(bdr => bdr.BookingDetail)
                    .ThenInclude(bd => bd.Booking)
                    .ToListAsync();

            var orderedRouteRoutines = routeRoutines
                    .OrderBy(routeRoutine => routeRoutine.BookingDetailDrivers.Count)
                    .ThenByDescending(routeRoutine => routeRoutine.User.Rating)
                    .ThenBy(routeRoutine => routeRoutine.User.CancelledTripRate)
                    .ToList();

            await MappingBookingDetail(bookingDetail, orderedRouteRoutines);

            return bookingDetail;
        }

        public async Task<Response> Get(int userId, GetBookingRequest request, Response successReponse)
        {
            var bookingQueryable = UnitOfWork.Bookings
                .List(booking => booking.UserId == userId);

            if (request.Code.HasValue)
            {
                bookingQueryable = bookingQueryable.Where(booking => booking.Code == request.Code);
            }

            var bookingViewModels = 
                await bookingQueryable
                    .OrderByDescending(booking => booking.CreatedAt)
                    .MapTo<BookerBookingViewModel>(Mapper)
                    .ToListAsync();

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
        public Task<Booking?> GetByCode(Guid code) => UnitOfWork.Bookings.List(booking => booking.Code == code).Include(booking => booking.User).FirstOrDefaultAsync();
        public Task<bool> Update(Booking booking) => UnitOfWork.Bookings.Update(booking);

        public async Task<bool?> Refund(Guid code)
        {
            var booking = await GetByCode(code);

            if (booking == null) return null;

            if (booking.Status != Bookings.Status.PendingRefund) return null;

            var wallet = await AppServices.Wallet.GetWallet(booking.UserId);

            if (wallet == null) return null;

            bool isSuccess = false;

            try
            {
                var amount = booking.TotalPrice - booking.DiscountPrice;
                switch (booking.PaymentMethod)
                {
                    case Payments.PaymentMethods.Momo:
                        //var transaction = booking.WalletTransactions
                        //    .Where(trans => trans.Type == WalletTransactions.Types.BookingPaidByMomo && trans.Status == WalletTransactions.Status.Success)
                        //    .FirstOrDefault();

                        //if (transaction != null)
                        //{
                        //    var txnId = long.Parse(transaction.TxnId);

                        //    var response = await AppServices.Payment.MomoRefund(txnId, (long)amount);

                        //    if (response.resultCode != (int)Payments.MomoStatusCodes.Successed) return false;

                        //    var refundTransaction = new WalletTransactionDTO
                        //    {
                        //        Amount = amount,
                        //        BookingId = booking.Id,
                        //        Type = WalletTransactions.Types.BookingRefund,
                        //        TxnId = response.transId.ToString(),
                        //        WalletId = wallet.Id,
                        //        Status = WalletTransactions.Status.Success
                        //    };

                        //    await AppServices.WalletTransaction.Create(refundTransaction);

                        //    isSuccess = true;
                        //}

                        ////return true;
                        //break;
                    case Payments.PaymentMethods.Wallet:
                        await AppServices.Wallet.UpdateBalance(new WalletTransactionDTO
                        {
                            Amount = amount,
                            BookingId = booking.Id,
                            Type = WalletTransactions.Types.BookingRefund,
                            WalletId = wallet.Id,
                            Status = WalletTransactions.Status.Success
                        });
                        isSuccess = true;
                        break;
                    //return true;
                    default: return true;
                }

                if (isSuccess)
                {
                    booking.Status = Bookings.Status.CompletedRefund;

                    await Update(booking);

                    var notiDTO = new NotificationDTO()
                    {
                        EventId = Events.Types.RefundBooking,
                        Type = Notifications.Types.SpecificUser,
                        Token = booking.User.FCMToken,
                        UserId = booking.User.Id
                    };

                    await AppServices.Notification.SendPushNotification(notiDTO);

                    return true;
                }  
            }
            catch (Exception e)
            {

            }

            return false;
        }
    }
}
