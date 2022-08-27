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

        Task CreateTransactionAsync();
        Task CommitAsync();
        Task Rollback();
        Task Save();
    }
}
