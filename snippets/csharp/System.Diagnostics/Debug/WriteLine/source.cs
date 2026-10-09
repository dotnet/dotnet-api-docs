using System.Diagnostics;

// <Snippet1>
// Class-level declaration.
// Create a TraceSwitch.
TraceSwitch generalSwitch = new("General", "Entire Application");

void MyErrorMethod()
{
    // Write the message if the TraceSwitch level is set to Error or higher.
    if (generalSwitch.TraceError)
    {
        Debug.Write("My error message. ");
    }

    // Write a second message if the TraceSwitch level is set to Verbose.
    if (generalSwitch.TraceVerbose)
    {
        Debug.WriteLine("My second error message.");
    }
}
// </Snippet1>
