using Domain.Interfaces.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AppDbContext _dbContext;

        public DbSet<T> DbSet { get; private set; }

        private readonly ILogger _logger;

        public GenericRepository(AppDbContext dbContext, ILogger<GenericRepository<T>> logger)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<T>();
            _logger = logger;
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                if (typeof(IBaseEntity).IsAssignableFrom(typeof(T)))
                {
                    ((IBaseEntity) entity).CreatedAt = DateTime.UtcNow;
                }
                entity = (await DbSet.AddAsync(entity)).Entity;

                await this._dbContext.SaveChangesAsync();

                return entity; 
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add function error.", typeof(T));
            }
            return null;
        }

        public IQueryable<T> List(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return DbSet.AsQueryable();
            }
            return DbSet.Where(expression);
        }

        public virtual async Task<bool> Remove(T entity)
        {
            try
            {
                var exist = await DbSet.FindAsync((IBaseEntity) entity);

                if (exist == null) return false;

                if (typeof(IBaseEntity).IsAssignableFrom(typeof(T)))
                {
                    ((IBaseEntity) entity).DeletedAt = DateTime.UtcNow;
                    DbSet.Update(entity);
                }
                else
                {
                    DbSet.Remove(entity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Remove function error.", typeof(T));
                return false;
            }
            //await _dbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                if (typeof(IBaseEntity).IsAssignableFrom(typeof(T)))
                {
                    ((IBaseEntity)entity).UpdatedAt = DateTime.UtcNow;
                }
                DbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error.", typeof(T));
            }
            return false;
        }

        public async Task<List<T>> Add(List<T> entities)
        {
            try
            {
                if (typeof(IBaseEntity).IsAssignableFrom(typeof(T)))
                {
                    entities.ForEach(entity =>
                    {
                        ((IBaseEntity)entity).CreatedAt = DateTime.UtcNow;
                    });                   
                }
                await DbSet.AddRangeAsync(entities);

                await this._dbContext.SaveChangesAsync();

                return entities;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add function error.", typeof(T));
            }
            return null;
        }
    }
}
