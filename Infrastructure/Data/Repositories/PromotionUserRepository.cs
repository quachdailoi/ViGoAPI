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
    public class PromotionUserRepository : GenericRepository<PromotionUser>, IPromotionUserRepository
    {
        public PromotionUserRepository(AppDbContext dbContext, ILogger<GenericRepository<PromotionUser>> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<PromotionUser> GetUsedPromotion(int userId)
        {
            return List().Where(p => p.UserId == userId);
        }
    }
}
