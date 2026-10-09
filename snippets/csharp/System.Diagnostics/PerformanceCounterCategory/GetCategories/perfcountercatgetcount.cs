// <snippet3>
using System;
using System.Diagnostics;

class PerfCounterCatGetCountMod
{
    // <snippet4>
    public static void Run(string[] args)
    {
        string categoryName = "";
        string machineName = "";
        string instanceName = "";

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            machineName = args[1] == "." ? "" : args[1];
            instanceName = args[2];
        }
        catch (Exception)
        {
            // Ignore the exception from non-supplied arguments.
        }

        PerformanceCounter[] counters;
        try
        {
            // Create the appropriate PerformanceCounterCategory object.
            PerformanceCounterCategory pcc = machineName.Length > 0
                ? new(categoryName, machineName)
                : new(categoryName);

            // Get the counters for this instance or a single instance of the selected category.
            counters = instanceName.Length > 0
                ? pcc.GetCounters(instanceName)
                : pcc.GetCounters();
        }
        catch (Exception ex)
        {
            string categoryDescription = instanceName.Length > 0
                ? $"instance \"{instanceName}\" in category"
                : "single-instance category";
            string location = machineName.Length > 0 ? $"computer \"{machineName}\":" : "this computer:";
            Console.WriteLine($"Unable to get counter information for {categoryDescription} \"{categoryName}\" on {location}");
            Console.WriteLine(ex.Message);
            return;
        }

        // Display the counter names if GetCounters was successful.
        string counterDescription = instanceName.Length > 0
            ? $"instance \"{instanceName}\" of"
            : "single instance";
        string registeredLocation = machineName.Length > 0 ? $"computer \"{machineName}\":" : "this computer:";
        Console.WriteLine($"These counters exist in {counterDescription} category {categoryName} on {registeredLocation}");

        // Display a numbered list of the counter names.
        for (int i = 0; i < counters.Length; i++)
        {
            Console.WriteLine($"{i + 1,4} - {counters[i].CounterName}");
            counters[i].Dispose();
        }
    }
    // </snippet4>
}
// </snippet3>
