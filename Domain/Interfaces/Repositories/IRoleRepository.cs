using Domain.Entities;
using Domain.Shares.Enums;

namespace Domain.Interfaces.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        IQueryable<Role> GetRoleByName(string roleName);
        IQueryable<Role> GetRoleById(Roles roleId);

        IQueryable<Role> GetAllRoles();
    }
}
