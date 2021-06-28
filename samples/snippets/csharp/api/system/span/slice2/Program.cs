using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        string contentLength = "Content-Length: 132";
        var length = GetContentLength(contentLength);	
        Console.WriteLine($"Content length: {length}"); 
    }

    private static int GetContentLength(ReadOnlySpan<char> span)
    {
        var slice = span.Slice(16);
        // Use InvariantCulture as the content length format does not change on a per-culture basis
	    return int.Parse(slice, provider: CultureInfo.InvariantCulture);
    }
}
// Output:
//      Content length: 132
