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
    public class AffiliatePartyTypeRepository : GenericRepository<AffiliatePartyType>, IAffiliatePartyTypeRepository
    {
        public AffiliatePartyTypeRepository(AppDbContext dbContext, ILogger<GenericRepository<AffiliatePartyType>> logger) : base(dbContext, logger)
        {
        }
    }
}
