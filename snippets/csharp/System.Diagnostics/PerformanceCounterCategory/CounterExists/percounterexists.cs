// <snippet5>
using System;
using System.Diagnostics;

class PerfCounterCatDeleteMod
{
    // <snippet6>
    public static void Run(string[] args)
    {
        string categoryName = "";

        // Copy the supplied argument into the local variable.
        try
        {
            categoryName = args[0];
        }
        catch (Exception)
        {
        }

        // Delete the specified category.
        try
        {
            PerformanceCounterCategory.Delete(categoryName);
            Console.WriteLine($"Category \"{categoryName}\" deleted from this computer.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unable to delete category \"{categoryName}\" from this computer:\n{ex.Message}");
        }
    }
    // </snippet6>
}
// </snippet5>
