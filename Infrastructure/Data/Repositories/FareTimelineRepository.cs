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
    public class FareTimelineRepository : GenericRepository<FareTimeline>, IFareTimelineRepository
    {
        public FareTimelineRepository(AppDbContext dbContext, ILogger<GenericRepository<FareTimeline>> logger) : base(dbContext, logger)
        {
        }
    }
}
