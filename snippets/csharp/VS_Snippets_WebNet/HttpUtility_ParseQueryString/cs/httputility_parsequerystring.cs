// <Snippet1>

using System;
using System.Web;

class Program
{
    static void Main()
    {
        // Parse the URL and get the query string
        var url = "https://www.microsoft.com?name=John&age=30&location=USA";
        var parsedUrl = url.Split('?')[1];

        // The ParseQueryString method will parse the query string and return a NameValueCollection
        var paramsCollection = HttpUtility.ParseQueryString(parsedUrl);

        // The foreach loop will iterate over the params collection and print the key and value for each param
        foreach (var key in paramsCollection.AllKeys)
        {
            Console.WriteLine($"Key: {key} => Value: {paramsCollection[key]}");
        }
    }
}

// The example displays the following output:
// Key: name => Value: John
// Key: age => Value: 30
// Key: location => Value: USA

// </Snippet1>