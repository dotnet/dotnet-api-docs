// <snippet1>
using System;
using System.Collections;
using System.Diagnostics;

class InstDataColColItemContainsMod
{
    // <snippet2>
    public static void Main(string[] args)
    {
        // The following values can be used as arguments.
        string categoryName = "Process";
        string counterName = "Private Bytes";

        // Copy the supplied arguments into the local variables.
        try
        {
            categoryName = args[0];
            counterName = args[1];
        }
        catch
        {
            // Ignore the exception from non-supplied arguments.
        }

        InstanceDataCollectionCollection idColCol;
        try
        {
            // Get the InstanceDataCollectionCollection for this category.
            PerformanceCounterCategory pcc = new(categoryName);
            idColCol = pcc.ReadCategory();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred getting the InstanceDataCollection for category \"{categoryName}\".\n{ex.Message}");
            return;
        }

        // <snippet3>
        // Check whether this counter name exists by using the Contains method.
        if (!idColCol.Contains(counterName))
        // </snippet3>
        {
            Console.WriteLine($"Counter \"{counterName}\" does not exist in category \"{categoryName}\".");
            return;
        }

        // <snippet4>
        // Get the counter's InstanceDataCollection by using the indexer (Item property).
        InstanceDataCollection countData = idColCol[counterName];
        // </snippet4>

        ICollection idColKeys = countData.Keys;
        string[] idColKeysArray = new string[idColKeys.Count];
        idColKeys.CopyTo(idColKeysArray, 0);

        Console.WriteLine($"Counter \"{counterName}\" of category \"{categoryName}\" has {idColKeys.Count} instances.");

        // Display the instance names for this counter.
        for (int i = 0; i < idColKeysArray.Length; i++)
        {
            Console.WriteLine($"{i + 1,4} -- {idColKeysArray[i]}");
        }
    }
    // </snippet2>
}
// </snippet1>
