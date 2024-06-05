﻿using System;
using System.Data;
using System.Diagnostics;

class Class1
{
    public static void Main() { }

    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    static TraceSwitch generalSwitch = new TraceSwitch("General", "Entire Application");

    static public void MyErrorMethod(Object myObject, string category)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        if (generalSwitch.TraceError)
            Debug.Write(myObject, category);

        // Write a second message if the TraceSwitch level is set to Verbose.
        if (generalSwitch.TraceVerbose)
            Debug.WriteLine(" Object is not valid for this category.");
    }
    // </Snippet1>
}
