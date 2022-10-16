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
    public class AffiliatePartyRepository : GenericRepository<AffiliateParty>, IAffiliatePartyRepository
    {
        public AffiliatePartyRepository(AppDbContext dbContext, ILogger<GenericRepository<AffiliateParty>> logger) : base(dbContext, logger)
        {
        }
    }
}
