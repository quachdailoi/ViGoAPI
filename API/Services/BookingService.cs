using API.Extensions;
using API.Models;
using API.Models.DTO;
using API.Models.Requests;
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

        public Task<bool> CheckIsConflictBooking(Booking booking)
             => UnitOfWork.Bookings
                .List(e =>
                    (e.Status == Bookings.Status.PendingMapping ||
                    e.Status == Bookings.Status.Started) &&
                    !(e.Time.AddMinutes(e.Duration / 60) < booking.Time ||
                    e.Time > booking.Time.AddMinutes(booking.Duration / 60)) &&
                    e.UserId == booking.UserId &&
                    !(e.StartAt > booking.EndAt || e.EndAt < booking.StartAt))
                .AnyAsync();

        public async Task<Response> Create(
            BookingDTO dto, CollectionLinkRequestDTO paymentDto, Response successResponse, Response invalidStationResponse, Response invalidVehicleTypeResponse,
            Response invalidRouteResponse, Response duplicationResponse, Response invalidPromotionResponse, Response notAvailableResponse, Response insufficientBalanceResponse, Response errorResponse, bool isDummy = false)
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

            if (isDummy && !AppServices.RouteRoutine.GetRouteRoutineFitBookingCondition(booking).Result.Any()) return notAvailableResponse;
 

            await UnitOfWork.CreateTransactionAsync();

            booking = await UnitOfWork.Bookings.Add(booking);

            if (booking == null) return errorResponse;

            string paymentUrl = String.Empty;
            string webUrl = string.Empty;

            try
            {
                var wallet = await AppServices.Wallet.GetWallet(booking.UserId);
                if (wallet == null) throw new Exception("Wallet is not exist.");

                var walletTransactionDto = new WalletTransactionDTO
                {
                    Amount = booking.TotalPrice,
                    TxnId = booking.Id.ToString(),
                    Status = WalletTransactions.Status.Pending,
                    WalletId = wallet.Id
                };

                switch (booking.PaymentMethod)
                {
                    case Payments.PaymentMethods.Momo:
                        walletTransactionDto.Type = WalletTransactions.Types.BookingPaidByMomo;


                        walletTransactionDto = await AppServices.WalletTransaction.Create(walletTransactionDto);

                        if (walletTransactionDto == null) throw new Exception("Fail to generate transaction");

                        ((MomoCollectionLinkRequestDTO)paymentDto).amount = (long)booking.TotalPrice;
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderId = booking.Code.ToString();
                        ((MomoCollectionLinkRequestDTO)paymentDto).orderInfo = "Pay for ViGo booking";
                        ((MomoCollectionLinkRequestDTO)paymentDto).extraData = Encryption.EncodeBase64(walletTransactionDto);

                        var momoResponse = await AppServices.Payment.GenerateMomoPaymentUrl((MomoCollectionLinkRequestDTO)paymentDto);
                        if (momoResponse == null) throw new Exception("Fail to generate momo url.");

                        paymentUrl = momoResponse.deeplink;
                        webUrl = momoResponse.payUrl;
                        break;
                    case Payments.PaymentMethods.ZaloPay:

                        walletTransactionDto.Type = WalletTransactions.Types.BookingPaidByZaloPay;

                        walletTransactionDto = await AppServices.WalletTransaction.Create(walletTransactionDto);

                        if (walletTransactionDto == null) throw new Exception("Fail to generate transaction");

                        ((ZaloCollectionLinkRequestDTO)paymentDto).amount = (long)booking.TotalPrice;
                        ((ZaloCollectionLinkRequestDTO)paymentDto).raw_item = new List<object>
                        {
                            Mapper.Map<PaymentBookingViewModel>(booking)
                        };

                        var zaloPayResponse = await AppServices.Payment.GenerateZaloPaymentUrl((ZaloCollectionLinkRequestDTO)paymentDto);
                        if (zaloPayResponse == null) throw new Exception("Fail to generate zalopay url.");

                        paymentUrl = zaloPayResponse.order_url;
                        break;
                    case Payments.PaymentMethods.Wallet:
                        if (wallet.Balance < booking.TotalPrice) throw new Exception("Insufficient balance.");
                        
                        wallet = await AppServices.Wallet.UpdateBalance(new WalletTransactionDTO
                        {
                            Amount = booking.TotalPrice,
                            TxnId = booking.Id.ToString(),
                            Status = WalletTransactions.Status.Success,
                            WalletId = wallet.Id,
                            Type = WalletTransactions.Types.BookingPaid
                        });

                        if (wallet == null) throw new Exception("Fail to pay by wallet.");

                        booking.Status = Bookings.Status.PendingMapping;

                        if (!UnitOfWork.Bookings.Update(booking).Result) throw new Exception("Fail to update booking status."); if (!UnitOfWork.Bookings.Update(booking).Result) throw new Exception("Fail to update booking status.");

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
                Booking = bookingViewModel,
                PaymentUrl = paymentUrl,
                WebLinkUrl = webUrl
            } 
            );
        }


        private bool IsSatisfiedTimeCondition(TimeOnly routeRoutineStartTime, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            var curBookingStartStation = routeStationDic[bookingDetail.Booking.StartRouteStationId];
            var timeArriveCurBookingStartStation = routeRoutineStartTime.AddMinutes(curBookingStartStation.DurationFromFirstStationInRoute / 60);


            return timeArriveCurBookingStartStation.ToTimeSpan(bookingDetail.Booking.Time).TotalMinutes <= Bookings.AllowedMappingTimeRange;
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
            var curStartStation = routeStationDic[bookingDetail.Booking.StartRouteStationId];
            var curEndStation = routeStationDic[bookingDetail.Booking.EndRouteStationId];

            var possibleSharingBookingDetails =
                    mappedBookingDetails
                    .Where(mappedBookingDetail =>
                        !(curStartStation.DistanceFromFirstStationInRoute >= routeStationDic[mappedBookingDetail.Booking.EndRouteStationId].DistanceFromFirstStationInRoute ||
                          curEndStation.DistanceFromFirstStationInRoute <= routeStationDic[mappedBookingDetail.Booking.StartRouteStationId].DistanceFromFirstStationInRoute))
                    .OrderBy(mappedBookingDetail => mappedBookingDetail.Booking.Time)
                    .ToList();

            var deniedSharingBookingDetails =
                possibleSharingBookingDetails
                .Where(mappedBookingDetail => !mappedBookingDetail.Booking.IsShared)
                .ToList();

            if (!deniedSharingBookingDetails.Any() && possibleSharingBookingDetails.Any())
            {
                //check is satisfied position
                if (IsSatisfiedTimeCondition(routeRoutineStartTime, bookingDetail, routeStationDic))
                {
                    //check is satisfied slots
                    if (IsSatisfiedSlotCondition(possibleSharingBookingDetails, bookingDetail, routeStationDic)) return true;
                }
            }

            return false;
        }
        private bool IsPossibleMappingWithRouteRoutineWithoutShare(TimeOnly routeRoutineStartTime, List<BookingDetail> mappedBookingDetails, BookingDetail bookingDetail, Dictionary<int, RouteStation> routeStationDic)
        {
            var curStartStation = routeStationDic[bookingDetail.Booking.StartRouteStationId];
            var curEndStation = routeStationDic[bookingDetail.Booking.EndRouteStationId];


            var mappedBookingDetailConflictWithBookingDetail = mappedBookingDetails
                .Where(bookingDetailMapped =>
                        !(curStartStation.DistanceFromFirstStationInRoute >= routeStationDic[bookingDetailMapped.Booking.EndRouteStationId].DistanceFromFirstStationInRoute ||
                          curEndStation.DistanceFromFirstStationInRoute <= routeStationDic[bookingDetailMapped.Booking.StartRouteStationId].DistanceFromFirstStationInRoute))
                .ToList();

            if (!mappedBookingDetailConflictWithBookingDetail.Any())
            {
                if(IsSatisfiedTimeCondition(routeRoutineStartTime, bookingDetail,routeStationDic)) return true;
            }
            return false;
        }
        private async Task MapBookingDetailWithDriver(BookingDetail bookingDetail, User driver, Dictionary<Guid,Room> driverUserMessageRoomDic)
        {
            bookingDetail.Status = BookingDetails.Status.Ready;
            bookingDetail.BookingDetailDrivers.Add(
                new BookingDetailDriver
                {
                    BookingDetailId = bookingDetail.Id,
                    DriverId = driver.Id,
                });

            if (!driverUserMessageRoomDic.TryGetValue(driver.Code, out var room))
            {
                room = await AppServices.Room.GetByMemberCode(new List<Guid> { driver.Code, bookingDetail.Booking.User.Code });

                if (room == null)
                {
                    room = await AppServices.Room.Create(new List<Guid> { driver.Code, bookingDetail.Booking.User.Code }, Rooms.RoomTypes.Conversation);
                    driverUserMessageRoomDic[driver.Code] = room;
                }
                else
                {
                    room.Status = Rooms.Status.Active;

                    foreach (var userRoom in room.UserRooms)
                    {
                        userRoom.Status = Rooms.UserRoomStatus.Active;
                    }

                    driverUserMessageRoomDic[driver.Code] = room;

                    bookingDetail.MessageRoomId = room.Id;
                    bookingDetail.MessageRoom = room;

                    return;
                }
            }

            bookingDetail.MessageRoomId = room.Id;
        }

        public async Task<Booking?> Mapping(int bookingId)
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

            if (booking == null) return null;

            var routeStationDic =
                (await UnitOfWork.Routes
                .List(e => e.Id == booking.StartRouteStation.RouteId && e.Status == Routes.Status.Active)
                .Include(e => e.RouteStations)
                .ThenInclude(rs => rs.Station)
                .FirstOrDefaultAsync())?
                .RouteStations
                .ToDictionary(e => e.Id);

            if(routeStationDic == null) return null;

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
                    .ThenInclude(u => u.BookingDetailDrivers.Where(bdr =>
                                bdr.BookingDetail.Date == bookingDetail.Date &&
                                bdr.Status == BookingDetailDrivers.Status.Ready))
                    .ThenInclude(bdr => bdr.BookingDetail)
                    .ThenInclude(bd => bd.Booking)
                    .ToListAsync());

                rawOrderedRouteRoutines.ForEach(routeRoutine =>
                    routeRoutine.User.BookingDetailDrivers = routeRoutine.User.BookingDetailDrivers.
                        Where(bdr => 
                            bdr.BookingDetail.Booking.Time >= routeRoutine.StartTime &&
                            bdr.BookingDetail.Booking.Time <= routeRoutine.EndTime)
                        .ToList());

                var orderedRouteRoutines = rawOrderedRouteRoutines
                    .OrderBy(routeRoutine => routeRoutine.User.BookingDetailDrivers.Count)
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
                                bdr.TripStatus == BookingDetailDrivers.TripStatus.NotYet)
                            .OrderBy(bdr => bdr.BookingDetail.Booking.Time)
                            .ToList()
                            .Select(bdr => bdr.BookingDetail)
                            .ToList();
                        }

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
                        await MapBookingDetailWithDriver(bookingDetail, fitRouteRoutine.User, driverUserMessageRoomDic);
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
                                bdr.TripStatus == BookingDetailDrivers.TripStatus.NotYet)
                            .OrderBy(bdr => bdr.BookingDetail.Booking.Time)
                            .ToList()
                            .Select(bdr => bdr.BookingDetail)
                            .ToList();
                        }

                        if (IsPossibleMappingWithRouteRoutineWithoutShare(routeRoutine.StartTime,mappedBookingDetailsDic[routeRoutine.Id], bookingDetail, routeStationDic))
                        {
                            await MapBookingDetailWithDriver(bookingDetail, routeRoutine.User, driverUserMessageRoomDic);
                            break;
                        }
                    }
                }

                //foreach (var routeRoutine in routeRoutines) routeRoutine.Dispose();
            }



            var endTime = DateTimeOffset.UtcNow;

            var mappedBookingDetails = booking.BookingDetails.Where(bd => bd.Status == BookingDetails.Status.Ready).ToList();
            Console.WriteLine($"BookingId: {booking.Id} | Status: {mappedBookingDetails.Any()} / {mappedBookingDetails.Count} / {booking.BookingDetails.Count} | EndTime: {endTime} | Time: {endTime.Subtract(startTime).TotalMilliseconds} ms");

            return booking;
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
    }
}
