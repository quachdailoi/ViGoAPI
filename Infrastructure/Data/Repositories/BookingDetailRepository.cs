using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class BookingDetailRepository : GenericRepository<BookingDetail>, IBookingDetailRepository
    {
        public BookingDetailRepository(AppDbContext dbContext, ILogger<GenericRepository<BookingDetail>> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<BookingDetail> GetBookingDetailByCodeAsync(string code)
        {
            return List(x => x.Code.ToString() == code);
        }

        public IQueryable<BookingDetail> GetBookingDetailsByDriverId(int driverId)
        {
            return List().Where(x => x.BookingDetailDrivers.Any(bdr => bdr.DriverId == driverId));
        }
    }
}
