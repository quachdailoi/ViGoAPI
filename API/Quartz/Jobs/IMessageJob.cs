using API.SignalR.Constract;
using Quartz;

namespace API.Quartz.Jobs
{
    public interface IMessageJob : IJob
    {
    }

    public class MessageJob : IMessageJob
    {
        private readonly ISignalRService _signalRService;
        public MessageJob(ISignalRService signalRService)
        {
            _signalRService = signalRService;
        }
        public Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;

            var room = dataMap.GetString("room");
            var message = dataMap.Get("message");

            _signalRService.SendToUserAsync(room, "Message", message);

            return Task.CompletedTask;
        }
    }
}
