using System;
using System.Diagnostics;
using System.IO;

string[] sampleArgs = args.Length > 1 ? args[1..] : [];

switch (args.Length > 0 ? args[0] : null)
{
    case "async":
        Process_StandardError.Class1.Run(sampleArgs);
        break;
    case "sync":
        Example.Run();
        break;
    case "helper":
        Write500Lines.Run();
        break;
    default:
        Console.WriteLine("Specify: async or sync.");
        break;
}

internal static class SampleProcess
{
    public static ProcessStartInfo CreateStartInfo(string sample)
    {
        string executablePath =
            Environment.ProcessPath ?? throw new InvalidOperationException("The current process path isn't available.");
        ProcessStartInfo startInfo = new(executablePath);

        if (string.Equals(Path.GetFileNameWithoutExtension(executablePath), "dotnet",
            StringComparison.OrdinalIgnoreCase))
        {
            startInfo.ArgumentList.Add(typeof(SampleProcess).Assembly.Location);
        }

        startInfo.ArgumentList.Add(sample);
        return startInfo;
    }
}

internal static class Write500Lines
{
    public static void Run()
    {
        for (int i = 0; i < 500; i++)
        {
            Console.WriteLine($"Line {i + 1} of 500 written: {(i + 1) / 500.0:P2}");
        }

        Console.Error.WriteLine("\nSuccessfully wrote 500 lines.\n");
    }
}
