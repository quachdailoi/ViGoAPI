using API.Extensions;
using API.Models.Responses;
using API.Services.Constract;
using AutoMapper;

namespace API.Services
{
    public static class PagingExtensions
    {
        public static PagingViewModel<IQueryable<T>>? Paging<T>(this IQueryable<T> list, int? page = null, int? pageSize = null)
        {
            if (list == null) return null;
            if (page == null) page = 1;
            if (pageSize == null) pageSize = 5;

            return new()
            {
                Items = list.Skip((int)((page - 1) * pageSize)).Take((int)pageSize),
                Page = (int) page,
                PageSize = (int) pageSize,
                TotalItemsCount = list.Count(),
                TotalPagesCount = (int)Math.Ceiling(list.Count() * 1.0 / (int)pageSize)
            };
        }

        public static PagingViewModel<IQueryable<TDes>>? PagingMap<T, TDes>(this IQueryable<T> list, IMapper mapper, int? page = null, int? pageSize = null, IAppServices? appServices = null)
            where TDes : class
        {
            if (list == null) return null;
            if (page == null) page = 1;
            if (pageSize == null) pageSize = 5;

            return new()
            {
                Items = list.Skip((int)((page - 1) * pageSize)).Take((int)pageSize).MapTo<TDes>(mapper, appServices),
                Page = (int)page,
                PageSize = (int)pageSize,
                TotalItemsCount = list.Count(),
                TotalPagesCount = (int)Math.Ceiling(list.Count() * 1.0 / (int)pageSize)
            };
        }

        public static PagingViewModel<IEnumerable<T>>? Paging<T>(this IEnumerable<T> list, int? page = null, int? pageSize = null)
        {
            if (list == null) return null;
            if (page == null) page = 1;
            if (pageSize == null) pageSize = 5;

            return new()
            {
                Items = list.Skip((int)((page - 1) * pageSize)).Take((int)pageSize),
                Page = (int) page,
                PageSize = (int) pageSize,
                TotalItemsCount = list.Count(),
                TotalPagesCount = (int)Math.Ceiling(list.Count() * 1.0 / (int)pageSize)
            };
        }
    }
}
