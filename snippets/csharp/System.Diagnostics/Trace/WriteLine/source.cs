using System.Diagnostics;

public class WriteLineSampleBase
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(object myObject)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        if (s_generalSwitch.TraceError)
            Trace.Write("Invalid object. ");

        // Write a second message if the TraceSwitch level is set to Verbose.
        if (s_generalSwitch.TraceVerbose)
            Trace.WriteLine(myObject);
    }

    // </Snippet1>
}
