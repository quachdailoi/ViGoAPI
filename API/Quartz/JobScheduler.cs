using API.Quartz.Jobs;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace API.Quartz
{
    public interface IJobScheduler
    {
        Task StartMessageJob<T>(string room, object message, string cronSchedule) where T : IJob;
        Task UpdateDriverRatingJob();
        Task CheckingMappingJob();
        Task NotifyTripJob();
        Task RunTestJob();
        IScheduler? GetScheduler();
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

        public async Task UpdateDriverRatingJob()
        {
            var cronSchedule1 = Utils.CronExpression.ParseFromSpecificTimeOnlyDaily(new TimeOnly(12, 0));
            var cronSchedule2 = Utils.CronExpression.ParseFromSpecificTimeOnlyDaily(new TimeOnly(0, 0));

            IJobDetail jobDetail = JobBuilder.Create<UpdateDriverRatingJob>()
                .WithIdentity("UpdateDriverRatingJob")
                .Build();

            ITrigger trigger1 = TriggerBuilder.Create()
                .WithIdentity("UpdateDriverRatingJob1")
                .StartNow()
                .WithCronSchedule(cronSchedule1)
                .Build();

            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity("UpdateDriverRatingJob2")
                .StartNow()
                .WithCronSchedule(cronSchedule2)
                .ForJob(jobDetail)
                .Build();

            await _scheduler.ScheduleJob(jobDetail, trigger1);
            await _scheduler.ScheduleJob(trigger2);
            await _scheduler.Start();
        }

        public async Task CheckingMappingJob()
        {
            var cronSchedule = Utils.CronExpression.ParseFromSpecificTimeOnlyDaily(new TimeOnly(20,00));

            IJobDetail jobDetail = JobBuilder.Create<CheckingMappingJob>()
                .WithIdentity("CheckingMappingJobIdentity")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("CheckingMappingJobIdentity")
                .StartNow()
                .WithCronSchedule(cronSchedule)
                .Build();

            await _scheduler.ScheduleJob(jobDetail, trigger);
            await _scheduler.Start();
        }

        public async Task NotifyTripJob()
        {
            var cronSchedule = Utils.CronExpression.ParseFromSpecificTimeOnlyDaily(new TimeOnly(6, 00));

            IJobDetail jobDetail = JobBuilder.Create<NotifyTripJob>()
                .WithIdentity("NotifyTripJobIdentity")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("NotifyTripJobIdentity")
                .StartNow()
                .WithCronSchedule(cronSchedule)
                .Build();

            await _scheduler.ScheduleJob(jobDetail, trigger);
            await _scheduler.Start();
        }

        public IScheduler? GetScheduler() => this._scheduler;

        public async Task RunTestJob()
        {
            var cronSchedule0 = Utils.CronExpression.ParseFromSpecificTimeOnlyDaily(new TimeOnly(10,00));

            var cronSchedule1 = Utils.CronExpression.ParseFromSpecificTimeOnlyDaily(new TimeOnly(9, 55));

            var cronSchedule2 = Utils.CronExpression.ParseFromSpecificTimeOnlyDaily(new TimeOnly(9, 50));

            var cronSchedule3 = Utils.CronExpression.ParseFromSpecificTimeOnlyDaily(new TimeOnly(9, 45));

            IJobDetail jobDetail = JobBuilder.Create<TestJob>()
                .WithIdentity("Test")
                .Build();

            ITrigger trigger0 = TriggerBuilder.Create()
                .WithIdentity("Test0")
                .StartNow()
                .WithCronSchedule(cronSchedule0)
                .Build();

            ITrigger trigger1 = TriggerBuilder.Create()
                .WithIdentity("Test1")
                .StartNow()
                .WithCronSchedule(cronSchedule1)
                .ForJob(jobDetail)
                .Build();

            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity("Test2")
                .StartNow()
                .WithCronSchedule(cronSchedule2)
                .ForJob(jobDetail)
                .Build();

            ITrigger trigger3 = TriggerBuilder.Create()
                .WithIdentity("Test3")
                .StartNow()
                .WithCronSchedule(cronSchedule3)
                .ForJob(jobDetail)
                .Build();

            await _scheduler.ScheduleJob(jobDetail,trigger0);
            await _scheduler.ScheduleJob(trigger1);
            await _scheduler.ScheduleJob(trigger2);
            await _scheduler.ScheduleJob(trigger3);
            await _scheduler.Start();
        }
    }
}
