using System;
using System.Net;
using System.Net.Http;

public class Sample
{

    private void sampleFunction()
    {
        // <Snippet1>
        WebProxy proxyObject = new WebProxy("http://proxyserver:80/", true);

        // HttpClient lifecycle management best practices:
        // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
        HttpClient client = new HttpClient(new HttpClientHandler
        {
            Proxy = proxyObject
        });
        // </Snippet1>
    }
}
