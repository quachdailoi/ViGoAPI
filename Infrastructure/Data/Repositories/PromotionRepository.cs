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
    public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(AppDbContext dbContext, ILogger<GenericRepository<Promotion>> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<Promotion> GetAll()
        {
            return List();
        }
    }
}
