using API.Services.Constract;
using AutoMapper;
using Domain.Interfaces.UnitOfWork;
using Microsoft.Extensions.Caching.Distributed;

namespace API.Services
{
    public abstract class BaseService
    {
        protected IAppServices AppServices { get; private set; }

        public BaseService(IAppServices appServices)
        {
            AppServices = appServices;

            UnitOfWork = Load<IUnitOfWork>();

            Mapper = Load<IMapper>();
            
            Cache = Load<IDistributedCache>();

            Configuration = Load<IConfiguration>();

            Context = Load<IHttpContextAccessor>();
        }

        protected IUnitOfWork UnitOfWork { get; private set; }
        public ILogger<T> Logger<T>() where T : class => Load<ILogger<T>>();
        protected IMapper Mapper { get; private set; }
        protected IDistributedCache Cache { get; private set; }
        protected IConfiguration Configuration { get; private set; }
        protected IHttpContextAccessor Context { get; private set; }

        private TT Load<TT>() where TT : class => AppServices.Provider.GetRequiredService<TT>();
    }
}
