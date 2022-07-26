﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IBookingDetailRepository : IGenericRepository<BookingDetail>
    {
        IQueryable<BookingDetail> GetBookingDetailsByDriverId(int driverId);
        IQueryable<BookingDetail> GetBookingDetailByCodeAsync(string code);
    }
}
