using System.Diagnostics;


public class Form3
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(object myObject, string category)
    {
        // Write the message if the TraceSwitch level is set to Verbose.
        Debug.WriteIf(s_generalSwitch.TraceVerbose,
            $"{myObject.ToString()} is not a valid object for category: ", category);

        // Write a second message if the TraceSwitch level is set to Error or higher.
        Debug.WriteLineIf(s_generalSwitch.TraceError, " Please use a different category.");
    }
    // </Snippet1>
}
