// <snippet1>
using System;
using System.Diagnostics;

class InstDataColItemContainsMod
{
    // <snippet2>
    public static void Main(string[] args)
    {
        // These values can be used as arguments.
        string categoryName = "Process";
        string counterName = "Private Bytes";
        string instanceName = "Explorer";
        const string SingleInstanceName = "systemdiagnosticsperfcounterlibsingleinstance";

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            counterName = args[1];
            instanceName = args[2];
        }
        catch
        {
            // Ignore the exception from non-supplied arguments.
        }

        InstanceDataCollection idCol;
        try
        {
            // Get the InstanceDataCollectionCollection for this category.
            PerformanceCounterCategory pcc = new(categoryName);
            InstanceDataCollectionCollection idColCol = pcc.ReadCategory();

            // Get the InstanceDataCollection for this counter.
            idCol = idColCol[counterName];
            if (idCol == null)
            {
                throw new Exception("Counter does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred getting the InstanceDataCollection for category \"{categoryName}\", counter \"{counterName}\".\n{ex.Message}");
            return;
        }

        // If the instance name is empty, use the single-instance name.
        if (instanceName.Length == 0)
        {
            instanceName = SingleInstanceName;
        }

        // <snippet3>
        // Check whether this instance name exists by using the Contains method.
        if (!idCol.Contains(instanceName))
        // </snippet3>
        {
            Console.WriteLine($"Instance \"{instanceName}\" does not exist in counter \"{counterName}\", category \"{categoryName}\".");
            return;
        }

        // <snippet4>
        // Get the InstanceData object by using the indexer (Item property).
        InstanceData instData = idCol[instanceName];
        // </snippet4>

        Console.WriteLine($"CategoryName: {categoryName}");
        Console.WriteLine($"CounterName:  {counterName}");
        Console.WriteLine($"InstanceName: {instData.InstanceName}");
        Console.WriteLine($"RawValue:     {instData.RawValue}");
    }
    // </snippet2>
}
// </snippet1>
