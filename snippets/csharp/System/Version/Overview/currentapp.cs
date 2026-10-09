// <Snippet5>
using System;
using System.Reflection;

public class Example4
{
    public static void Main()
    {
        // Get the version of the executing assembly (that is, this assembly).
        Assembly assem = Assembly.GetEntryAssembly();
        AssemblyName assemName = assem.GetName();
        Version ver = assemName.Version;
        Console.WriteLine($"Application {assemName.Name}, Version {ver}");
    }
}
// </Snippet5>
