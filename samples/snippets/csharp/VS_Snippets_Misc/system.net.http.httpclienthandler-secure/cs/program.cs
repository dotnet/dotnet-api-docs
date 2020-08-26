using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

class HttpClientHandler_SecureExample
{
// <Snippet1>
    static async Task Main()
    {
        // Create an HttpClientHandler object and set to use default credentials
        HttpClientHandler handler = new HttpClientHandler();

        // Set custom server validation callback
        handler.ServerCertificateCustomValidationCallback = ServerCertificateCustomValidation;

        // Create an HttpClient object
        HttpClient client = new HttpClient(handler);

        // Call asynchronous network methods in a try/catch block to handle exceptions
        try
        {
            HttpResponseMessage response = await client.GetAsync("https://docs.microsoft.com/");

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Read {responseBody.Length} characters");
        }
        catch(HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ",e.Message);
        }

        // Need to call dispose on the HttpClient and HttpClientHandler objects
        // when done using them, so the app doesn't leak resources
        handler.Dispose();
        client.Dispose();
    }

    private static bool ServerCertificateCustomValidation(HttpRequestMessage requestMessage, X509Certificate2 certificate, X509Chain chain, SslPolicyErrors sslErrors)
    {
        // It is possible inpect the certificate provided by server
        Console.WriteLine($"Requested URI: {requestMessage.RequestUri}");
        Console.WriteLine($"Effective date: {certificate.GetEffectiveDateString()}");
        Console.WriteLine($"Exp date: {certificate.GetExpirationDateString()}");
        Console.WriteLine($"Issuer: {certificate.Issuer}");
        Console.WriteLine($"Subject: {certificate.Subject}");

        // Based on the custom logic it is possible to decide whether the client considers certificate valid or not
        Console.WriteLine($"Errors: {sslErrors}");
        return sslErrors == SslPolicyErrors.None;
    }
// </Snippet1>
}
