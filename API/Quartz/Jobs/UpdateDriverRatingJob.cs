using API.Services.Constract;
using Quartz;

namespace API.Quartz.Jobs
{
    public class UpdateDriverRatingJob : IJob
    {
        private readonly IServiceProvider _serviceProvider;

        public UpdateDriverRatingJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"UpdateDriverRatingJob is running - {DateTimeOffset.Now}");

            using var scope = _serviceProvider.CreateScope();
            var appService = scope.ServiceProvider.GetRequiredService<IAppServices>();
            await appService.Driver.UpdateDriverRatingAndCancelledTripRate();

            Console.WriteLine($"UpdateDriverRatingJob is completed - {DateTimeOffset.Now}");
        }
    }
}
