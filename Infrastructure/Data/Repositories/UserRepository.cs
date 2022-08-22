using Domain.Entities;
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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext, ILogger<GenericRepository<User>> logger) : base(dbContext, logger)
        {
        }

        public IQueryable<User> GetUserByCode(string code)
        {
            return List(user => user.Code.ToString() == code);
        }

        public IQueryable<User> GetUserById(int id)
        {
            return List(user => user.Id == id);
        }
    }
}
