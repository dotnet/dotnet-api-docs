// <snippet3>
using System;
using System.Diagnostics;

class PerfCounterCatObjCountExistsMod
{
    // <snippet4>
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
            PerformanceCounterCategory pcc = machineName.Length == 0
                ? new(categoryName)
                : new(categoryName, machineName);

            // Check whether the specified counter exists.
            // Use the per-instance overload of CounterExists.
            bool objectExists = pcc.CounterExists(counterName);

            // Tell the user whether the counter exists.
            string location = machineName.Length > 0 ? $"computer \"{pcc.MachineName}\"." : "this computer.";
            Console.WriteLine($"Counter \"{counterName}\" {(objectExists ? "exists" : "does not exist")} in category \"{pcc.CategoryName}\" on {location}");
        }
        catch (Exception ex)
        {
            string location = machineName.Length > 0 ? $"computer \"{machineName}\"." : "this computer.";
            Console.WriteLine($"Unable to check for the existence of counter \"{counterName}\" in category \"{categoryName}\" on {location}\n{ex.Message}");
        }
    }
    // </snippet4>
}
// </snippet3>
