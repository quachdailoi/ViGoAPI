using API.JwtFeatures;
using API.Services.Constract;
using Domain.Shares.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace API.SignalR
{
    public class GpsTrackingStream : Hub
    {
        public static Dictionary<string, Dictionary<Guid, Coordinates>> dic = new();
        public static Dictionary<Guid, HashSet<string>> connectionIdDic = new();
        private delegate TResult GetWriterItems<TResult, TData>(TData data);
        private readonly int delay = 1000;
        private readonly double radiusLimit = 3000; // meters

        private readonly ILocationService _locationService;
        private readonly IJwtHandler _jwtHandler;
        public GpsTrackingStream(ILocationService locationService, IJwtHandler jwtHandler)
        {
            _locationService = locationService;
            _jwtHandler = jwtHandler;
        }

        [Authorize(Roles = "BOOKER")]
        public ChannelReader<List<Coordinates>> GetNearByLocation(Coordinates coordinate, CancellationToken cancellationToken)
        {
            var channel = Channel.CreateUnbounded<List<Coordinates>>();

            GetWriterItems<List<Coordinates>, Coordinates> getWritterItems = new((userCode) =>
            {
                var coordinates = new List<Coordinates>();
                var driverCooridinates = dic[Roles.DRIVER.GetString()]?.Values;

                if (driverCooridinates == null || !driverCooridinates.Any()) return coordinates;

                foreach (var driverCoordinate in driverCooridinates)
                {
                    if (ILocationService.CalculateDistanceAsTheCrowFlies(
                        coordinate.Latitude, coordinate.Longitude,
                        driverCoordinate.Latitude, driverCoordinate.Longitude) <= radiusLimit) coordinates.Add(driverCoordinate);
                }

                return coordinates;
            });

            _ = WriteItemsAsync<List<Coordinates>, Coordinates>(channel.Writer, getWritterItems, coordinate, cancellationToken);

            return channel.Reader;
        }

        [Authorize(Roles = "BOOKER")]
        public ChannelReader<Coordinates?> GetByUserCode(Guid userCode, CancellationToken cancellationToken)
        {
            var channel = Channel.CreateUnbounded<Coordinates?>();

            GetWriterItems<Coordinates?, Guid> getWritterItems = new((userCode) =>
            {
                if (dic.TryGetValue(Roles.DRIVER.ToString(), out var userDic))
                {
                    if (userDic.TryGetValue(userCode, out var coordinate))
                    {
                        return coordinate;
                    }
                }

                return null;
            });

            _ = WriteItemsAsync(channel.Writer, getWritterItems, userCode, cancellationToken);

            return channel.Reader;
        }

        private async Task WriteItemsAsync<TResult, TData>(
            ChannelWriter<TResult> writer,
            GetWriterItems<TResult, TData> getWriterItems,
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

        [Authorize(Roles = "DRIVER")]
        public async Task StreamGps(ChannelReader<Coordinates> stream)
        {
            var token = Context.GetHttpContext()?.Request.Query["access_token"].FirstOrDefault();

            var user = _jwtHandler.GetUserViewModelByToken(token);

            if(connectionIdDic.TryGetValue(user.Code, out var connectionSet))
            {
                connectionSet.Add(Context.ConnectionId);
            }
            else
            {
                connectionIdDic[user.Code] = new HashSet<string> { Context.ConnectionId };
            }

            while (await stream.WaitToReadAsync())
            {
                while (stream.TryRead(out var coordinate))
                {
                    if (dic.TryGetValue(user.RoleName, out var userDic))
                    {
                        userDic[user.Code] = coordinate;
                    }
                    else
                    {
                        dic[user.RoleName] = new Dictionary<Guid, Coordinates> {{user.Code,coordinate }};
                    }                  
                }
            }

            RemoveFromUserCoordinateDic(user.Code);
        }

        public override Task OnConnectedAsync()
        {           
            return base.OnConnectedAsync();
        }

        private void RemoveFromUserCoordinateDic(Guid userCode)
        {
            if(dic.TryGetValue(Roles.DRIVER.ToString(), out var userDic)){
                userDic.Remove(userCode);
            }
        }
        private void RemoveFromConnectionIdDic()
        {
            var set = connectionIdDic.Where(e => e.Value.Contains(Context.ConnectionId)).FirstOrDefault();

            if (set.Value != null)
            {
                set.Value.Remove(Context.ConnectionId);

                if (!set.Value.Any())
                {
                    connectionIdDic.Remove(set.Key);
                    dic[Roles.DRIVER.ToString()]?.Remove(set.Key);
                }
                else
                    connectionIdDic[set.Key] = set.Value;
            }
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            RemoveFromConnectionIdDic();
            return base.OnDisconnectedAsync(exception);
        }

        public class Coordinates
        {
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }
    }
}
