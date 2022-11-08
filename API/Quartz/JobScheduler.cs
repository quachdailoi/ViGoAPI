using API.Quartz.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace API.Quartz
{
    public interface IJobScheduler
    {
        Task StartMessageJob<T>(string room, object message, string cronSchedule) where T : IJob;
        Task UpdateDriverRatingJob(string cronSchedule);
        Task CheckingMappingJob(string cronSchedule);
        Task NotifyTripJob(string cronSchedule);
    }
    public class JobScheduler : IJobScheduler
    {
        IScheduler _scheduler;
        public JobScheduler(IJobFactory jobFactory)
        {
            _scheduler = new StdSchedulerFactory().GetScheduler().Result;
            _scheduler.JobFactory = jobFactory;
        }

        public async Task StartMessageJob<T>(string room, object message, string cronSchedule) where T : IJob
        {
            JobDataMap dataMap = new();

            dataMap.Add("message", message);
            dataMap.Add("room", room);

            IJobDetail jobDetail = JobBuilder.Create<T>()
                .UsingJobData(dataMap)
                .WithIdentity("SendMessageJobIdentity", room)
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("SendMessageTriggerIdentity", room)
                .StartNow()
                .WithCronSchedule(cronSchedule)
                .Build();


            await _scheduler.ScheduleJob(jobDetail, trigger);
            await _scheduler.Start();
        }

        public Task UpdateDriverRatingJob(string cronSchedule)
        {
            throw new NotImplementedException();
        }

        public Task CheckingMappingJob(string cronSchedule)
        {
            throw new NotImplementedException();
        }

        public Task NotifyTripJob(string cronSchedule)
        {
            throw new NotImplementedException();
        }
    }
}
