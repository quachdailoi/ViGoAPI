using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IStationRepository : IGenericRepository<Station>
    {
        IQueryable<Station> GetStationsByCodes(List<Guid> codes);

        IQueryable<Station> GetStationsByIds(List<int> ids);

        IQueryable<Station> GetStationByCode(string code);
        IQueryable<Station> GetStationByCode(Guid code);

        Task<bool> DeleteStations(List<Station> stations);
    }
}
