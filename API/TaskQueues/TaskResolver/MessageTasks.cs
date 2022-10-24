//using API.Services.Constract;
//using Domain.Shares.Enums;
//using Newtonsoft.Json;
//using StackExchange.Redis;

//namespace API.TaskQueues.TaskResolver
//{
//    public class MessageTasks : BaseTaskResolver
//    {
//        public const string SUPPORT_MESSAGE_QUEUE = "Support_Message";
//        public const string ADMIN_QUEUE = "Admin";

//        public MessageTasks(IServiceProvider serviceProvider) : base(serviceProvider)
//        {

//        }

//        public override async Task Solve()
//        {
//            var roomService = ServiceProvider.GetRequiredService<IRoomService>();
//            var redisMQService = ServiceProvider.GetRequiredService<IRedisMQService>();

//            var subscriber = redisMQService.GetSubscriber();

//            subscriber.Subscribe(SUPPORT_MESSAGE_QUEUE).OnMessage(async (msg) =>
//            {
//                var admin = await redisMQService.GetValue(ADMIN_QUEUE);

//                if (admin == null) return;

//                var task = await redisMQService.GetValue(SUPPORT_MESSAGE_QUEUE);

//                var userCode = JsonConvert.DeserializeObject<Guid>(task);

//                var adminCode = JsonConvert.DeserializeObject<Guid>(admin);

//                var result = false;

//                while (!result)
//                {
//                    result = (await roomService.Create(new List<Guid> { userCode, adminCode }, Rooms.RoomTypes.Support)) != null;
//                }

//                await redisMQService.Push(ADMIN_QUEUE, adminCode);
//            });

//            subscriber.Subscribe(ADMIN_QUEUE).OnMessage(async (msg) =>
//            {
//                var task = await redisMQService.GetValue(SUPPORT_MESSAGE_QUEUE);

//                if (task == null) return;

//                var admin = await redisMQService.GetValue(ADMIN_QUEUE);

//                var userCode = JsonConvert.DeserializeObject<Guid>(task);

//                var adminCode = JsonConvert.DeserializeObject<Guid>(admin);

//                var result = false;

//                while (!result)
//                {
//                    result = (await roomService.Create(new List<Guid> { userCode, adminCode }, Rooms.RoomTypes.Support)) != null;
//                }

//                await redisMQService.Push(ADMIN_QUEUE, adminCode);
//            });
//        }
//    }
//}
