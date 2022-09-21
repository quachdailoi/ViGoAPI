﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IStationRepository : IGenericRepository<Station>
    {
        IQueryable<Station> GetStationsByCodes(List<string> codes);

        IQueryable<Station> GetStationsByIds(List<int> ids);
    }
}
