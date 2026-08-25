using System.Diagnostics;

public class WriteSampleBase
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod()
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        if (s_generalSwitch.TraceError)
            Trace.Write("My error message. ");

        // Write a second message if the TraceSwitch level is set to Verbose.
        if (s_generalSwitch.TraceVerbose)
            Trace.WriteLine("My second error message.");
    }

    // </Snippet1>
}
