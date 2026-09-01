using System;
using System.Diagnostics;

public class Form1
{
    // <Snippet1>
    // Class-level declaration.
    /* Create a TraceSwitch to use in the entire application. */
    private static readonly TraceSwitch s_mySwitch = new("General", "Entire Application");

    public static void MyMethod()
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        if (s_mySwitch.TraceError)
        {
            Console.WriteLine("My error message.");
        }

        // Write the message if the TraceSwitch level is set to Verbose.
        if (s_mySwitch.TraceVerbose)
        {
            Console.WriteLine("My second error message.");
        }
    }

    public static void Run(string[] args)
    {
        // Run the method that prints error messages based on the switch level.
        MyMethod();
    }

    // </Snippet1>
}
