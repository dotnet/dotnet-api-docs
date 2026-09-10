// <snippet1>
using System;
using System.Diagnostics;

class PerfCounterCatGetCatMod
{
    // <snippet2>
    public static void Run(string[] args)
    {
        string machineName = "";

        // Copy the machine name argument into the local variable.
        try
        {
            machineName = args[0] == "." ? "" : args[0];
        }
        catch (Exception)
        {
        }

        // Generate a list of categories registered on the specified computer.
        PerformanceCounterCategory[] categories;
        try
        {
            categories = machineName.Length > 0
                ? PerformanceCounterCategory.GetCategories(machineName)
                : PerformanceCounterCategory.GetCategories();
        }
        catch (Exception ex)
        {
            string location = machineName.Length > 0 ? $"computer \"{machineName}\":" : "this computer:";
            Console.WriteLine($"Unable to get categories on {location}");
            Console.WriteLine(ex.Message);
            return;
        }

        string registeredLocation = machineName.Length > 0 ? $"computer \"{machineName}\":" : "this computer:";
        Console.WriteLine($"These categories are registered on {registeredLocation}");

        // Create and sort an array of category names.
        string[] categoryNames = new string[categories.Length];
        for (int i = 0; i < categories.Length; i++)
        {
            categoryNames[i] = categories[i].CategoryName;
        }
        Array.Sort(categoryNames);

        for (int i = 0; i < categories.Length; i++)
        {
            Console.WriteLine($"{i + 1,4} - {categoryNames[i]}");
        }
    }
    // </snippet2>
}
// </snippet1>
