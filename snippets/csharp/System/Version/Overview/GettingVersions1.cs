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

    private static void GetSpecificAssemblyVersion()
    {
        // Get the version of a specific assembly.
        string filename = @".\StringLibrary.dll";
        Assembly assem = Assembly.ReflectionOnlyLoadFrom(filename);
        AssemblyName assemName = assem.GetName();
        Version ver = assemName.Version;
        Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString());
    }

    private static void GetApplicationVersion()
    {
        // Get the version of the executing assembly (that is, this assembly).
        Assembly assem = Assembly.GetEntryAssembly();
        AssemblyName assemName = assem.GetName();
        Version ver = assemName.Version;
        Console.WriteLine("Application {0}, Version {1}", assemName.Name, ver.ToString());
    }
}

public class VersionsExample1
{
    public static void GetExecutingAssemblyVersion()
    {
        // Get the version of the current application.
        Assembly assem = typeof(Assembly.GetExecutingAssembly());
        AssemblyName assemName = assem.GetName();
        Version ver = assemName.Version;
        Console.WriteLine("{0}, Version {1}", assemName.Name, ver.ToString());
    }
}
