using API.Services.Constract;
using API.SignalR.Constract;
using Domain.Entities;
using Domain.Shares.Enums;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace API.TaskQueues.TaskResolver
{
    public class MappingBookingTask : BaseTaskResolver
    {
        public readonly static string BOOKING_QUEUE = "BookingPending";
        private BlockingCollection<int> currentJobs = new BlockingCollection<int>(boundedCapacity: 100);

        public MappingBookingTask(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override Task Solve()
        {
            var subscriber = _appService.RedisMQ.GetSubscriber();

            var thread = new Thread(new ThreadStart(
                async () => 
                {
                    foreach(var id in currentJobs.GetConsumingEnumerable())
                    {                       
                        var booking = await _appService.Booking.Mapping(id);

                        if(booking != null)
                        {
                            var isMappedSuccess = booking.BookingDetails.Any(bd => bd.Status == BookingDetails.Status.Ready);
                            await _appService.SignalR.SendToUserAsync(booking.User.Code.ToString(), "BookingMappingResult", new { Code = booking.Code, IsMappedSuccess = isMappedSuccess });

                            if (!isMappedSuccess)
                            {
                                booking.Status = Bookings.Status.CancelledBySystem;
                                // implement refund when can not mapping
                            }
                            else booking.Status = Bookings.Status.Started;
                            if (!_appService.Booking.Update(booking).Result)
                                throw new Exception("Fail to update booking after mapping");
                        }
                        else
                        {
                            throw new Exception("Exist null booking in mapping task");
                        } 
                    }
                }
                ));

            thread.IsBackground = true;
            thread.Start();

            subscriber.Subscribe(BOOKING_QUEUE).OnMessage((channelMsg) =>
            {
                var id = JsonConvert.DeserializeObject<int>(channelMsg.Message);

                while (!currentJobs.TryAdd(id, TimeSpan.FromMilliseconds(1000)));
            });

            return Task.CompletedTask;
        }
    }
}
