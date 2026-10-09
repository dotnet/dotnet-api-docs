// <Snippet1>
using System;

public class Example
{
    public static void Main()
    {
        var os = Environment.OSVersion;
        Console.WriteLine("Current OS Information:\n");
        Console.WriteLine($"Platform: {os.Platform:G}");
        Console.WriteLine($"Version String: {os.VersionString}");
        Console.WriteLine("Version Information:");
        Console.WriteLine($"   Major: {os.Version.Major}");
        Console.WriteLine($"   Minor: {os.Version.Minor}");
        Console.WriteLine($"Service Pack: '{os.ServicePack}'");
    }
}
// If run on a Windows 8.1 system, the example displays output like the following:
//       Current OS Information:
//
//       Platform: Win32NT
//       Version String: Microsoft Windows NT 6.2.9200.0
//       Version Information:
//          Major: 6
//          Minor: 2
//       Service Pack: ''
// If run on a Windows 7 system, the example displays output like the following:
//       Current OS Information:
//
//       Platform: Win32NT
//       Version String: Microsoft Windows NT 6.1.7601 Service Pack 1
//       Version Information:
//          Major: 6
//          Minor: 1
//       Service Pack: 'Service Pack 1'
// </Snippet1>
