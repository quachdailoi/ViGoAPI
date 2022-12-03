using API.Services.Constract;
using Quartz;

namespace API.Quartz.Jobs
{
    public class NotifyTripJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;

        public NotifyTripJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"NotifyTripJob is running - {DateTimeOffset.Now}");

            using var scope = _serviceProvider.CreateScope();
            var appService = scope.ServiceProvider.GetRequiredService<IAppServices>();
            try
            {
                await appService.BookingDetail.CheckingExistTripInDay();
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"===> {ex.Message}");
            }

            Console.WriteLine($"NotifyTripJob is completed - {DateTimeOffset.Now}");
        }
    }
}
