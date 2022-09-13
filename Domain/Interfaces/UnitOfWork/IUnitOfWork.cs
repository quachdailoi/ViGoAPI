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
        IRouteRepository Route { get; }
        IStationRepository Station { get; }
        IRouteStationRepository RouteStaion { get; }
        IPromotionRepository Promotions { get; }
        IPromotionUserRepository PromotionUsers { get; }
        IFileRepository Files { get; }

        Task CreateTransactionAsync();
        Task CommitAsync();
        Task Rollback();
        Task Save();
    }
}
