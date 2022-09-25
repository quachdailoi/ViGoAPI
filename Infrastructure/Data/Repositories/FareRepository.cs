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
    public class FareRepository : GenericRepository<Fare>, IFareRepository
    {
        public FareRepository(AppDbContext dbContext, ILogger<GenericRepository<Fare>> logger) : base(dbContext, logger)
        {
        }
    }
}
