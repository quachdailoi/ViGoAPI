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
    public class RouteStationRepository : GenericRepository<RouteStation>, IRouteStationRepository
    {
        public RouteStationRepository(AppDbContext dbContext, ILogger<GenericRepository<RouteStation>> logger) : base(dbContext, logger)
        {
        }
    }
}
