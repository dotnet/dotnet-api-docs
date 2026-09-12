using System.Diagnostics;

// <Snippet1>
// Class-level declaration.
// Create a TraceSwitch.
TraceSwitch generalSwitch = new("General", "Entire Application");

void MyErrorMethod()
{
    // Write the message if the TraceSwitch level is set to Error or higher.
    Debug.WriteIf(generalSwitch.TraceError, "My error message. ");

    // Write a second message if the TraceSwitch level is set to Verbose.
    Debug.WriteIf(generalSwitch.TraceVerbose, "My second error message.");
}
// </Snippet1>
