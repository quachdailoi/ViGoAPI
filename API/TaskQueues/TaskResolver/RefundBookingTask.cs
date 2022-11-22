using API.Models.DTO;
using API.Services.Constract;
using Domain.Shares.Enums;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace API.TaskQueues.TaskResolver
{
    public class RefundBookingTask : BaseTaskResolver
    {
        public readonly static string REFUND_QUEUE = "RefundQueue";
        private BlockingCollection<RefundItemDTO> currentJobs = new BlockingCollection<RefundItemDTO>();

        public RefundBookingTask(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        public override Task Solve(IServiceProvider serviceProvider)
        {
            var _appService = serviceProvider.GetRequiredService<IAppServices>();
            var _logger = serviceProvider.GetRequiredService<ILogger<RefundBookingTask>>();
            var subscriber = _appService.RedisMQ.GetSubscriber();

            var thread = new Thread(new ThreadStart(
                async () =>
                {
                    foreach (var item in currentJobs.GetConsumingEnumerable())
                    {
                        try
                        {
                            bool? result = null;
                            switch (item.Type)
                            {
                                case TaskItems.RefundItemTypes.Booking:
                                    result = await _appService.Booking.Refund(item.Code);
                                    break;
                                case TaskItems.RefundItemTypes.BookingDetail:
                                    result = await _appService.BookingDetail.Refund(item.Code, item.Amount.Value, BookingDetails.RefundTypes.NotFoundDriver);
                                    break;
                                case TaskItems.RefundItemTypes.TripSharing:
                                    result = await _appService.BookingDetail.Refund(item.Code, item.Amount.Value);
                                    break;
                                default: break;
                            }

                            if (result.HasValue && !result.Value)
                                currentJobs.TryAdd(item, TimeSpan.FromMilliseconds(1000));
                        }
                        catch(Exception ex)
                        {
                            _logger.LogError(ex, "Error occurred executing {RefundTaskItem}.", nameof(item));
                        }
                        
                    }
                }
                ));

            thread.IsBackground = true;
            thread.Start();

            subscriber.Subscribe(REFUND_QUEUE).OnMessage((channelMsg) =>
            {
                var item = JsonConvert.DeserializeObject<RefundItemDTO>(channelMsg.Message);

                while (!currentJobs.TryAdd(item, TimeSpan.FromMilliseconds(1000))) ;
            });

            return Task.CompletedTask;
        }
    }
}
