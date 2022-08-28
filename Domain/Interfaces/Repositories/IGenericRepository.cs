using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);

        Task<List<T>> Add(List<T> entities);

        Task<bool> Update(T entity);

        Task<bool> Remove(T entity);

        IQueryable<T> List(Expression<Func<T, bool>> expression = default);
    }
}
