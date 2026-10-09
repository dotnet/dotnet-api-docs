// <Snippet1>
#define TRACE

using System;
using System.Diagnostics;
using System.IO;

public class TextWriterTraceListenerSample
{
    public static void Run()
    {
        // Create a file for output named TestFile.txt.
        string myFileName = "TestFile.txt";
        using StreamWriter myOutputWriter = new(myFileName, true);

        // Add a TextWriterTraceListener for the file.
        using TextWriterTraceListener myTextListener =
            new TextWriterTraceListener(myOutputWriter);
        Trace.Listeners.Add(myTextListener);

        // Write trace output to all trace listeners.
        Trace.WriteLine($"{DateTime.Now} - Trace output");

        // Remove and close the file writer/trace listener.
        myTextListener.Flush();
        Trace.Listeners.Remove(myTextListener);
    }
}
// </Snippet1>
