using API.Services.Constract;
using API.SignalR.Constract;
using API.TaskQueues;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Microsoft.Extensions.Caching.Distributed;

namespace API.Services
{
    public class AppServices : IAppServices
    {
        public IServiceProvider Provider { get; private set; }

        public AppServices(IServiceProvider provider)
        {
            Provider = provider.CreateScope().ServiceProvider;
        }

        public IAccountService Account => Load<IAccountService>();
        public IVerifiedCodeService VerifiedCode => Load<IVerifiedCodeService>();
        public IUserService User => Load<IUserService>();
        public ITokenService Token => Load<ITokenService>();
        public IBookerService Booker => Load<IBookerService>();
        public IDriverService Driver => Load<IDriverService>();
        public IUserRoomService UserRoom => Load<IUserRoomService>();
        public IRoomService Room => Load<IRoomService>();
        public IMessageService Message => Load<IMessageService>();
        public IBookingService Booking => Load<IBookingService>();
        public IBookingDetailService BookingDetail => Load<IBookingDetailService>();
        public IBookingDetailDriverService BookingDetailDriver => Load<IBookingDetailDriverService>();
        public IRouteService Route => Load<IRouteService>();
        public IStationService Station => Load<IStationService>();
        public IRouteStationService RouteStation => Load<IRouteStationService>();
        public IPromotionService Promotion => Load<IPromotionService>();
        public IRapidApiService RapidApi => Load<IRapidApiService>();
        public IBannerService Banner => Load<IBannerService>();
        public ILocationService Location => Load<ILocationService>();
        public IAdminService Admin => Load<IAdminService>();
        public IVehicleTypeService VehicleType => Load<IVehicleTypeService>();
        public IVehicleService Vehicle => Load<IVehicleService>();
        public IFareService Fare => Load<IFareService>();
        public IFareTimelineService FareTimeline => Load<IFareTimelineService>();
        public IRouteRoutineService RouteRoutine => Load<IRouteRoutineService>();
        public IPaymentService Payment => Load<IPaymentService>();
        public IFileService File => Load<IFileService>();
        public IRedisMQService RedisMQ => Load<IRedisMQService>();
        public ISignalRService SignalR => Load<ISignalRService>();
        public IAffiliateAccountService AffiliateAccount => Load<IAffiliateAccountService>();
        public IAffiliatePartyService AffiliateParty => Load<IAffiliatePartyService>();
        public IWalletService Wallet => Load<IWalletService>();
        public IWalletTransactionService WalletTransaction => Load<IWalletTransactionService>();

        private T Load<T>() where T : class => Provider.GetRequiredService<T>();
    }
}
