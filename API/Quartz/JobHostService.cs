using Quartz.Spi;

namespace API.Quartz
{
    public class JobHostService : IHostedService
    {
        private readonly IJobScheduler _jobScheduler;
        public JobHostService(IJobScheduler jobScheduler)
        {
            _jobScheduler = jobScheduler;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _jobScheduler.CheckingMappingJob();
            await _jobScheduler.RunTestJob();
            await _jobScheduler.NotifyTripJob();
            await _jobScheduler.UpdateDriverRatingJob();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _jobScheduler.GetScheduler()?.Shutdown(cancellationToken);
        }
    }
}
