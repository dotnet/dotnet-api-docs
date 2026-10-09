//<Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
class Program
{
    public static void Run(string[] args)
    {
        Stopwatch stopWatch = new();
        stopWatch.Start();
        Thread.Sleep(10000);
        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime =
            $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}";
        Console.WriteLine($"RunTime {elapsedTime}");
    }
}
//</Snippet1>
