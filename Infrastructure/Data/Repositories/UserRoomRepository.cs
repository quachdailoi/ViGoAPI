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
    public class UserRoomRepository : GenericRepository<UserRoom>, IUserRoomRepository
    {
        public UserRoomRepository(AppDbContext dbContext, ILogger<GenericRepository<UserRoom>> logger) : base(dbContext, logger)
        {
        }
    }
}
