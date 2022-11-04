/**
  * File name:socket.cs.
  * This example creates a socket connection to the server specified by the user,
  * using port 80. Once the connection has been established it asks the server for
  * the content of its home page. If no server name is passed as argument to this
  * program, it sends the request to example.com.
  * */
using System;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

public class GetSocket
{
    public static async Task Main(string[] args)
    {
        Uri? uri = args.Any() ? new Uri(args[0]) : null;

        // Sync:
        SendHttpRequest(uri);

        // Async:
        await SendHttpRequestAsync(uri);
    }

//<Snippet1>
private static void SendHttpRequest(Uri? uri = null, int port = 80)
{
    uri ??= new Uri("http://example.com");

    // Construct a minimalistic HTTP/1.1 request
    byte[] requestBytes = Encoding.ASCII.GetBytes(@$"GET {uri.AbsoluteUri} HTTP/1.0
Host: {uri.Host}
Connection: Close

");

    // Create and connect a dual-stack socket
    using Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
    socket.Connect(uri.Host, port);

    // Send the request.
    // For the tiny amount of data in this example, the first call to Send() will likely deliver the buffer completely,
    // however this is not guaranteed to happen for larger real-life buffers.
    // The best practice is to iterate until all the data is sent.
    int bytesSent = 0;
    while (bytesSent < requestBytes.Length)
    {
        bytesSent += socket.Send(requestBytes, bytesSent, requestBytes.Length - bytesSent, SocketFlags.None);
    }

    // Do minimalistic buffering assuming ASCII response
    byte[] responseBytes = new byte[256];
    char[] responseChars = new char[256];

    while (true)
    {
        int bytesReceived = socket.Receive(responseBytes);

        // Receiving 0 bytes means EOF has been reached
        if (bytesReceived == 0) break;

        // Convert byteCount bytes to ASCII characters using the 'responseChars' buffer as destination
        int charCount = Encoding.ASCII.GetChars(responseBytes, 0, bytesReceived, responseChars, 0);

        // Print the contents of the 'responseChars' buffer to Console.Out
        Console.Out.Write(responseChars, 0, charCount);
    }
}
//</Snippet1>

//<Snippet2>
private static async Task SendHttpRequestAsync(Uri? uri = null, int port = 80, CancellationToken cancellationToken = default)
{
    uri ??= new Uri("http://example.com");

    // Construct a minimalistic HTTP/1.1 request
    byte[] requestBytes = Encoding.ASCII.GetBytes(@$"GET {uri.AbsoluteUri} HTTP/1.1
Host: {uri.Host}
Connection: Close

");

    // Create and connect a dual-stack socket
    using Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
    await socket.ConnectAsync(uri.Host, port, cancellationToken);

    // Send the request.
    // For the tiny amount of data in this example, the first call to SendAsync() will likely deliver the buffer completely,
    // however this is not guaranteed to happen for larger real-life buffers.
    // The best practice is to iterate until all the data is sent.
    int bytesSent = 0;
    while (bytesSent < requestBytes.Length)
    {
        bytesSent += await socket.SendAsync(requestBytes.AsMemory(bytesSent), SocketFlags.None);
    }

    // Do minimalistic buffering assuming ASCII response
    byte[] responseBytes = new byte[256];
    char[] responseChars = new char[256];

    while (true)
    {
        int bytesReceived = await socket.ReceiveAsync(responseBytes, SocketFlags.None, cancellationToken);

        // Receiving 0 bytes means EOF has been reached
        if (bytesReceived == 0) break;

        // Convert byteCount bytes to ASCII characters using the 'responseChars' buffer as destination
        int charCount = Encoding.ASCII.GetChars(responseBytes, 0, bytesReceived, responseChars, 0);

        // Print the contents of the 'responseChars' buffer to Console.Out
        await Console.Out.WriteAsync(responseChars.AsMemory(0, charCount), cancellationToken);
    }
}
//</Snippet2>
}
