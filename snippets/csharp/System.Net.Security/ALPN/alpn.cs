using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

async Task RunServer()
{
    using X509Certificate2 serverCertificate = new X509Certificate2("contoso.com.pfx", "testcertificate");

    TcpListener listener = new TcpListener(IPAddress.Loopback, 5004);
    listener.Start();
    using TcpClient server = await listener.AcceptTcpClientAsync();
    listener.Stop();

    await Server(server.GetStream(), serverCertificate);
}

async Task RunClient()
{
    using TcpClient client = new TcpClient();
    await client.ConnectAsync(new IPEndPoint(IPAddress.Loopback, 5004));

    await Client(client.GetStream(), "testserver.contoso.com");
}

//<snippet>
async Task Server(NetworkStream stream, X509Certificate2 serverCertificate)
{
    using SslStream server = new SslStream(stream);
    await server.AuthenticateAsServerAsync(new SslServerAuthenticationOptions
    {
        ServerCertificate = serverCertificate,
        ApplicationProtocols = new List<SslApplicationProtocol>
        {
            new SslApplicationProtocol("protocol1"),
            new SslApplicationProtocol("protocol2"),
        },
    });

    string protocol = Encoding.ASCII.GetString(server.NegotiatedApplicationProtocol.Protocol.Span);
    System.Console.WriteLine($"Server - negotiated protocol: {protocol}");
}

async Task Client(NetworkStream stream, string hostName)
{
    using SslStream client = new SslStream(stream);
    await client.AuthenticateAsClientAsync(new SslClientAuthenticationOptions
    {
        // the host name must match the name on the certificate used on the server side
        TargetHost = hostName,
        ApplicationProtocols = new List<SslApplicationProtocol>
        {
            new SslApplicationProtocol("protocol2"),
            new SslApplicationProtocol("protocol3")
        },
    });

    string protocol = Encoding.ASCII.GetString(client.NegotiatedApplicationProtocol.Protocol.Span);
    System.Console.WriteLine($"Client - negotiated protocol: {protocol}");
}

// possible output:
//   Server - negotiated protocol: protocol2
//   Client - negotiated protocol: protocol2
//</snippet>

await Task.WhenAll(RunClient(), RunServer());