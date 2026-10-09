using System.Diagnostics;

public class WriteIfSample1
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(object myObject)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        Trace.WriteIf(s_generalSwitch.TraceError, myObject);

        // Write a second message if the TraceSwitch level is set to Verbose.
        Trace.WriteLineIf(s_generalSwitch.TraceVerbose, " is not a valid value for this method.");
    }

    // </Snippet1>
}
