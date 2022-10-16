
using API.SignalR.Constract;
using API.TaskQueues;

namespace API.Services.Constract
{
    public interface IAppServices
    {
        IServiceProvider Provider { get; }
        IAccountService Account { get; }
        IVerifiedCodeService VerifiedCode { get; }
        IUserService User { get; }

        ITokenService Token { get; }

        IBookerService Booker { get; }

        IDriverService Driver { get; }

        IAdminService Admin { get; }

        IUserRoomService UserRoom { get; }
        IRoomService Room { get; }
        IMessageService Message  { get; }
        IBookingService Booking { get; }
        IBookingDetailService BookingDetail { get; }
        IBookingDetailDriverService BookingDetailDriver { get; }
        IRouteService Route { get; }
        IStationService Station { get; }
        IRouteStationService RouteStation { get; }
		IPromotionService Promotion { get; }
        IRapidApiService RapidApi { get; }
        IBannerService Banner { get; }
        ILocationService Location { get; }
        IVehicleTypeService VehicleType { get; }
        IVehicleService Vehicle { get; }
        IFareService Fare { get; }
        IFareTimelineService FareTimeline { get; }
        IPaymentService Payment { get; }
        IRouteRoutineService RouteRoutine { get; }
        IAffiliateAccountService AffiliateAccount { get; }
        IAffiliatePartyService AffiliateParty { get; }
        IWalletService Wallet { get; }
        IWalletTransactionService WalletTransaction { get; }
        IFileService File { get; }
        IRedisMQService RedisMQ { get; }
        ISignalRService SignalR { get; }
    }
}
