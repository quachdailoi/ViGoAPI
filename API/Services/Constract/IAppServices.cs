
namespace API.Services.Constract
{
    public interface IAppServices
    {
        IAccountService Account { get; }
        IVerifiedCodeService VerifiedCode { get; }
        IUserService User { get; }

        ITokenService Token { get; }

        IBookerService Booker { get; }

        IDriverService Driver { get; }

        IUserRoomService UserRoom { get; }
        IRoomService Room { get; }
        IMessageService Message  { get; }
        IBookingService Booking { get; }
        IBookingDetailService BookingDetail { get; }
        IRouteService Route { get; }
        IStationService Station { get; }
        IRouteStationService RouteStation { get; }

		IPromotionService Promotion { get; }
        ITrueWayMatrixApiService TrueWayMatrixApi{ get; }
    }
}
