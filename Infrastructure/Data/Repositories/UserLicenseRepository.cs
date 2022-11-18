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
    public class UserLicenseRepository : GenericRepository<UserLicense>, IUserLicenseRepository
    {
        public UserLicenseRepository(AppDbContext dbContext, ILogger<GenericRepository<UserLicense>> logger) : base(dbContext, logger)
        {
        }
    }
}
