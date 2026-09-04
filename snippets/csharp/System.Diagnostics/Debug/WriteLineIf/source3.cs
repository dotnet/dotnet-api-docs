using System.Diagnostics;

public class Form4
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(object myObject, string category)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        Debug.WriteIf(s_generalSwitch.TraceError, "Invalid object for category. ");

        // Write a second message if the TraceSwitch level is set to Verbose.
        Debug.WriteLineIf(s_generalSwitch.TraceVerbose, myObject, category);
    }
    // </Snippet1>
}
