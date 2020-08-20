using System;
using System.Net;
using System.Windows.Forms;

public class Form1 : Form
{
  protected void Method()
  {
    // <Snippet1>
    Uri contoso = new Uri("http://www.contoso.com/");

    WebRequest wr = WebRequest.Create(contoso);
    // </Snippet1>
    
    // <Snippet2>
    Uri uri = new Uri("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName");
    
    Console.WriteLine($"AbsolutePath: {uri.AbsolutePath}");
    Console.WriteLine($"AbsoluteUri: {uri.AbsoluteUri}");
    Console.WriteLine($"DnsSafeHost: {uri.DnsSafeHost}");
    Console.WriteLine($"Fragment: {uri.Fragment}");
    Console.WriteLine($"Host: {uri.Host}");
    Console.WriteLine($"HostNameType: {uri.HostNameType}");
    Console.WriteLine($"IdnHost: {uri.IdnHost}");
    Console.WriteLine($"IsAbsoluteUri: {uri.IsAbsoluteUri}");
    Console.WriteLine($"IsDefaultPort: {uri.IsDefaultPort}");
    Console.WriteLine($"IsFile: {uri.IsFile}");
    Console.WriteLine($"IsLoopback: {uri.IsLoopback}");
    Console.WriteLine($"IsUnc: {uri.IsUnc}");
    Console.WriteLine($"LocalPath: {uri.LocalPath}");
    Console.WriteLine($"OriginalString: {uri.OriginalString}");
    Console.WriteLine($"PathAndQuery: {uri.PathAndQuery}");
    Console.WriteLine($"Port: {uri.Port}");
    Console.WriteLine($"Query: {uri.Query}");
    Console.WriteLine($"Scheme: {uri.Scheme}");
    Console.WriteLine($"Segments: {string.Join(", ", uri.Segments)}");
    Console.WriteLine($"UserEscaped: {uri.UserEscaped}");
    Console.WriteLine($"UserInfo: {uri.UserInfo}");
    
    // AbsolutePath: /Home/Index.htm
    // AbsoluteUri: https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName
    // DnsSafeHost: www.contoso.com
    // Fragment: #FragmentName
    // Host: www.contoso.com
    // HostNameType: Dns
    // IdnHost: www.contoso.com
    // IsAbsoluteUri: True
    // IsDefaultPort: False
    // IsFile: False
    // IsLoopback: False
    // IsUnc: False
    // LocalPath: /Home/Index.htm
    // OriginalString: https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName
    // PathAndQuery: /Home/Index.htm?q1=v1&q2=v2
    // Port: 80
    // Query: ?q1=v1&q2=v2
    // Scheme: https
    // Segments: /, Home/, Index.htm
    // UserEscaped: False
    // UserInfo: user:password

    // </Snippet2>
  }
}
