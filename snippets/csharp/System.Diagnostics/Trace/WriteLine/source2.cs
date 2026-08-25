using System.Diagnostics;

public class WriteLineSample2
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(object myObject, string category)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        if (s_generalSwitch.TraceError)
            Trace.Write("Invalid object for category. ");

        // Write a second message if the TraceSwitch level is set to Verbose.
        if (s_generalSwitch.TraceVerbose)
            Trace.WriteLine(myObject, category);
    }

    // </Snippet1>
}
