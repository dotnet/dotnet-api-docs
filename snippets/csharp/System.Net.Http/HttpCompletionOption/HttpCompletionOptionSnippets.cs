using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpCompletionOptionSnippets
{
    class HttpCompletionOptionSnippets
    {
        public static async Task RunAsync()
        {
            //<SnippetHttpCompletionOption>
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);
            httpClient.MaxResponseContentBufferSize = 1_000; // This will be ignored

            // Because we're specifying the ResponseHeadersRead option,
            // the 30-second timeout applies only up until the headers are received.
            // It does not affect future operations that interact with the response content.
            using HttpResponseMessage response = await httpClient.GetAsync(
                "http://localhost:12345/",
                HttpCompletionOption.ResponseHeadersRead);

            // Do other checks that don't rely on the content first, like status code validation.
            response.EnsureSuccessStatusCode();

            // Since the HttpClient.Timeout will not apply to reading the content,
            // you must enforce it yourself, for example by using a CancellationTokenSource.
            using var cancellationSource = new CancellationTokenSource(TimeSpan.FromSeconds(15));
            
            // If you wish to enforce the MaxResponseContentBufferSize limit as well,
            // you can do so by calling the LoadIntoBufferAsync helper first.
            await response.Content.LoadIntoBufferAsync(1_000, cancellationSource.Token);

            // Make sure to pass the CancellationToken to all methods.
            string content = await response.Content.ReadAsStringAsync(cancellationSource.Token);
            //</SnippetHttpCompletionOption>
        }
    }
}
