Imports System.Net
Imports System.Net.Security
Imports System.Net.Sockets
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Module MainModule
    Async Function RunServer() As Task
        Using serverCertificate As X509Certificate2 = New X509Certificate2("contoso.com.pfx", "testcertificate")
            Dim listener as New TcpListener(IPAddress.Loopback, 5004)
            listener.Start()
            Using tcpServer As TcpClient = Await listener.AcceptTcpClientAsync()
                listener.Stop()
                Await Server(tcpServer.GetStream(), serverCertificate)
            End Using
        End Using
    End Function

    Async Function RunClient() As Task
        Using tcpClient as TcpClient = New TcpClient()
            Await tcpClient.ConnectAsync(new IPEndPoint(IPAddress.Loopback, 5004))
            Await Client(tcpClient.GetStream(), "testserver.contoso.com")
        End Using
    End Function

    '<snippet>
    Async Function Server(stream As NetworkStream, serverCertificate As X509Certificate2) As Task
        Using serverStream As SslStream = new SslStream(stream)
            Dim options as New SslServerAuthenticationOptions() With
            {
                .ServerCertificate = serverCertificate,
                .ApplicationProtocols = New List(Of SslApplicationProtocol) From
                {
                    New SslApplicationProtocol("protocol1"),
                    New SslApplicationProtocol("protocol2")
                }
            }
            Await serverStream.AuthenticateAsServerAsync(options)

            Dim protocol As String = Encoding.ASCII.GetString(
                serverStream.NegotiatedApplicationProtocol.Protocol.Span)
            System.Console.WriteLine($"Server - negotiated protocol: {protocol}")
        End Using
    End Function

    Async Function Client(stream As NetworkStream, hostName As String ) As Task
        Using clientStream As SslStream = new SslStream(stream)
            Dim options as New SslClientAuthenticationOptions() With
            {
                .TargetHost = hostName,
                .ApplicationProtocols = New List(Of SslApplicationProtocol) From
                {
                    New SslApplicationProtocol("protocol2"),
                    New SslApplicationProtocol("protocol3")
                }
            }
            Await clientStream.AuthenticateAsClientAsync(options)

            Dim protocol As String = Encoding.ASCII.GetString(
                clientStream.NegotiatedApplicationProtocol.Protocol.Span)
            System.Console.WriteLine($"Client - negotiated protocol: {protocol}")
        End Using
    End Function

    ' possible output:
    '   Server - negotiated protocol: protocol2
    '   Client - negotiated protocol: protocol2
    '</snippet>

    Sub Main()
        Task.WhenAll(RunClient(), RunServer()).GetAwaiter().GetResult()
    End Sub
End Module
