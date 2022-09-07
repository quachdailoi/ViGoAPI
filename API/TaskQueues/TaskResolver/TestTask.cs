namespace API.TaskQueues.TaskResolver
{
    public class TestTask : BaseTaskResolver
    {
        public TestTask(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override async Task Solve()
        {
            subscriber.Subscribe("1").OnMessage((msg) =>
            {
                Console.WriteLine(msg);
            });
        }
    }
}
