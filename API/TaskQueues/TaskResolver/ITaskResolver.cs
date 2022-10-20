namespace API.TaskQueues.TaskResolver
{
    public interface ITaskResolver : IHostedService, IDisposable
    {
        Task Solve();
    }
}
