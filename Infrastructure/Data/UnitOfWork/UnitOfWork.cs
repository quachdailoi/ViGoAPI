﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnitOfWork;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _dbContext;
        private IDbContextTransaction _dbTransaction;
        private bool _disposed;
        private readonly ILogger _logger;

        public IAccountRepository Accounts { get; private set; }
        public IRoleRepository Roles { get; private set; }
        public IUserRepository Users { get; private set; }
        public IVerifiedCodeRepository VerifiedCodes { get; private set; }

        public IUserRoomRepository UserRooms { get; private set; }

        public IRoomRepository Rooms { get; private set; }

        public IMessageRepository Messages { get; private set; }
        public IBookingRepository Bookings { get; private set; }
        public IBookingDetailRepository BookingDetails { get; private set; }
        public IFileRepository Files { get; private set; }
        public IRouteRepository Routes { get; private set; }
        public IStationRepository Stations { get; private set; }
        public IRouteStationRepository RouteStations { get; private set; }

        public IPromotionRepository Promotions { get; }
        public IPromotionUserRepository PromotionUsers { get; }

        public IBannerRepository Banners { get; }
        public IVehicleTypeRepository VehicleTypes { get; }
        public IVehicleRepository Vehicles { get; }
        public IFareRepository Fares { get; }
        public IFareTimelineRepository FareTimelines { get; }
        public IRouteRoutineRepository RouteRoutines { get; }

        public UnitOfWork(
            AppDbContext dbContext, 
            ILoggerFactory loggerFactory,
            IAccountRepository accountRepository,
            IRoleRepository roleRepository,
            IUserRepository userRepository,
            IVerifiedCodeRepository verifiedCodeRepository,
            IUserRoomRepository userRoomRepository,
            IRoomRepository roomRepository,
            IMessageRepository messageRepository,
            IBookingRepository bookingRepository,
            IBookingDetailRepository bookingDetailRepository,
            IRouteRepository routeRepository,
            IFileRepository fileRepository,
            IStationRepository stationRepository,
            IRouteStationRepository routeStaionRepository,
            IPromotionRepository promotionRepository,
            IPromotionUserRepository promotionUserRepository,
            IBannerRepository bannerRepository,
            IVehicleTypeRepository vehicleTypeRepository,
            IVehicleRepository vehicleRepository,
            IFareRepository fareRepository,
            IFareTimelineRepository fareTimelineRepository,
            IRouteRoutineRepository routeRoutineRepository)
        {
            _dbContext = dbContext;

            Users = userRepository;
            Roles = roleRepository;
            Accounts = accountRepository;
            VerifiedCodes = verifiedCodeRepository;
            UserRooms = userRoomRepository;
            Rooms = roomRepository;
            Messages = messageRepository;
            Bookings = bookingRepository;
            BookingDetails = bookingDetailRepository;
            Routes = routeRepository;
            Files = fileRepository;
            Stations = stationRepository;
            RouteStations = routeStaionRepository;
            Promotions = promotionRepository;
            PromotionUsers = promotionUserRepository;
            Banners = bannerRepository;
            VehicleTypes = vehicleTypeRepository;
            Vehicles = vehicleRepository;
            Fares = fareRepository;
            FareTimelines = fareTimelineRepository;
            RouteRoutines = routeRoutineRepository;

            _logger = loggerFactory.CreateLogger("logs");
        }

        public async Task CommitAsync()
        {
            if (_dbTransaction != null)
            {
                await _dbTransaction.CommitAsync();
            }
        }

        public async Task CreateTransactionAsync()
        {
            try
            {
                _dbTransaction = await _dbContext.Database.BeginTransactionAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Rollback()
        {
            if (_dbTransaction != null && !_disposed)
            {
                await _dbTransaction.RollbackAsync();
                await _dbTransaction.DisposeAsync();
                _disposed = true;
            }
        }

        public async Task Save()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception dbEx)
            {
                _logger.LogError(dbEx, "{UnitOfWork} Save function error", typeof(UnitOfWork));
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _dbContext.Dispose();
            _disposed = true;
        }
    }
}
