using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class PricingRepository : GenericRepository<Pricing>, IPricingRepository
    {
        public PricingRepository(AppDbContext dbContext, ILogger<GenericRepository<Pricing>> logger) : base(dbContext, logger)
        {
        }

        public Task<List<Pricing>> Get() => List().ToListAsync();
    }
}
