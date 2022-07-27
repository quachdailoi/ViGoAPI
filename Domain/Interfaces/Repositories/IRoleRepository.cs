using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        IQueryable<Role> GetRoleByName(string roleName);

        IQueryable<Role> GetAllRoles();
    }
}
