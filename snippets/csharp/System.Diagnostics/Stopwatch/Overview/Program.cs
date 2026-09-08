using System;

internal static class SampleRunner
{
    public static void Main(string[] args)
    {
        string[] sampleArgs = args.Length > 1 ? args[1..] : [];

        switch (args.Length > 0 ? args[0] : null)
        {
            case "operations":
                StopWatchSample.OperationsTimer.Run();
                break;
            case "elapsed":
                Program.Run(sampleArgs);
                break;
            default:
                Console.WriteLine("Specify: operations or elapsed.");
                break;
        }
    }
}
