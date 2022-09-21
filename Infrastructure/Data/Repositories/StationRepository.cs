﻿using Domain.Entities;
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
    public class StationRepository : GenericRepository<Station>, IStationRepository
    {
        public StationRepository(AppDbContext dbContext, ILogger<GenericRepository<Station>> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<Station> GetStationsByCodes(List<string> codes)
        {
            return List().Where(s => s.Status == StatusTypes.Station.Active && codes.Contains(s.Code.ToString()));
        }

        public IQueryable<Station> GetStationsByIds(List<int> ids)
        {
            return List().Where(s => s.Status == StatusTypes.Station.Active && ids.Contains(s.Id));
        }
    }
}
