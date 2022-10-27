using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IVerifiedCodeRepository VerifiedCodes { get; }
        IUserRoomRepository UserRooms { get; }
        IRoomRepository Rooms { get; }
        IMessageRepository Messages { get; }
        IBookingRepository Bookings { get; }
        IBookingDetailRepository BookingDetails { get; }
        IBookingDetailDriverRepository BookingDetailDrivers { get; }
        IRouteRepository Routes { get; }
        IStationRepository Stations { get; }
        IRouteStationRepository RouteStations { get; }
        IPromotionRepository Promotions { get; }
        IPromotionUserRepository PromotionUsers { get; }
        IFileRepository Files { get; }
        IBannerRepository Banners { get; }
        IVehicleTypeRepository VehicleTypes { get; }
        IVehicleRepository Vehicles { get; }
        IFareRepository Fares { get; }
        IFareTimelineRepository FareTimelines { get; }
        IRouteRoutineRepository RouteRoutines { get; }
        IAffiliateAccountRepository AffiliateAccounts { get; }
        IAffiliatePartyRepository AffiliateParties { get; }
        IWalletRepository Wallets { get; }
        IWalletTransactionRepository WalletTransactions { get; }
        IEventRepository Events { get; }
        INotificationRepository Notifications { get; }

        Task CreateTransactionAsync();
        Task CommitAsync();
        Task Rollback();
        Task Save();
    }
}
