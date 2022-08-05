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

        public static IQueryable<T> MapTo<T>(this IQueryable query, IMapper mapper)
            where T : class
        {
            return query.ProjectTo<T>(mapper.ConfigurationProvider);
        }

        //public static IQueryable<TDestination> ProjectTo<TDestination>(
        //    this IQueryable source,
        //    IConfigurationProvider configuration)
        // => new ProjectionExpression(source, configuration.)
        //.To<TDestination>();
    }
    //public class ProjectionExpression
    //{
    //    private readonly Expression expression;
    //    private readonly IQueryable _source;
    //    private readonly Microsoft.Extensions.Configuration.IConfigurationProvider _configuration;
    //    public IQueryable<TResult> To<TResult>()
    //    {
    //        return (IQueryable<TResult>)_configuration. .GetMapExpression(
    //                _source.ElementType,
    //                typeof(TResult))
    //            .Aggregate(_source, Select);
    //    }
    //}
}
