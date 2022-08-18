using AutoMapper;
using Domain.Entities;

namespace API.Extensions
{
    public static class EntityExtensions
    {
        public static TViewModel? MapTo<TViewModel, TEntity>(this TEntity entity, IMapper mapper)
        {
            var x = (new[] { entity }).AsQueryable();
            
            return mapper.ProjectTo<TViewModel>(x).FirstOrDefault();
        }
    }
}
