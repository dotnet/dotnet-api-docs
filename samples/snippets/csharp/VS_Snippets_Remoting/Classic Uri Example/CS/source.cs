using System;
using System.Data;
using System.Net;
using System.Windows.Forms;

public class Form1: Form
{
 protected void Method()
 {
Uri uri = new Uri("https://user:password@www.contoso.com:80/Home/Index.htm?q1=v1&q2=v2#FragmentName");
Console.WriteLine("AbsolutePath: {0}", uri.AbsolutePath);
Console.WriteLine("AbsoluteUri: {0}", uri.AbsoluteUri);
Console.WriteLine("DnsSafeHost: {0}", uri.DnsSafeHost);
Console.WriteLine("Fragment: {0}", uri.Fragment);
Console.WriteLine("Host: {0}", uri.Host);
Console.WriteLine("HostNameType: {0}", uri.HostNameType);
Console.WriteLine("IdnHost: {0}", uri.IdnHost);
Console.WriteLine("IsAbsoluteUri: {0}", uri.IsAbsoluteUri);
Console.WriteLine("IsDefaultPort: {0}", uri.IsDefaultPort);
Console.WriteLine("IsFile: {0}", uri.IsFile);
Console.WriteLine("IsLoopback: {0}", uri.IsLoopback);
Console.WriteLine("IsUnc: {0}", uri.IsUnc);
Console.WriteLine("LocalPath: {0}", uri.LocalPath);
Console.WriteLine("OriginalString: {0}", uri.OriginalString);
Console.WriteLine("PathAndQuery: {0}", uri.PathAndQuery);
Console.WriteLine("Port: {0}", uri.Port);
Console.WriteLine("Query: {0}", uri.Query);
Console.WriteLine("Scheme: {0}", uri.Scheme);
Console.WriteLine("Segments: {0}", string.Join(", ", uri.Segments));
Console.WriteLine("UserEscaped: {0}", uri.UserEscaped);
Console.WriteLine("UserInfo: {0}", uri.UserInfo);

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

// </Snippet1>
 }
}
