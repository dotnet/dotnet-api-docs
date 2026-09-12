using System.Diagnostics;

class Class1
{
    public static void Main()
    {
    }

    // <Snippet1>
    // Class-level declaration.
    // Create a TraceSwitch.
    private static readonly TraceSwitch s_generalSwitch = new("General", "Entire Application");

    public static void MyErrorMethod(object myObject, string category)
    {
        // Write the message if the TraceSwitch level is set to Error or higher.
        if (s_generalSwitch.TraceError)
        {
            Debug.Write(myObject, category);
        }

        // Write a second message if the TraceSwitch level is set to Verbose.
        if (s_generalSwitch.TraceVerbose)
        {
            Debug.WriteLine(" Object is not valid for this category.");
        }
    }
    // </Snippet1>
}
