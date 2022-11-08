using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Shares.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class RouteRoutineRepository : GenericRepository<RouteRoutine>, IRouteRoutineRepository
    {
        public RouteRoutineRepository(AppDbContext dbContext, ILogger<GenericRepository<RouteRoutine>> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<RouteRoutine> GetActiveRoutines(int driverId)
        {
            return List().Where(x => x.UserId == driverId)
                    .Where(x => x.Status == RouteRoutines.Status.Active);
        }

        public IQueryable<RouteRoutine> GetAllRouteRoutine(int? driverId = null)
        {

            if (driverId != null) 
                return List().Where(x => x.UserId == driverId);

            return List();
        }
    }
}
