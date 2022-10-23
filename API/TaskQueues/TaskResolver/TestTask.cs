//using System.Collections.Concurrent;

//namespace API.TaskQueues.TaskResolver
//{
//    public class TestTask : BaseTaskResolver
//    {
//        private BlockingCollection<int> currentJobs = new BlockingCollection<int>();
//        public TestTask(IServiceProvider serviceProvider) : base(serviceProvider)
//        {
//        }

//        public override async Task Solve()
//        {
//            var redisMQService = ServiceProvider.GetRequiredService<IRedisMQService>();

//            var subscriber = redisMQService.GetSubscriber();

//            var thread = new Thread(new ThreadStart(
//                () =>
//                {
//                    foreach(var job in currentJobs.GetConsumingEnumerable())
//                    {
//                        for (int i = 1; i <= 10; i++)
//                        {
//                            Thread.Sleep(1000);
//                            Console.Write(job + ", ");
//                        }
//                        Console.WriteLine();
//                    }                                
//                }));
//            thread.IsBackground = true;
//            thread.Start();

//            subscriber.Subscribe("number").OnMessage((msg) =>
//            {
//                var number = int.Parse(msg.Message);
//                while (!currentJobs.TryAdd(number, TimeSpan.FromMilliseconds(100)));
//                Console.WriteLine(number + " has been add");
//            });
//        }
//    }
//}
