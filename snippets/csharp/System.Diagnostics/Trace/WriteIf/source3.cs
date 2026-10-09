using System.Diagnostics;

public class WriteIfSample3
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(object myObject, string category)
    {
        // Write the message if the TraceSwitch level is set to Verbose.
        Trace.WriteIf(s_generalSwitch.TraceVerbose, myObject, category);

        // Write a second message if the TraceSwitch level is set to Error or higher.
        Trace.WriteLineIf(s_generalSwitch.TraceError, " Object is not valid for this category.");
    }

    // </Snippet1>
}
