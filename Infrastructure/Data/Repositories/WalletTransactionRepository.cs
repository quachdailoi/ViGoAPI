﻿using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class WalletTransactionRepository : GenericRepository<WalletTransaction>, IWalletTransactionRepository
    {
        public WalletTransactionRepository(AppDbContext dbContext, ILogger<GenericRepository<WalletTransaction>> logger) : base(dbContext, logger)
        {
        }

        public Task<WalletTransaction> GetByCode(Guid code) => List(e => e.Code == code).FirstOrDefaultAsync();
    }
}
