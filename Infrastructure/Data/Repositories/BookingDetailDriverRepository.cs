using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class BookingDetailDriverRepository : GenericRepository<BookingDetailDriver>, IBookingDetailDriverRepository
    {
        public BookingDetailDriverRepository(AppDbContext dbContext, ILogger<GenericRepository<BookingDetailDriver>> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<BookingDetailDriver> GetByDriverId(int driverId)
        {
            return List(x => x.DriverId == driverId);
        }
    }
}
