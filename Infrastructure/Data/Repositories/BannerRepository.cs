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
    public class BannerRepository : GenericRepository<Banner>, IBannerRepository
    {
        public BannerRepository(AppDbContext dbContext, ILogger<GenericRepository<Banner>> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<Banner> GetAll()
        {
            return List();
        }
    }
}
