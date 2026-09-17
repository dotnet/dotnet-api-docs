using System.Diagnostics;


public class Form2
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(object myObject)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        Debug.WriteIf(s_generalSwitch.TraceError, myObject);

        // Write a second message if the TraceSwitch level is set to Verbose.
        Debug.WriteLineIf(s_generalSwitch.TraceVerbose, " is not a valid value for this method.");
    }
    // </Snippet1>
}
