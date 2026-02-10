using System;

public class UriHostComparison
{
    public static void Main()
    {
        // <SnippetHostComparison>
        // Demonstrate differences between Host, IdnHost, and DnsSafeHost.

        // Example 1: Regular hostname (ASCII).
        Console.WriteLine("Example 1: Regular ASCII hostname");
        Uri uri1 = new Uri("http://www.contoso.com:8080/path");
        Console.WriteLine($"  Host:        {uri1.Host}");        // www.contoso.com
        Console.WriteLine($"  IdnHost:     {uri1.IdnHost}");     // www.contoso.com
        Console.WriteLine($"  DnsSafeHost: {uri1.DnsSafeHost}"); // www.contoso.com
        Console.WriteLine();

        // Example 2: International domain name (non-ASCII).
        Console.WriteLine("Example 2: International domain name");
        Uri uri2 = new Uri("http://münchen.de/path");
        Console.WriteLine($"  Host:        {uri2.Host}");        // münchen.de (original)
        Console.WriteLine($"  IdnHost:     {uri2.IdnHost}");     // xn--mnchen-3ya.de (punycode)
        Console.WriteLine($"  DnsSafeHost: {uri2.DnsSafeHost}"); // depends on configuration
        Console.WriteLine();

        // Example 3: IPv6 address without zone ID.
        Console.WriteLine("Example 3: IPv6 address without zone ID");
        Uri uri3 = new Uri("http://[::1]:8080/path");
        Console.WriteLine($"  Host:        {uri3.Host}");        // [::1] (with brackets)
        Console.WriteLine($"  IdnHost:     {uri3.IdnHost}");     // ::1 (without brackets)
        Console.WriteLine($"  DnsSafeHost: {uri3.DnsSafeHost}"); // ::1 (without brackets)
        Console.WriteLine();

        // Example 4: IPv6 link-local address with zone ID.
        Console.WriteLine("Example 4: IPv6 link-local address with zone ID");
        Uri uri4 = new Uri("http://[fe80::1%10]:8080/path");
        Console.WriteLine($"  Host:        {uri4.Host}");        // [fe80::1] (with brackets, no zone ID)
        Console.WriteLine($"  IdnHost:     {uri4.IdnHost}");     // fe80::1%10 (without brackets, with zone ID)
        Console.WriteLine($"  DnsSafeHost: {uri4.DnsSafeHost}"); // fe80::1%10 (without brackets, with zone ID)
        Console.WriteLine();

        // Example 5: IPv4 address.
        Console.WriteLine("Example 5: IPv4 address");
        Uri uri5 = new Uri("http://192.168.1.1:8080/path");
        Console.WriteLine($"  Host:        {uri5.Host}");        // 192.168.1.1
        Console.WriteLine($"  IdnHost:     {uri5.IdnHost}");     // 192.168.1.1
        Console.WriteLine($"  DnsSafeHost: {uri5.DnsSafeHost}"); // 192.168.1.1
        // </SnippetHostComparison>
    }
}
