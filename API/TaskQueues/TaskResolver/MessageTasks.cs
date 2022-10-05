using API.Services.Constract;
using Domain.Shares.Enums;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace API.TaskQueues.TaskResolver
{
    public class MessageTasks : BaseTaskResolver
    {
        public const string SUPPORT_MESSAGE_QUEUE = "Support_Message";
        public const string ADMIN_QUEUE = "Admin";

        public MessageTasks(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override async Task Solve()
        {
            var _roomService = _serviceProvider.GetRequiredService<IRoomService>();

            subscriber.Subscribe(SUPPORT_MESSAGE_QUEUE).OnMessage(async (msg) =>
            {
                var admin = await _redisMQService.GetValue(ADMIN_QUEUE);

                if (admin == null) return;

                var task = await _redisMQService.GetValue(SUPPORT_MESSAGE_QUEUE);

                var userCode = JsonConvert.DeserializeObject<Guid>(task);

                var adminCode = JsonConvert.DeserializeObject<Guid>(admin);

                var result = false;

                while (!result)
                {
                    result = (await _roomService.Create(new List<Guid> { userCode, adminCode }, MessageRoomTypes.Support)) != null;
                }

                await _redisMQService.Push(ADMIN_QUEUE, adminCode);
            });

            subscriber.Subscribe(ADMIN_QUEUE).OnMessage(async (msg) =>
            {
                var task = await _redisMQService.GetValue(SUPPORT_MESSAGE_QUEUE);

                if (task == null) return;

                var admin = await _redisMQService.GetValue(ADMIN_QUEUE);

                var userCode = JsonConvert.DeserializeObject<Guid>(task);

                var adminCode = JsonConvert.DeserializeObject<Guid>(admin);

                var result = false;

                while (!result)
                {
                    result = (await _roomService.Create(new List<Guid> { userCode, adminCode }, MessageRoomTypes.Support)) != null;
                }

                await _redisMQService.Push(ADMIN_QUEUE, adminCode);
            });
        }
    }
}
