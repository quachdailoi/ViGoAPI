﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRouteRoutineRepository :  IGenericRepository<RouteRoutine>
    {
        IQueryable<RouteRoutine> GetActiveRoutines(int driverId);

        IQueryable<RouteRoutine> GetAllRouteRoutine(int? driverId = null);
    }
}
