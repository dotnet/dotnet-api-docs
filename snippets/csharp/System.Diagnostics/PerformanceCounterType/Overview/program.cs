//<Snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

// Provides a SampleFraction counter to measure the percentage of the user processor
// time for this process to total processor time for the process.
public class SampleFractionApp
{

    private static PerformanceCounter perfCounter;
    private static PerformanceCounter basePerfCounter;
    private static Process thisProcess = Process.GetCurrentProcess();

    public static void Run()
    {

        ArrayList samplesList = [];

        // If the category does not exist, create the category and exit.
        // Performance counters should not be created and immediately used.
        // There is a latency time to enable the counters, they should be created
        // prior to executing the application that uses the counters.
        // Execute this sample a second time to use the category.
        if (SetupCategory())
            return;
        CreateCounters();
        CollectSamples(samplesList);
        CalculateResults(samplesList);
    }

    private static bool SetupCategory()
    {
        if (!PerformanceCounterCategory.Exists("SampleFractionCategory"))
        {

            CounterCreationDataCollection CCDC = [];

            // Add the counter.
            CounterCreationData sampleFraction = new()
            {
                CounterType = PerformanceCounterType.SampleFraction,
                CounterName = "SampleFractionSample"
            };
            CCDC.Add(sampleFraction);

            // Add the base counter.
            CounterCreationData sampleFractionBase = new()
            {
                CounterType = PerformanceCounterType.SampleBase,
                CounterName = "SampleFractionSampleBase"
            };
            CCDC.Add(sampleFractionBase);

            // Create the category.
            PerformanceCounterCategory.Create("SampleFractionCategory",
                "Demonstrates usage of the SampleFraction performance counter type.",
                PerformanceCounterCategoryType.SingleInstance, CCDC);

            return (true);
        }
        else
        {
            Console.WriteLine("Category exists - SampleFractionCategory");
            return (false);
        }
    }

    private static void CreateCounters()
    {
        // Create the counters.

        perfCounter = new PerformanceCounter("SampleFractionCategory",
            "SampleFractionSample",
            false);

        basePerfCounter = new PerformanceCounter("SampleFractionCategory",
            "SampleFractionSampleBase",
            false);

        perfCounter.RawValue = thisProcess.UserProcessorTime.Ticks;
        basePerfCounter.RawValue = thisProcess.TotalProcessorTime.Ticks;
    }
    private static void CollectSamples(ArrayList samplesList)
    {

        // Loop for the samples.
        for (int j = 0; j < 100; j++)
        {

            perfCounter.IncrementBy(thisProcess.UserProcessorTime.Ticks);

            basePerfCounter.IncrementBy(thisProcess.TotalProcessorTime.Ticks);

            if ((j % 10) == 9)
            {
                OutputSample(perfCounter.NextSample());
                samplesList.Add(perfCounter.NextSample());
            }
            else
            {
                Console.WriteLine();
            }

            System.Threading.Thread.Sleep(50);
        }
    }

    private static void CalculateResults(ArrayList samplesList)
    {
        for (int i = 0; i < (samplesList.Count - 1); i++)
        {
            // Output the sample.
            OutputSample((CounterSample)samplesList[i]);
            OutputSample((CounterSample)samplesList[i + 1]);

            // Use .NET to calculate the counter value.
            Console.WriteLine(".NET computed counter value = " +
                CounterSampleCalculator.ComputeCounterValue((CounterSample)samplesList[i],
                (CounterSample)samplesList[i + 1]));

            // Calculate the counter value manually.
            Console.WriteLine("My computed counter value = " +
                MyComputeCounterValue((CounterSample)samplesList[i],
                (CounterSample)samplesList[i + 1]));
        }
    }

    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    // Description - This counter type provides A percentage counter that shows the
    // average ratio of user proccessor time to total processor time  during the last
    // two sample intervals.
    //++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++//++++++++
    private static float MyComputeCounterValue(CounterSample s0, CounterSample s1)
    {
        float numerator = (float)s1.RawValue - (float)s0.RawValue;
        float denomenator = (float)s1.BaseValue - (float)s0.BaseValue;
        float counterValue = 100 * (numerator / denomenator);
        return (counterValue);
    }

    // Output information about the counter sample.
    private static void OutputSample(CounterSample s)
    {
        Console.WriteLine("\r\n+++++++++++");
        Console.WriteLine("Sample values - \r\n");
        Console.WriteLine("   BaseValue        = " + s.BaseValue);
        Console.WriteLine("   CounterFrequency = " + s.CounterFrequency);
        Console.WriteLine("   CounterTimeStamp = " + s.CounterTimeStamp);
        Console.WriteLine("   CounterType      = " + s.CounterType);
        Console.WriteLine("   RawValue         = " + s.RawValue);
        Console.WriteLine("   SystemFrequency  = " + s.SystemFrequency);
        Console.WriteLine("   TimeStamp        = " + s.TimeStamp);
        Console.WriteLine("   TimeStamp100nSec = " + s.TimeStamp100nSec);
        Console.WriteLine("++++++++++++++++++++++");
    }
}
//</Snippet1>

internal static class Program
{
    public static void Main(string[] args)
    {
        switch (args.Length > 0 ? args[0] : null)
        {
            case "average-timer":
#if BELOW_WHIDBEY_BUILD
                App.Run();
#else
                App2.Run();
#endif
                break;
            case "number-of-items-32":
                NumberOfItems32.Run();
                break;
            case "number-of-items-64":
                NumberOfItems64_1.Run();
                break;
            case "sample-fraction":
                SampleFractionApp.Run();
                break;
            case "rate-32":
                App3.Run();
                break;
            case "rate-64":
                App4.Run();
                break;
            case "raw-fraction":
                App5.Run();
                break;
            default:
                Console.WriteLine(
                    "Specify: average-timer, number-of-items-32, " +
                    "number-of-items-64, sample-fraction, rate-32, rate-64, or raw-fraction.");
                break;
        }
    }
}
