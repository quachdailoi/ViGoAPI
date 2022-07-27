using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Shares.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDbContext dbContext, ILogger<GenericRepository<Role>> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<Role> GetAllRoles()
        {
            return List();
        }

        public IQueryable<Role> GetRoleByName(string roleName)
        {
            return List(x => x.Name == roleName);
        }
    }
}
