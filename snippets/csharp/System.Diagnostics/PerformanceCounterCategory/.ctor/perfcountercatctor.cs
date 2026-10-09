// <snippet3>
using System;
using System.Diagnostics;

class PerfCounterCatCtorMod
{
    // <snippet4>
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

        // Create a PerformanceCounterCategory object using the appropriate constructor.
        PerformanceCounterCategory pcc = categoryName.Length == 0
            ? new PerformanceCounterCategory()
            : machineName.Length == 0
                ? new PerformanceCounterCategory(categoryName)
                : new PerformanceCounterCategory(categoryName, machineName);

        // Display the properties of the PerformanceCounterCategory object.
        try
        {
            Console.WriteLine($"  Category:  {pcc.CategoryName}");
            Console.WriteLine($"  Computer:  {pcc.MachineName}");
            Console.WriteLine($"  Help text: {pcc.CategoryHelp}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error getting the properties of the PerformanceCounterCategory object:");
            Console.WriteLine(ex.Message);
        }
    }
    // </snippet4>
}
// </snippet3>
