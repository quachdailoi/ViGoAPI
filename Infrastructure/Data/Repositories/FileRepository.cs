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
    public class FileRepository : GenericRepository<AppFile>, IFileRepository
    {
        public FileRepository(AppDbContext dbContext, ILogger<GenericRepository<AppFile>> logger) : base(dbContext, logger)
        {
        }
    }
}
