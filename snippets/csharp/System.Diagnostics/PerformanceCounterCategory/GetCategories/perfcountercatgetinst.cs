// <snippet5>
using System;
using System.Diagnostics;

class PerfCounterCatGetInstMod
{
    // <snippet6>
    public static void Run(string[] args)
    {
        string categoryName = "";
        string machineName = "";

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            machineName = args[1] == "." ? "" : args[1];
        }
        catch (Exception)
        {
            // Ignore the exception from non-supplied arguments.
        }

        try
        {
            // Create the appropriate PerformanceCounterCategory object.
            PerformanceCounterCategory pcc = machineName.Length > 0
                ? new(categoryName, machineName)
                : new(categoryName);

            // Get the instances associated with this category.
            string[] instances = pcc.GetInstanceNames();

            // If an empty array is returned, the category has a single instance.
            if (instances.Length == 0)
            {
                string location = machineName.Length > 0 ? $"computer \"{pcc.MachineName}\"" : "this computer";
                Console.WriteLine($"Category \"{pcc.CategoryName}\" on {location} is single-instance.");
                return;
            }

            // Otherwise, display the instances.
            string registeredLocation = machineName.Length > 0 ? $"computer \"{pcc.MachineName}\"." : "this computer:";
            Console.WriteLine($"These instances exist in category \"{pcc.CategoryName}\" on {registeredLocation}");

            Array.Sort(instances);
            for (int i = 0; i < instances.Length; i++)
            {
                Console.WriteLine($"{i + 1,4} - {instances[i]}");
            }
        }
        catch (Exception ex)
        {
            string location = machineName.Length > 0 ? $"computer \"{machineName}\":" : "this computer:";
            Console.WriteLine($"Unable to get instance information for category \"{categoryName}\" on {location}");
            Console.WriteLine(ex.Message);
        }
    }
    // </snippet6>
}
// </snippet5>
