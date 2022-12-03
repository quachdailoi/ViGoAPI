using API.Models.DTO;
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
        public readonly static string MAPPING_QUEUE = "BookingPending";
        private BlockingCollection<MappingItemDTO> currentJobs = new BlockingCollection<MappingItemDTO>(boundedCapacity: 100);

        public MappingBookingTask(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override Task Solve(IServiceProvider serviceProvider)
        {
            var _appService = serviceProvider.GetRequiredService<IAppServices>();
            var _logger = serviceProvider.GetRequiredService<ILogger<MappingBookingTask>>();
            var subscriber = _appService.RedisMQ.GetSubscriber();

            var thread = new Thread(new ThreadStart(
                async () => 
                {
                    foreach(var item in currentJobs.GetConsumingEnumerable())
                    {
                        try
                        {
                            switch (item.Type)
                            {
                                case TaskItems.MappingItemTypes.Booking:
                                    var booking = await _appService.Booking.MappingBooking(item.Id, item.SpecificMappingId);
                                    if (booking != null)
                                    {
                                        var isMappedSuccess = booking.BookingDetails.Any(bd => bd.Status == BookingDetails.Status.Ready);

                                        //updating for defining condition checking for mapping success
                                        if (isMappedSuccess) await _appService.SignalR.SendToUserAsync(booking.User.Code.ToString(), "BookingMappingResult", new { Code = booking.Code, IsMappedSuccess = isMappedSuccess });

                                        //if (!isMappedSuccess)
                                        //{
                                        //    booking.Status = Bookings.Status.CancelledBySystem;
                                        //    // implement refund when can not mapping
                                        //}
                                        //else booking.Status = Bookings.Status.Started;

                                        booking.Status = Bookings.Status.Started;
                                        if (!_appService.Booking.Update(booking).Result)
                                            throw new Exception("Fail to update booking after mapping");
                                    }
                                    break;
                                case TaskItems.MappingItemTypes.RouteRoutine:
                                    var routeRoutine = await _appService.Booking.MappingRouteRoutine(item.Id);
                                    if (routeRoutine != null)
                                    {
                                        if (!_appService.RouteRoutine.Update(routeRoutine).Result)
                                            throw new Exception("Fail to update route routine after mapping");
                                    }
                                    break;
                                case TaskItems.MappingItemTypes.BookingDetail:
                                    var bookingDetail = await _appService.Booking.MappingBookingDetail(item.Id);
                                    if (bookingDetail != null)
                                    {
                                        if (!_appService.BookingDetail.UpdateBookingDetail(bookingDetail).Result)
                                            throw new Exception("Fail to update booking detail after re-mapping");
                                    }
                                    break;
                                case TaskItems.MappingItemTypes.CancelBooking:
                                    await _appService.Booking.MappingRouteRoutineAfterCancelBooking(item.Id);
                                    break;
                            }
                        }
                        catch(Exception ex)
                        {
                            _logger.LogError(ex, "Error occurred executing {MappingTaskItem}.", nameof(item));
                        }
                    }
                }
                ));

            thread.IsBackground = true;
            thread.Start();

            subscriber.Subscribe(MAPPING_QUEUE).OnMessage((channelMsg) =>
            {
                var item = JsonConvert.DeserializeObject<MappingItemDTO>(channelMsg.Message);

                while (!currentJobs.TryAdd(item, TimeSpan.FromMilliseconds(1000)));
            });

            return Task.CompletedTask;
        }
    }
}
