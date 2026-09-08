using System;
using System.Diagnostics;
using System.IO;

// <Snippet1>
public class Sample
{

    public static int Main(string[] args)
    {
        // Create a file for output named TestFile.txt.
        using Stream myFile = File.Create("TestFile.txt");

        /* Create a new text writer using the output stream, and add it to
         * the trace listeners. */
        using TextWriterTraceListener myTextListener = new(myFile);
        Trace.Listeners.Add(myTextListener);

        // Write output to the file.
        Trace.Write("Test output ");

        // Flush the output.
        Trace.Flush();
        Trace.Listeners.Remove(myTextListener);

        return 0;
    }
}
// </Snippet1>
