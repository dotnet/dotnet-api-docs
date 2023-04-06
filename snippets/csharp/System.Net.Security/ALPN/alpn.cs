using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

async Task RunServer()
{
    using X509Certificate2 serverCertificate = new("contoso.com.pfx", "testcertificate");


    var listener = new TcpListener(IPAddress.Loopback, 5004);
    listener.Start();
    using var server = await listener.AcceptTcpClientAsync();
    listener.Stop();

    await Server(server.GetStream(), serverCertificate);
}

async Task RunClient()
{
    using var client = new TcpClient();

    await client.ConnectAsync(new IPEndPoint(IPAddress.Loopback, 5004));

    await Client(client.GetStream(), "testserver.contoso.com");
}

//<snippet>
async Task Server(NetworkStream stream, X509Certificate2 serverCertificate)
{
    using var server = new SslStream(stream);

    await server.AuthenticateAsServerAsync(new SslServerAuthenticationOptions
    {
        ServerCertificate = serverCertificate,
        ApplicationProtocols = new()
        {
            new("protocol1"),
            new("protocol2"),
        }
    });

    string protocol = Encoding.ASCII.GetString(server.NegotiatedApplicationProtocol.Protocol.Span);
    System.Console.WriteLine($"Server - negotiated protocol: {protocol}");
}

async Task Client(NetworkStream stream, string hostName)
{
    using var client = new SslStream(stream);

    await client.AuthenticateAsClientAsync(new SslClientAuthenticationOptions
    {
        // the host name must match the name on the certificate used on the server side
        TargetHost = hostName,
        ApplicationProtocols = new()
        {
            new("protocol2"),
            new("protocol3")
        }
    });

    string protocol = Encoding.ASCII.GetString(client.NegotiatedApplicationProtocol.Protocol.Span);
    System.Console.WriteLine($"Client - negotiated protocol: {protocol}");
}

// possible output:
//   Server - negotiated protocol: protocol2
//   Client - negotiated protocol: protocol2
//</snippet>

await Task.WhenAll(RunClient(), RunServer());