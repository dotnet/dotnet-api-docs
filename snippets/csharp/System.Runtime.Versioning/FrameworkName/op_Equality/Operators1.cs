using System;
using System.Runtime.Versioning;

public class Example
{
    public static void Main()
    {
        TestForEquality();
        TestForInequality();
    }

    private static void TestForEquality()
    {
        // <Snippet1>
        FrameworkName version = new(".NET, Version=10.0");
        FrameworkName actualVersion = new($".NET, Version={Environment.Version}");

        Console.WriteLine($"Given Version: {version}");
        Console.WriteLine($"Actual Version: {actualVersion}");
        if (version == actualVersion)
            Console.WriteLine("The versions are the same.");
        else
            Console.WriteLine("The versions are different.");

        Console.WriteLine();

        // The example displays output similar to the following:

        // Given Version: .NET,Version=v10.0
        // Actual Version: .NET,Version=v10.0.10
        // The versions are different.

        // </Snippet1>
    }

    private static void TestForInequality()
    {
        // <Snippet2>
        FrameworkName version = new(".NET, Version=10.0");
        FrameworkName actualVersion = new($".NET, Version={Environment.Version}");

        Console.WriteLine($"Given Version: {version}");
        Console.WriteLine($"Actual Version {actualVersion}");
        if (version != actualVersion)
            Console.WriteLine("The versions are different.");
        else
            Console.WriteLine("The versions are the same.");

        Console.WriteLine();

        // The example displays output similar to the following:

        // Given Version: .NET,Version=v10.0
        // Actual Version: .NET,Version=v10.0.10
        // The versions are different.

        // </Snippet2>
    }
}
