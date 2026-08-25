// <Snippet1>
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace EventLogSamples;

class CreateSourceSample
{
    [STAThread]
    static void Main(string[] args)
    {
        // <Snippet2>
        EventSourceCreationData mySourceData = new("", "");
        bool registerSource = true;

        // Process input parameters.
        if (args.Length > 0)
        {
            // Require at least the source name.
            mySourceData.Source = args[0];

            if (args.Length > 1)
            {
                mySourceData.LogName = args[1];
            }

            if (args.Length > 2)
            {
                mySourceData.MachineName = args[2];
            }

            if (args.Length > 3 && args[3].Length > 0)
            {
                mySourceData.MessageResourceFile = args[3];
            }
        }
        else
        {
            // Display a syntax help message.
            Console.WriteLine("Input:");
            Console.WriteLine(" source [event log] [machine name] [resource file]");
            registerSource = false;
        }

        // Set defaults for parameters missing input.
        if (mySourceData.MachineName.Length == 0)
        {
            // Default to the local computer.
            mySourceData.MachineName = ".";
        }

        if (mySourceData.LogName.Length == 0)
        {
            // Default to the Application log.
            mySourceData.LogName = "Application";
        }
        // </Snippet2>

        // Determine whether the source exists on the specified computer.
        if (!EventLog.SourceExists(mySourceData.Source, mySourceData.MachineName))
        {
            // Verify that the message file exists and the event log is local.
            if (!string.IsNullOrEmpty(mySourceData.MessageResourceFile))
            {
                if (mySourceData.MachineName == ".")
                {
                    if (!File.Exists(mySourceData.MessageResourceFile))
                    {
                        Console.WriteLine($"File {mySourceData.MessageResourceFile} not found - message file not set for source.");
                        registerSource = false;
                    }
                }
                else
                {
                    // For simplicity, don't allow setting the message file for a remote event log.
                    // To set the message and register the source remotely, use system-wide environment variables.
                    // Use variables that are valid on that computer, such as "%SystemRoot%\system32\myresource.dll".
                    Console.WriteLine("Message resource file ignored for remote event log.");
                    mySourceData.MessageResourceFile = string.Empty;
                }
            }
        }
        else
        {
            // Don't register the source because it already exists.
            registerSource = false;

            // Get the event log corresponding to the existing source.
            string sourceLog = EventLog.LogNameFromSourceName(
                mySourceData.Source,
                mySourceData.MachineName);

            // Determine whether the event source is registered for the specified log.
            if (sourceLog.ToUpper(CultureInfo.InvariantCulture) !=
                mySourceData.LogName.ToUpper(CultureInfo.InvariantCulture))
            {
                // An existing source is registered to write to a different event log.
                Console.WriteLine($"Warning: source {mySourceData.Source} is already registered to write to event log {sourceLog}");
            }
            else
            {
                // The source is already registered to write to the specified event log.
                Console.WriteLine($"Source {mySourceData.Source} already registered to write to event log {sourceLog}");
            }
        }

        if (registerSource)
        {
            // Register the new event source for the specified event log.
            Console.WriteLine($"Registering new source {mySourceData.Source} for event log {mySourceData.LogName}.");
            EventLog.CreateEventSource(mySourceData);
            Console.WriteLine("Event source was registered successfully!");
        }
    }
}
// </Snippet1>
