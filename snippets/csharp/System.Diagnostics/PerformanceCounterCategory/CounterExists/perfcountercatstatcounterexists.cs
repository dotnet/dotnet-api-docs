// <snippet7>
using System;
using System.Diagnostics;

class PerfCounterCatStatCountExistsMod
{
    // <snippet8>
    public static void Run(string[] args)
    {
        string categoryName = "";
        string counterName = "";
        string machineName = "";

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            counterName = args[1];
            machineName = args[2] == "." ? "" : args[2];
        }
        catch (Exception)
        {
            // Ignore the exception from non-supplied arguments.
        }

        try
        {
            // Check whether the specified counter exists.
            // Use the static forms of the CounterExists method.
            bool objectExists = machineName.Length == 0
                ? PerformanceCounterCategory.CounterExists(counterName, categoryName)
                : PerformanceCounterCategory.CounterExists(counterName, categoryName, machineName);

            // Tell the user whether the counter exists.
            string location = machineName.Length > 0 ? $"computer \"{machineName}\"." : "this computer.";
            Console.WriteLine($"Counter \"{counterName}\" {(objectExists ? "exists" : "does not exist")} in category \"{categoryName}\" on {location}");
        }
        catch (Exception ex)
        {
            string location = machineName.Length > 0 ? $"computer \"{machineName}\"." : "this computer.";
            Console.WriteLine($"Unable to check for the existence of counter \"{counterName}\" in category \"{categoryName}\" on {location}\n{ex.Message}");
        }
    }
    // </snippet8>
}
// </snippet7>
