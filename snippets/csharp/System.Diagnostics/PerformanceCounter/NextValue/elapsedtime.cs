// The sample is conditionally compiled for Everett and Whidbey builds.
// Whidbey introduced APIs that aren't available in Everett.
// Snippet IDs don't overlap: snippet 1 is Everett, and snippets 2 and 3 are Whidbey.

#if (BELOW_WHIDBEY_BUILD)

//<snippet1>
using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

public class App
{
    private static PerformanceCounter PC;

	public static void Main()
	{	
		ArrayList samplesList = new();

		SetupCategory();
        CreateCounters();
		CollectSamples(samplesList);
	}

    private static bool SetupCategory()
    {
        if ( !PerformanceCounterCategory.Exists("ElapsedTimeSampleCategory") )
        {
            CounterCreationDataCollection CCDC = new();

            // Add the counter.
            CounterCreationData ETimeData = new();
            ETimeData.CounterType = PerformanceCounterType.ElapsedTime;
            ETimeData.CounterName = "ElapsedTimeSample";
            CCDC.Add(ETimeData);	
		
            // Create the category.
            PerformanceCounterCategory.Create("ElapsedTimeSampleCategory",
                "Demonstrates usage of the ElapsedTime performance counter type.",
                CCDC);

            return(true);
        }
        else
        {
            Console.WriteLine("Category exists - ElapsedTimeSampleCategory");
            return(false);
        }
    }

    private static void CreateCounters()
    {
        // Create the counter.
        PC = new PerformanceCounter("ElapsedTimeSampleCategory",
            "ElapsedTimeSample",
            false);
    }

    private static void CollectSamples(ArrayList samplesList)
    {
        long pcValue;
        DateTime Start;

        // Initialize the counter.
        QueryPerformanceCounter(out pcValue);
        PC.RawValue = pcValue;
        Start = DateTime.Now;

        // Loop for the samples.
        for (int j = 0; j < 1000; j++)
        {
            // Output the values.
            if ((j % 10) == 9)
            {
                Console.WriteLine($"NextValue() = {PC.NextValue()}");
                Console.WriteLine($"Actual elapsed time = {DateTime.Now.Subtract(Start)}");
                OutputSample(PC.NextSample());
                samplesList.Add( PC.NextSample() );
            }

            // Reset the counter on 100th iteration.
            if (j % 100 == 0)
            {
                QueryPerformanceCounter(out pcValue);
                PC.RawValue = pcValue;
                Start = DateTime.Now;
            }
            System.Threading.Thread.Sleep(50);
        }

        Console.WriteLine($"Elapsed time = {DateTime.Now.Subtract(Start)}");
    }
	
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

	// Reads the counter information to enable setting the RawValue.
	[DllImport("Kernel32.dll")]
	public static extern bool QueryPerformanceCounter(out long value);
}
//</snippet1>

#else
// Build sample for Whidbey or higher.

// <Snippet2>
using System;
using System.Diagnostics;
using System.Threading;

public class App
{
    public static void Main() => CollectSamples();

    public static void CollectSamples()
    {
        const string CategoryName = "ElapsedTimeSampleCategory";
        const string CounterName = "ElapsedTimeSample";

        // If the category doesn't exist, create it and exit.
        // Performance counters shouldn't be created and immediately used.
        // The counters take time to become enabled.
        // Create them before executing the application that uses them.
        // Execute this sample a second time to use the category.
        if (!PerformanceCounterCategory.Exists(CategoryName))
        {
            CounterCreationData elapsedTimeData = new()
            {
                CounterType = PerformanceCounterType.ElapsedTime,
                CounterName = CounterName
            };
            CounterCreationDataCollection counterData = new() { elapsedTimeData };

            // Create the category.
            PerformanceCounterCategory.Create(
                CategoryName,
                "Demonstrates ElapsedTime performance counter usage.",
                PerformanceCounterCategoryType.SingleInstance,
                counterData);
            // Return and rerun the application to use the new counters.
            return;
        }

        Console.WriteLine($"Category exists - {CategoryName}");

        // <Snippet3>
        // Create the performance counter.
        using PerformanceCounter performanceCounter = new(CategoryName, CounterName, false);
        // Initialize the counter.
        performanceCounter.RawValue = Stopwatch.GetTimestamp();
        // </Snippet3>

        DateTime start = DateTime.Now;

        // Loop for the samples.
        for (int j = 0; j < 100; j++)
        {
            // Output the values.
            if (j % 10 == 9)
            {
                Console.WriteLine($"NextValue() = {performanceCounter.NextValue()}");
                Console.WriteLine($"Actual elapsed time = {DateTime.Now.Subtract(start)}");
                OutputSample(performanceCounter.NextSample());
            }

            // Reset the counter on every 20th iteration.
            if (j % 20 == 0)
            {
                performanceCounter.RawValue = Stopwatch.GetTimestamp();
                start = DateTime.Now;
            }
            Thread.Sleep(50);
        }

        Console.WriteLine($"Elapsed time = {DateTime.Now.Subtract(start)}");
    }

    private static void OutputSample(CounterSample sample)
    {
        Console.WriteLine("\r\n+++++++++++");
        Console.WriteLine("Sample values - \r\n");
        Console.WriteLine($"   BaseValue        = {sample.BaseValue}");
        Console.WriteLine($"   CounterFrequency = {sample.CounterFrequency}");
        Console.WriteLine($"   CounterTimeStamp = {sample.CounterTimeStamp}");
        Console.WriteLine($"   CounterType      = {sample.CounterType}");
        Console.WriteLine($"   RawValue         = {sample.RawValue}");
        Console.WriteLine($"   SystemFrequency  = {sample.SystemFrequency}");
        Console.WriteLine($"   TimeStamp        = {sample.TimeStamp}");
        Console.WriteLine($"   TimeStamp100nSec = {sample.TimeStamp100nSec}");
        Console.WriteLine("++++++++++++++++++++++");
    }
}
// </Snippet2>
#endif
