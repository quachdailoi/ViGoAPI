using API.Services.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace API.SignalR
{
    public class GPSTrackingStream : Hub
    {
        public static Dictionary<Roles, Dictionary<Guid, Coordinates>> dic = new();
        private delegate TResult GetWriterItems<TResult,TData>(TData data);
        private readonly int delay = 1000;
        private readonly double radiusLimit = 3000; // meters

        private readonly ILocationService _locationService;
        public GPSTrackingStream(ILocationService locationService)
        {
            _locationService = locationService;
        }

        private ChannelReader<List<Coordinates>> GetNearByLocation(Guid userCode,CancellationToken cancellationToken)
        {
            var channel = Channel.CreateUnbounded<List<Coordinates>>();

            GetWriterItems<List<Coordinates>, Guid> getWritterItems = new((userCode) =>
            {
                var coordinates = new List<Coordinates>();
                var driverCooridinates = dic[Roles.DRIVER]?.Values;
                var currentUserCoordinate = dic[Roles.BOOKER]?[userCode];

                if(driverCooridinates == null || !driverCooridinates.Any() || currentUserCoordinate == null) return coordinates;
                
                foreach(var driverCoordinate in driverCooridinates)
                {
                    if (ILocationService.CalculateDistanceAsTheCrowFlies(
                        currentUserCoordinate.Latitude, currentUserCoordinate.Longitude,
                        driverCoordinate.Latitude, driverCoordinate.Longitude) <= radiusLimit) coordinates.Add(driverCoordinate);
                }

                return coordinates;
            });

            _ = WriteItemsAsync<List<Coordinates>, Guid>(channel.Writer, getWritterItems, userCode, cancellationToken);

            return channel.Reader;
        }

        private ChannelReader<Coordinates?> GetByUserCode(Guid userCode, CancellationToken cancellationToken)
        {
            var channel = Channel.CreateUnbounded<Coordinates?>();

            GetWriterItems<Coordinates?,Guid> getWritterItems = new((userCode) => dic[Roles.DRIVER]?[userCode]);

            _ = WriteItemsAsync<Coordinates?, Guid>(channel.Writer, getWritterItems, userCode, cancellationToken);

            return channel.Reader;
        }

        private async Task WriteItemsAsync<TResult,TData>(
            ChannelWriter<TResult> writer,
            GetWriterItems<TResult,TData> getWriterItems,
            TData data,
            CancellationToken cancellationToken)
        {
            Exception localException = null;
            try
            {
                while (true)
                {
                    var result = getWriterItems(data);
                    await writer.WriteAsync(result, cancellationToken);
                    await Task.Delay(delay, cancellationToken);
                }

            }
            catch (Exception ex)
            {
                localException = ex;
            }
            finally
            {
                writer.Complete(localException);
            }
        }

        private async Task StreamGPS(ChannelReader<UserCoordinates> stream)
        {
            while (await stream.WaitToReadAsync())
            {
                while (stream.TryRead(out var item))
                {
                    var roleDic = dic[item.Role];
                    if(roleDic == null)
                    {
                        dic.Add(item.Role, new());
                    }
                    dic[item.Role][item.Code] = item.Coordinates;
                }
            }
        }

        public class Coordinates
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        public class UserCoordinates
        {
            public Roles Role { get; set; }
            public Guid Code { get; set; }
            public Coordinates Coordinates { get; set; }
        }
    }
    //public class TestStreamHub : StreamHub<int>
    //{

    //}
    //public class StreamHub<T> : Hub
    //{
    //    //public async IAsyncEnumerable<T> Counter(
    //    //    T data,
    //    //    int delay,
    //    //    [EnumeratorCancellation]
    //    //    CancellationToken cancellationToken)
    //    //{
    //    //    for(var i = 0; i < 1000; i++)
    //    //    {
    //    //        cancellationToken.ThrowIfCancellationRequested();

    //    //        yield return data;

    //    //        await Task.Delay(delay, cancellationToken);
    //    //    }  
    //    //}
    //    public static ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
    //    public ChannelReader<T> Counter(
    //        T data,
    //        int delay,
    //        CancellationToken cancellationToken)
    //    {
    //        var channel = Channel.CreateUnbounded<T>();

    //        _ = WriteItemsAsync(channel.Writer, data, delay, cancellationToken);

    //        return channel.Reader;
    //    }

    //    public async Task WriteItemsAsync(
    //        ChannelWriter<T> writer,
    //        T data,
    //        int delay,
    //        CancellationToken cancellationToken)
    //    {
    //        Exception localException = null;
    //        try
    //        {
    //            while (true)
    //            {
    //                if (queue.TryDequeue(out T? result))
    //                {
    //                    await writer.WriteAsync(result, cancellationToken);
    //                }
    //                await Task.Delay(delay, cancellationToken);
    //            }
                
    //        }catch(Exception ex)
    //        {
    //            localException = ex;
    //        }
    //        finally
    //        {
    //            writer.Complete(localException);
    //        }
    //    }
    //    public async Task UploadStream(ChannelReader<T> stream)
    //    {
    //        while(await stream.WaitToReadAsync())
    //        {
    //            while(stream.TryRead(out var item))
    //            {
    //                queue.Enqueue(item);
    //            }
    //        }
    //    }

    //}
}
