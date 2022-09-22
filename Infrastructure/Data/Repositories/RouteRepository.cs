﻿using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(AppDbContext dbContext, ILogger<GenericRepository<Route>> logger) : base(dbContext, logger)
        {
        }

        public async Task<Route> CreateRoute(Route route)
        {
            return await Add(route);
        }
    }
}
