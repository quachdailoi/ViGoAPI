using Domain.Entities;
using Domain.Interfaces.Entities;
using Domain.Shares.Enums;
using Infrastructure.Data.EntityConfigurations;
using Infrastructure.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigSoftDeleteQuery(builder);

            base.OnModelCreating(builder);

            AddEntityConfiguration(builder);

            new RoleSeeder(builder);

            new FileSeeder(builder);

            new UserSeeder(builder);

            new AccountSeeder(builder);

            new PromotionSeeder(builder);

            new PromotionConditionSeeder(builder);

            new PromotionUserSeeder(builder);

            new StationSeeder(builder);

            new BannerSeeder(builder);
        }

        private void ConfigSoftDeleteQuery(ModelBuilder builder)
        {
            Expression<Func<IBaseEntity, bool>> filterExpr = e => e.DeletedAt == null;

            foreach (var mutableEntityType in builder.Model.GetEntityTypes())
            {
                // check if current entity type is child of BaseModel
                if (mutableEntityType.ClrType.IsAssignableTo(typeof(IBaseEntity)))
                {
                    // modify expression to handle correct child type
                    var parameter = Expression.Parameter(mutableEntityType.ClrType);
                    var body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                    var lambdaExpression = Expression.Lambda(body, parameter);

                    // set filter
                    mutableEntityType.SetQueryFilter(lambdaExpression);
                }
            }
        }

        private void AddEntityConfiguration(ModelBuilder builder)
        {
            new RoleEntityConfiguration()
                .Configure(builder.Entity<Role>());

            new FileEntityConfiguration()
                .Configure(builder.Entity<AppFile>());

            new UserEntityConfiguration()
                .Configure(builder.Entity<User>());

            new AccountEntityConfiguration()
                .Configure(builder.Entity<Account>());

            new VerifiedCodeEntityConfiguration()
                .Configure(builder.Entity<VerifiedCode>());

            new UserRoomEntityConfiguration()
                .Configure(builder.Entity<UserRoom>());

            new RoomEntityConfiguration()
                .Configure(builder.Entity<Room>());

            new MessageEntityConfiguration()
                .Configure(builder.Entity<Message>());

            new BookingEntityConfiguration()
                .Configure(builder.Entity<Booking>());

            new BookingDetailEntityConfiguration()
                .Configure(builder.Entity<BookingDetail>());

			new RouteEntityConfiguration()
                .Configure(builder.Entity<Route>());

            new StationEntityConfiguration()
                .Configure(builder.Entity<Station>());

            new RouteStationEntityConfiguration()
                .Configure(builder.Entity<RouteStation>());

            new PromotionConditionEntityConfiguration()
                .Configure(builder.Entity<PromotionCondition>());

            new PromotionEntityConfiguration()
                .Configure(builder.Entity<Promotion>());

            new PromotionUserEntityConfiguration()
                .Configure(builder.Entity<PromotionUser>());

			new BannerEntityConfiguration()
                .Configure(builder.Entity<Banner>());

            new VehicleTypeEntityConfiguration()
                .Configure(builder.Entity<VehicleType>());

            new VehicleEntityConfiguration()
                .Configure(builder.Entity<Vehicle>());

            new FareEntityConfiguration()
                .Configure(builder.Entity<Fare>());

            new FareTimelineEntityConfiguration()
                .Configure(builder.Entity<FareTimeline>());


        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AppFile> Files { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VerifiedCode> VerifiedCodes { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<RouteStation> RouteStations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionUser> PromotionUsers { get; set; }
        public DbSet<PromotionCondition> PromotionConditions { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Fare> Fares { get; set; }
        public DbSet<FareTimeline> FareTimelines { get; set; }
    }
}