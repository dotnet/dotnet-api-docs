using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

class WinHttpHandler_SecureExample
{
    static async Task Main()
    {
        // <Snippet1>
        var handler = new WinHttpHandler();
        handler.ServerCertificateValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors)
        {
             if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
        // </Snippet1>
    }
}
