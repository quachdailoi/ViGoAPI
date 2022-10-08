using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace API.SignalR
{
    public class StreamHub<T> : Hub where T : class
    {
        //public async IAsyncEnumerable<T> Counter(
        //    T data,
        //    int delay,
        //    [EnumeratorCancellation]
        //    CancellationToken cancellationToken)
        //{
        //    for(var i = 0; i < 1000; i++)
        //    {
        //        cancellationToken.ThrowIfCancellationRequested();

        //        yield return data;

        //        await Task.Delay(delay, cancellationToken);
        //    }  
        //}

        public ChannelReader<T> Counter(
            T data,
            int delay,
            CancellationToken cancellationToken)
        {
            var channel = Channel.CreateUnbounded<T>();

            _ = WriteItemsAsync(channel.Writer, data, delay, cancellationToken);

            return channel.Reader;
        }

        private async Task WriteItemsAsync(
            ChannelWriter<T> writer,
            T data,
            int delay,
            CancellationToken cancellationToken)
        {
            Exception localException = null;
            try
            {
                for (var i = 0; i < 1000; i++) 
                {
                    await writer.WriteAsync(data, cancellationToken);

                    await Task.Delay(delay, cancellationToken);
                }
            }catch(Exception ex)
            {
                localException = ex;
            }
            finally
            {
                writer.Complete(localException);
            }
        }
        public async Task UploadStream(ChannelReader<T> stream)
        {
            while(await stream.WaitToReadAsync())
            {
                while(stream.TryRead(out var item))
                {
                    Console.WriteLine(item);
                }
            }
        }

    }
}
