namespace API.TaskQueues.TaskResolver
{
    public interface ITaskResolver : IHostedService
    {
        Task Solve(IServiceProvider serviceProvider);
    }
}
