//<snippet3>
using System;
using System.Diagnostics;

class TWTLConStringMod
{

    // args(0) is the specification of the trace log file.
    public static void Run(string[] args)
    {

        // Verify that a parameter was entered.
        if (args.Length == 0)
        {
            Console.WriteLine("Enter a trace file specification.");
        }
        else
        {
            // Create a TextWriterTraceListener object that takes a
            // file specification.
            TextWriterTraceListener textListener;
            try
            {
                textListener = new TextWriterTraceListener(args[0]);
                Trace.Listeners.Add(textListener);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating TextWriterTraceListener for trace " +
                    "file \"{0}\":\r\n{1}", args[0], ex.Message);
                return;
            }

            // Write these messages only to the TextWriterTraceListener.
            textListener.WriteLine("This is trace listener named \"" + textListener.Name + "\"");
            textListener.WriteLine("Trace written to a file: " +
                "\r\n    \"" + args[0] + "\"");

            // Write a message to all trace listeners.
            Trace.WriteLine($"This trace message written {DateTime.Now} to all listeners.");

            // Flush and close the output.
            Trace.Flush();
            textListener.Flush();
            textListener.Close();
        }
    }
}
//</snippet3>
