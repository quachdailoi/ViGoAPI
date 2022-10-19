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
    public class StationRepository : GenericRepository<Station>, IStationRepository
    {
        public StationRepository(AppDbContext dbContext, ILogger<GenericRepository<Station>> logger) : base(dbContext, logger)
        {
        }

        public Task<bool> DeleteStations(List<Station> stations)
        {
            return RemoveRange(stations.ToArray(), softDelete: true);
        }

        public IQueryable<Station> GetStationByCode(string code)
        {
            return List().Where(s => s.Code.ToString() == code);
        }

        public IQueryable<Station> GetStationByCode(Guid code)
        {
            return List().Where(s => s.Code == code);
        }

        public IQueryable<Station> GetStationsByCodes(List<Guid> codes)
        {
            return List().Where(s => s.Status == Stations.Status.Active && codes.Contains(s.Code));
        }

        public IQueryable<Station> GetStationsByIds(List<int> ids)
        {
            return List().Where(s => s.Status == Stations.Status.Active && ids.Contains(s.Id));
        }
    }
}
