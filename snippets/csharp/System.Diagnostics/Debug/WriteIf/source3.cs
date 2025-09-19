using System;
using System.Data;
using System.Diagnostics;


public class Form4
{
    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    static TraceSwitch generalSwitch = new TraceSwitch("General", "Entire Application");

    static public void MyErrorMethod(Object myObject, string category)
    {
        // Write the message if the TraceSwitch level is set to Verbose.
        Debug.WriteIf(generalSwitch.TraceVerbose, myObject, category);

        // Write a second message if the TraceSwitch level is set to Error or higher.
        Debug.WriteLineIf(generalSwitch.TraceError, " Object is not valid for this category.");
    }
    // </Snippet1>
}
