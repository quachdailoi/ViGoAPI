using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IQueryable<User> GetUserByCode(string code);
        IQueryable<User> GetUserById(int id);
        Task UpdateUser(User user);
    }
}
