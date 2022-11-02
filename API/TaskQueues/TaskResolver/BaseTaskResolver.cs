using API.Services.Constract;
using StackExchange.Redis;

namespace API.TaskQueues.TaskResolver
{
    public abstract class BaseTaskResolver : ITaskResolver
    {
        private readonly IServiceProvider _serviceProvider;
        public BaseTaskResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            //_redisMQService = _serviceProvider.GetRequiredService<IRedisMQService>();
            //subscriber = _redisMQService.GetSubscriber();
        }

        public CancellationToken ApplicationStarted => throw new NotImplementedException();

        public CancellationToken ApplicationStopped => throw new NotImplementedException();

        public CancellationToken ApplicationStopping => throw new NotImplementedException();

        public abstract Task Solve(IServiceProvider serviceProvider);
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var scope = _serviceProvider.CreateScope();
            await Solve(scope.ServiceProvider);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
