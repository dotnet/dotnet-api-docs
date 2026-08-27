using System;
using System.Diagnostics;
using System.IO;

switch (args.Length > 0 ? args[0] : null)
{
    case "redirect":
        StandardOutputExample.Run();
        break;
    case "async":
        AsyncExample.Run();
        break;
    case "sync":
        SyncExample.Run();
        break;
    case "helper":
        Example3.Run();
        break;
    default:
        Console.WriteLine("Specify: redirect, async, sync, or helper.");
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
