using StackExchange.Redis;

namespace API.TaskQueues.TaskResolver
{
    public abstract class BaseTaskResolver : ITaskResolver
    {
        protected IServiceProvider _serviceProvider;
        protected IRedisMQService _redisMQService;
        //protected ISubscriber subscriber;
        public BaseTaskResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            //_redisMQService = _serviceProvider.GetRequiredService<IRedisMQService>();
            //subscriber = _redisMQService.GetSubscriber();
        }

        public CancellationToken ApplicationStarted => throw new NotImplementedException();

        public CancellationToken ApplicationStopped => throw new NotImplementedException();

        public CancellationToken ApplicationStopping => throw new NotImplementedException();

        public abstract Task Solve();
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _serviceProvider = _serviceProvider.CreateScope().ServiceProvider;
            //_redisMQService = _serviceProvider.GetRequiredService<IRedisMQService>();
            //subscriber = _redisMQService.GetSubscriber();
            await Solve();
        }

        public void StopApplication()
        {
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
