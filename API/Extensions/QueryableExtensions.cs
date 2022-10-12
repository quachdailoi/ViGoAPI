using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace API.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            return query;

        }

        public static IQueryable<T> MapTo<T>(this IQueryable query, IMapper mapper, object? service = null)
            where T : class
        {
            return query.ProjectTo<T>(mapper.ConfigurationProvider, new {service = service});
        }
    }
}
