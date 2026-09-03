using System.Diagnostics;

public class WriteLineIfSample1
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(string category)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        Trace.WriteIf(s_generalSwitch.TraceError, "My error message. ");

        // Write a second message if the TraceSwitch level is set to Verbose.
        Trace.WriteLineIf(s_generalSwitch.TraceVerbose, "My second error message.", category);
    }

    // </Snippet1>
}
