using API.Services.Constract;
using Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace API.TaskQueues.TaskResolver
{
    public class MappingBookingTask : BaseTaskResolver
    {
        public readonly static string BOOKING_QUEUE = "BookingPending";
        private BlockingCollection<Booking> currentJob = new BlockingCollection<Booking>(boundedCapacity: 1);

        public MappingBookingTask(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override async Task Solve()
        {
            var bookingService = _serviceProvider.GetRequiredService<IBookingService>();

            var thread = new Thread(new ThreadStart(
                async () => 
                {
                    if (currentJob.TryTake(out var booking))
                    {
                        await bookingService.Mapping(booking);
                    }
                }
                ));

            thread.IsBackground = true;
            thread.Start();

            subscriber.Subscribe(BOOKING_QUEUE).OnMessage((bookingSerialized) =>
            {
                var booking = JsonConvert.DeserializeObject<Booking>(bookingSerialized.Message);

                while (!currentJob.TryAdd(booking,TimeSpan.FromMilliseconds(1000)));
            });
        }
    }
}
