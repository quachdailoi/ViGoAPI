using Quartz;

namespace API.Quartz.Jobs
{
    public class TestJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Job test at {DateTimeOffset.Now}");

            return Task.CompletedTask;
        }
    }
}
