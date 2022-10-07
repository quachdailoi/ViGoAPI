﻿using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class AffiliateAccountRepository : GenericRepository<AffiliateAccount>, IAffiliateAccountRepository
    {
        public AffiliateAccountRepository(AppDbContext dbContext, ILogger<GenericRepository<AffiliateAccount>> logger) : base(dbContext, logger)
        {
        }
    }
}
