using API.Services.Constract;
using Quartz;

namespace API.Quartz.Jobs
{
    public class CheckingMappingJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;

        public CheckingMappingJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"CheckingMappingJob is running - {DateTimeOffset.Now}");

            using var scope = _serviceProvider.CreateScope();
            var appService = scope.ServiceProvider.GetRequiredService<IAppServices>();
            await appService.BookingDetail.CheckingMappingStatus();

            Console.WriteLine($"CheckingMappingJob is completed - {DateTimeOffset.Now}");
        }
    }
}
