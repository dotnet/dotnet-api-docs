// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;
using System.Timers;

public class PerfCounter1
{

    [STAThread]
    public static void Run(string[] args)
    {
        try
        {
            if (!PerformanceCounterCategory.Exists("Orders"))
            {
                // If the category does not exist, create the category and exit.
                // Performance counters should not be created and immediately used.
                // The counters take time to become enabled.
                // Create them before executing the application that uses them.

                // Create custom counters.
                Writer.CreateCounters();
                return;
            }
            Writer server = new();
            // Start the counters.
            server.StartCounters();
            Reader client = new();
            // Read the counters from the client.
            client.StartCounters();
            server.CloseTimer();
            client.Finish();
            Writer.DeleteCounters();
            Console.WriteLine("Press any key to exit.");
            Console.Read();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Sample failed with exception: {e}");
        }
    }

    public class Writer
    {
        private readonly System.Timers.Timer timer1;
        private PerformanceCounter counter1;
        private PerformanceCounter counter2;
        private PerformanceCounter counter3;
        private PerformanceCounter counter4;
        private int finalCount;

        public Writer()
        {
            timer1 = new(100);
            finalCount = 0;
            timer1.Elapsed += OnTimer1;
        }

        // <Snippet4>
        public static void CreateCounters()
        {
            // <Snippet2>
            CounterCreationData data1 = new("Trucks",
                "Number of orders", PerformanceCounterType.NumberOfItems32);
            CounterCreationData data2 = new("Rate of sales",
                "Orders/second", PerformanceCounterType.RateOfCountsPerSecond32);
            CounterCreationDataCollection ccds = new();
            ccds.Add(data1);
            ccds.Add(data2);
            Console.WriteLine("Creating Orders custom counter.");
            if (!PerformanceCounterCategory.Exists("Orders"))
            {
                PerformanceCounterCategory.Create("Orders",
                    "Processed orders",
                    PerformanceCounterCategoryType.MultiInstance,
                    ccds);
            }
            // </Snippet2>

            // <Snippet3>
            Console.WriteLine("Creating Inventory custom counter");
            if (!PerformanceCounterCategory.Exists("Inventory"))
            {
                PerformanceCounterCategory.Create("Inventory",
                    "Truck inventory",
                    PerformanceCounterCategoryType.SingleInstance,
                    "Trucks", "Number of trucks on hand");
            }
            // </Snippet3>
        }
        // </Snippet4>

        public void StartCounters()
        {
            Console.WriteLine(
                "Instantiating Custom Counter Orders, Trucks, United States");
            counter1 = new PerformanceCounter(
                "Orders", "Trucks", "United States", false);
            counter1.RawValue = 5;
            Console.WriteLine(
                "Instantiating Custom Counter Orders, Trucks, Europe");
            counter2 = new PerformanceCounter(
                "Orders", "Trucks", "Europe", false);
            counter2.RawValue = 10;
            Console.WriteLine(
                "Instantiating Custom Counter Orders, Rate of Sales, Total");
            counter3 = new PerformanceCounter(
                "Orders", "Rate of Sales", "Total", false);
            counter3.RawValue = 10;
            Console.WriteLine(
                "Instantiating Custom Counter Inventory, Trucks");
            counter4 = new PerformanceCounter(
                "Inventory", "Trucks", false);
            counter4.RawValue = 15;

            timer1.Start();
        }

        public void CloseTimer()
        {
            timer1.Close();
        }

        public static void DeleteCounters()
        {
            try
            {
                PerformanceCounterCategory.Delete("Orders");
                PerformanceCounterCategory.Delete("Inventory");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void OnTimer1(object sender, ElapsedEventArgs args)
        {
            try
            {
                counter1.IncrementBy(100);
                counter1.Increment();
                counter2.IncrementBy(50);
                counter2.Decrement();
                counter3.IncrementBy(1);
                counter4.IncrementBy(150);
                ++finalCount;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected exception thrown :{e}");
            }
        }
    }

    public class Reader
    {
        private readonly ManualResetEvent signal;
        private readonly System.Timers.Timer timer1;
        private PerformanceCounter counter1;
        private PerformanceCounter counter2;
        private PerformanceCounter counter3;
        private PerformanceCounter counter4;
        private int finalCount;

        public Reader()
        {
            signal = new(false);
            timer1 = new(500);
            finalCount = 0;
            timer1.Elapsed += OnTimer1;
        }

        public void Finish()
        {
            signal.WaitOne();
            timer1.Close();
            PerformanceCounter.CloseSharedResources();
        }

        private void OnTimer1(object sender, ElapsedEventArgs args)
        {
            try
            {
                lock (this)
                {
                    if (finalCount >= 10)
                        return;

                    float value1 = counter1.NextValue();
                    Console.WriteLine(
                                "Custom Counter Orders, Trucks, United States: {0}", value1);

                    float value2 = counter2.NextValue();
                    Console.WriteLine(
                        "Custom Counter Orders, Trucks, Europe: {0}", value2);

                    float value3 = counter3.NextValue();
                    Console.WriteLine(
                        "Custom Counter Orders, Rate of sales, United Total: {0}", value3);

                    float value4 = counter4.NextValue();
                    Console.WriteLine(
                        "Custom Counter Inventory, Trucks, United States: {0}", value4);

                    if (finalCount < 5)
                    {
                        ++finalCount;
                    }
                    else
                    {
                        ++finalCount;
                        signal.Set();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Sample failure :{e}");
                signal.Set();
            }
        }

        public void StartCounters()
        {
            Console.WriteLine(
                "Instantiating Custom Counter Orders, Trucks, United States");
            // Instantiate a counter with category "Orders", counter name "Trucks", and instance "United States".
            counter1 = new PerformanceCounter(
                "Orders", "Trucks", "United States");
            Console.WriteLine("Instantiating Custom Counter Orders, Trucks, Europe");
            // Instantiate a counter with category "Orders", counter name "Trucks", and instance "Europe".
            counter2 = new PerformanceCounter(
                "Orders", "Trucks", "Europe");
            Console.WriteLine("Instantiating Custom Counter Orders, Rate of Sales.");
            // Instantiate a counter with category "Orders", counter name "Rate of Sales", and a single instance.
            counter3 = new PerformanceCounter(
                "Orders", "Rate of Sales", "Total");
            Console.WriteLine("Instantiating Custom Counter Inventory, Trucks, Only instance.");
            // Instantiate a single instance counter, category "Inventory", counter name "Trucks".
            counter4 = new PerformanceCounter(
                "Inventory", "Trucks", false);

            timer1.Start();
        }
    }
}
// </Snippet1>
public static class Program
{
    public static void Main(string[] args)
    {
        PerfCounter1.Run(args);
    }
}
