using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

class HttpClientHandler_SecureExample
{
    // <Snippet1>
    static async Task Main()
    {
        using SocketsHttpHandler handler = new SocketsHttpHandler();

        handler.ConnectCallback = async (ctx, ct) =>
        {
            var s = new Socket(SocketType.Stream, ProtocolType.Tcp) { NoDelay = true };
            try
            {
                s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                s.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveTime, 5);
                s.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveInterval, 5);
                s.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.TcpKeepAliveRetryCount, 5);
                await s.ConnectAsync(ctx.DnsEndPoint, ct);
                return new NetworkStream(s, ownsSocket: true);
            }
            catch
            {
                s.Dispose();
                throw;
            }
        };

        // Create an HttpClient object
        using HttpClient client = new HttpClient(handler);

        // Call asynchronous network methods in a try/catch block to handle exceptions
        try
        {
            HttpResponseMessage response = await client.GetAsync("https://learn.microsoft.com/");

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Read {responseBody.Length} characters");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine($"Message: {e.Message} ");
        }
    }

    // </Snippet1>
}
