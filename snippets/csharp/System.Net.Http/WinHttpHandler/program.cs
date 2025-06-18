using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;

class WinHttpHandler_SecureExample
{
    static void Main()
    {
        if (!OperatingSystem.IsWindows())
        {
            Console.WriteLine("This example requires Windows.");
            return;
        }
        // <Snippet1>
        var handler = new WinHttpHandler();
        handler.ServerCertificateValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) =>
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                // TODO: Implement additional custom certificate validation logic here.
                return true;
            }
            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        };
        // </Snippet1>
    }
}
