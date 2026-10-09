// <snippet9>
using System;
using System.Diagnostics;

class PerfCounterCatStatInstExistsMod
{
    // <Snippet10>
    public static void Run(string[] args)
    {
        string categoryName = "";
        string instanceName = "";
        string machineName = "";
        const string SingleInstanceName = "systemdiagnosticsperfcounterlibsingleinstance";

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            instanceName = args[1];
            machineName = args[2] == "." ? "" : args[2];
        }
        catch (Exception)
        {
            // Ignore the exception from non-supplied arguments.
        }

        // Use the given instance name or the default single-instance name.
        if (instanceName.Length == 0)
        {
            instanceName = SingleInstanceName;
        }

        try
        {
            // Check whether the specified instance exists.
            // Use the static forms of the InstanceExists method.
            bool objectExists = machineName.Length == 0
                ? PerformanceCounterCategory.InstanceExists(instanceName, categoryName)
                : PerformanceCounterCategory.InstanceExists(instanceName, categoryName, machineName);

            // Tell the user whether the instance exists.
            string location = machineName.Length > 0 ? $"computer \"{machineName}\"." : "this computer.";
            Console.WriteLine($"Instance \"{instanceName}\" {(objectExists ? "exists" : "does not exist")} in category \"{categoryName}\" on {location}");
        }
        catch (Exception ex)
        {
            string location = machineName.Length > 0 ? $"computer \"{machineName}\":" : "this computer:";
            Console.WriteLine($"Unable to check for the existence of instance \"{instanceName}\" in category \"{categoryName}\" on {location}\n{ex.Message}");
        }
    }
    // </Snippet10>
}
// </snippet9>
