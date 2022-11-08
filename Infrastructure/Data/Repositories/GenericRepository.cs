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
            this._dbContext = dbContext;
            this.DbSet = dbContext.Set<T>();
            this._logger = logger;
        }

        public async Task<T> Add(T entity)
        {
            try
            {
                if (typeof(IBaseEntity).IsAssignableFrom(typeof(T)))
                {
                    ((IBaseEntity)entity).CreatedAt = DateTimeOffset.Now;
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
                var exist = await DbSet.FindAsync(((IBaseEntity)entity).Id);

                if (exist == null) return false;

                //DbSet.Remove(entity);
                if (typeof(IBaseEntity).IsAssignableFrom(typeof(T)))
                {
                    ((IBaseEntity)entity).DeletedAt = DateTimeOffset.Now;
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
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            try
            {
                if (typeof(IBaseEntity).IsAssignableFrom(typeof(T)))
                {
                    ((IBaseEntity)entity).UpdatedAt = DateTimeOffset.Now;
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

        public virtual async Task<bool> UpdateRange(T[] entities)
        {
            try
            {
                if (typeof(IBaseEntity).IsAssignableFrom(typeof(T)))
                {
                    entities = entities.Select(entity => { ((IBaseEntity)entity).UpdatedAt = DateTimeOffset.Now; return entity; }).ToArray();
                }
                DbSet.UpdateRange(entities);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update Range function error.", typeof(T));
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
                        ((IBaseEntity)entity).CreatedAt = DateTimeOffset.Now;
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

        public async Task<bool> RemoveRange(T[] entities, bool softDelete = true)
        {
            try
            {
                var ids = entities.Select(x => ((IBaseEntity)x).Id);

                var existList = DbSet.Where(x => ids.Contains(((IBaseEntity)x).Id));

                if (entities.Length != existList.Count()) return false;

                if (softDelete)
                {
                    var deleteEntities = entities.Select(x => { ((IBaseEntity)x).DeletedAt = DateTimeOffset.Now; return x; });
                    DbSet.UpdateRange(deleteEntities);
                }
                else
                {
                    DbSet.RemoveRange(entities);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Remove Range function error.", typeof(T));
                return false;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}