using API.Services.Constract;
using StackExchange.Redis;

namespace API.TaskQueues.TaskResolver
{
    public abstract class BaseTaskResolver : ITaskResolver
    {
        protected IServiceProvider _serviceProvider { get; private set; }
        protected IAppServices? _appService { get; private set; } = null;
        public BaseTaskResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider.CreateScope().ServiceProvider;
            //_redisMQService = _serviceProvider.GetRequiredService<IRedisMQService>();
            //subscriber = _redisMQService.GetSubscriber();
        }

        public CancellationToken ApplicationStarted => throw new NotImplementedException();

        public CancellationToken ApplicationStopped => throw new NotImplementedException();

        public CancellationToken ApplicationStopping => throw new NotImplementedException();

        public abstract Task Solve();
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if(_appService == null) 
                _appService = _serviceProvider.GetRequiredService<IAppServices>(); 
            //_redisMQService = _serviceProvider.GetRequiredService<IRedisMQService>();
            //subscriber = _redisMQService.GetSubscriber();
            await Solve();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public void Dispose()
        {

        }
    }
}
