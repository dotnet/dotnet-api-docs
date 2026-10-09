using System.Diagnostics;

public class WriteSample1
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(object myObject)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        if (s_generalSwitch.TraceError)
            Trace.Write(myObject);

        // Write a second message if the TraceSwitch level is set to Verbose.
        if (s_generalSwitch.TraceVerbose)
            Trace.WriteLine(" is not a valid value for this method.");
    }

    // </Snippet1>
}
