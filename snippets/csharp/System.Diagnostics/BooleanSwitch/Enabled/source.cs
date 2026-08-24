using System;
using System.Diagnostics;

public class Form1
{
    // <Snippet1>
    // Class-level declaration.
    // Create a BooleanSwitch for data.
    private static readonly BooleanSwitch s_dataSwitch = new("Data", "DataAccess module");

    public static void MyMethod(string location)
    {
        // Insert code here to handle processing.
        if (s_dataSwitch.Enabled)
        {
            Console.WriteLine($"Error happened at {location}");
        }
    }

    // Run the method that writes an error message specifying the location of the error.
    public static void Main() => MyMethod("in Main");

    // </Snippet1>
}
