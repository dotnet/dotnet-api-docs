// <snippet1>
using System;
using System.Diagnostics;

class PerfCounterCatObjInstExistsMod
{
    // <snippet2>
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
            PerformanceCounterCategory pcc = machineName.Length == 0
                ? new(categoryName)
                : new(categoryName, machineName);

            // Check whether the instance exists.
            // Use the per-instance overload of InstanceExists.
            bool objectExists = pcc.InstanceExists(instanceName);

            // Tell the user whether the instance exists.
            string location = machineName.Length > 0 ? $"computer \"{pcc.MachineName}\"." : "this computer.";
            Console.WriteLine($"Instance \"{instanceName}\" {(objectExists ? "exists" : "does not exist")} in category \"{pcc.CategoryName}\" on {location}");
        }
        catch (Exception ex)
        {
            string location = machineName.Length > 0 ? $"computer \"{machineName}\":" : "this computer:";
            Console.WriteLine($"Unable to check for the existence of instance \"{instanceName}\" in category \"{categoryName}\" on {location}\n{ex.Message}");
        }
    }
    // </snippet2>
}
// </snippet1>
