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
            var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);
            using (var response = await httpClient.GetAsync("http://localhost:12345/", HttpCompletionOption.ResponseHeadersRead)) // 30-second timeout but ONLY up until past the headers
            {
                // Do other stuff that doesn't rely on the content first, like status code validation
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync(); // NO TIMEOUT
            }
            //</SnippetHttpCompletionOption>
        }
    }
}
