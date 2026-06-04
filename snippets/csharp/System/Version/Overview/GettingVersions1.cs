using System;
using System.Reflection;

[assembly: CLSCompliant(true)]
public class Class1
{
    public static void Run()
    {
        GetOsVersion();
        Console.WriteLine();
        GetClrVersion();
        Console.WriteLine();
    }

    private static void GetOsVersion()
    {
        // <Snippet1>
        // Get the operating system version.
        OperatingSystem os = Environment.OSVersion;
        Version ver = os.Version;
        Console.WriteLine($"Operating System: {os.VersionString} ({ver})");
        // </Snippet1>
    }

    private static void GetClrVersion()
    {
        // <Snippet2>
        // Get the common language runtime version.
        Version ver = Environment.Version;
        Console.WriteLine($"CLR Version {ver}");
        // </Snippet2>
    }
}
