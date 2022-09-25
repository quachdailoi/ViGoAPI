﻿using API.Services.Constract;

namespace API.Services
{
    public class AppServices : IAppServices
    {
        public AppServices(
                IAccountService accountService,
                IVerifiedCodeService verifiedCodeService,
                IUserService userService,
                ITokenService tokenService,
                IBookerService bookerService, 
                IDriverService driverService,
                IUserRoomService userRoomService,
                IRoomService roomService,
                IMessageService messageService,
                IBookingService bookingService,
                IBookingDetailService bookingDetailService,
                IRouteService routeService,
                IStationService stationService,
                IRouteStationService routeStationService,
                IPromotionService promotionService,
                IRapidApiService rapidApiService,
                IBannerService bannerService,
                ILocationService locationService,
                IAdminService adminService,
                IVehicleTypeService vehicleTypeService,
                IVehicleService vehicleService,
                IFareService fareService,
                IFareTimelineService fareTimelineService
            )
        {
            Account = accountService;
            VerifiedCode = verifiedCodeService;
            User = userService;
            Token = tokenService;
            Booker = bookerService;
            Driver = driverService;
            UserRoom = userRoomService;
            Room = roomService;
            Message = messageService;
            Booking = bookingService;
            BookingDetail = bookingDetailService;
            Route = routeService;
            Station = stationService;
            RouteStation = routeStationService;
            Promotion = promotionService;
            RapidApi = rapidApiService;
            Banner = bannerService;
            Location = locationService;
            Admin = adminService;
            VehicleType = vehicleTypeService;
            Vehicle = vehicleService;
            Fare = fareService;
            FareTimeline = fareTimelineService;
        }

        public IAccountService Account { get; }
        public IVerifiedCodeService VerifiedCode { get; }
        public IUserService User { get; }
        public ITokenService Token { get; set; }
        public IBookerService Booker { get; }
        public IDriverService Driver { get; }
        public IUserRoomService UserRoom { get; }
        public IRoomService Room { get; }
        public IMessageService Message { get; }
        public IBookingService Booking { get; }
        public IBookingDetailService BookingDetail { get; }
        public IRouteService Route { get; }
        public IStationService Station { get; }
        public IRouteStationService RouteStation { get; }
        public IPromotionService Promotion { get; }
        public IRapidApiService RapidApi { get; }
        public IBannerService Banner { get; }
        public ILocationService Location { get; }
        public IAdminService Admin { get; }
        public IVehicleTypeService VehicleType { get; }
        public IVehicleService Vehicle { get; }
        public IFareService Fare { get; }
        public IFareTimelineService FareTimeline { get; }
    }
}
