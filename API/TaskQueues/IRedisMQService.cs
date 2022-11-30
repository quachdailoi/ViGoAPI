using API.Extensions;
using API.Models.Settings;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace API.TaskQueues
{
    public interface IRedisMQService
    {
        Task<long> Publish(string key, object obj);
        ChannelMessageQueue GetChannel(string key);
        ISubscriber GetSubscriber();
        Task<long> Push(string key, object obj);
        Task<RedisValue?> GetValue(string key);
        Task<bool> IsEmptyQueue(string key);
    }
    public class RedisMQService : IRedisMQService
    {
        private readonly ConnectionMultiplexer _connection;

        public RedisMQService(IConfiguration configuration)
        {
            _connection = ConnectionMultiplexer.Connect(configuration.Get(BaseSettings.RedisConnectionString));
        }

        public ChannelMessageQueue GetChannel(string key)
        {
            return _connection.GetSubscriber().Subscribe(key);
        }

        public ISubscriber GetSubscriber()
        {
            return _connection.GetSubscriber();
        }

        public async Task<RedisValue?> GetValue(string key)
        {
            return await _connection.GetDatabase().ListLeftPopAsync(key);
        }

        public async Task<bool> IsEmptyQueue(string key)
        {
            var length = await _connection.GetDatabase().ListLengthAsync(key);
            return  length == 0;
        }

        public Task<long> Publish(string key, object obj)
        {
            return _connection.GetDatabase().PublishAsync(key, JsonConvert.SerializeObject(obj));
        }

        public Task<long> Push(string key, object obj)
        {
            return _connection.GetDatabase().ListRightPushAsync(key, JsonConvert.SerializeObject(obj));
        }
    }
}
