using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRouteRepository : IGenericRepository<Route>
    {
        Task<Route> CreateRoute(Route route);
        Task<Route> GetRouteByCode(string code);
        IQueryable<Route> GetRouteByCode(Guid code);
    }
}
