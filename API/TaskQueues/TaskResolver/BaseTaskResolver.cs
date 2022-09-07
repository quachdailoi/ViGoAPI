using StackExchange.Redis;

namespace API.TaskQueues.TaskResolver
{
    public abstract class BaseTaskResolver : ITaskResolver
    {
        protected IServiceProvider _serviceProvider;
        protected IRedisMQService _redisMQService;
        protected ISubscriber subscriber;
        public BaseTaskResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            //_redisMQService = _serviceProvider.GetRequiredService<IRedisMQService>();
            //subscriber = _redisMQService.GetSubscriber();
        }
        public abstract Task Solve();
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _serviceProvider = _serviceProvider.CreateScope().ServiceProvider;
            _redisMQService = _serviceProvider.GetRequiredService<IRedisMQService>();
            subscriber = _redisMQService.GetSubscriber();
            await Solve();
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
