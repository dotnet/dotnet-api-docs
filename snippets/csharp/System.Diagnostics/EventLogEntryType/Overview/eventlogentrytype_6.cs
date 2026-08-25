// System.Diagnostics.EventLogEntryType
// System.Diagnostics.EventLogEntryType.Error
// System.Diagnostics.EventLogEntryType.Warning
// System.Diagnostics.EventLogEntryType.Information
// System.Diagnostics.EventLogEntryType.FailureAudit
// System.Diagnostics.EventLogEntryType.SuccessAudit

/* The following program demonstrates 'Error', 'Warning',
   'Information', 'FailureAudit', and 'SuccessAudit' members of
   the 'EventLogEntryType' enumeration. It creates a new source with a
   specified event log, ID, EventLogEntryType, and message if it doesn't exist.
*/

// <Snippet1>
using System;
using System.Diagnostics;

try
{
    string myMessage = "A new event is created.";
    Console.Write("Enter source name for new event (eg: Print ): ");
    string mySource = Console.ReadLine();
    Console.Write("Enter log name in which to write an event( eg: System ): ");
    string myLog = Console.ReadLine();
    // Check whether the source exists in the event log.
    if (!EventLog.SourceExists(mySource))
    {
        // Create a new source in a specified log on a system.
        // An event log source shouldn't be created and immediately used.
        // The source takes time to become enabled.
    // Create it before executing the application that uses it.
        // Execute this sample a second time to use the new source.
        EventLog.CreateEventSource(mySource, myLog);
        Console.WriteLine("Creating the event source, press the Enter key to exit the application, \n" +
            "then run the applicaton again to use the new event source.");
        Console.Read();
    }
    Console.WriteLine();
    Console.WriteLine("     Select type of event to write:");
    Console.WriteLine("       1.     Error ");
    Console.WriteLine("       2.     Warning");
    Console.WriteLine("       3.     Information");
    Console.WriteLine("       4.     FailureAudit");
    Console.WriteLine("       5.     SuccessAudit");
    Console.Write("Enter the choice(eg. 1): ");
    int myIntLog = Convert.ToInt32(Console.ReadLine());
    Console.Write("Enter ID with which to write an event( eg: 0-65535 ): ");
    int myID = Convert.ToInt32(Console.ReadLine());
    // <Snippet2>

    // Create an event log instance.
    using EventLog myEventLog = new(myLog);
    // Initialize the Source property of the obtained instance.
    myEventLog.Source = mySource;
    switch (myIntLog)
    {
        case 1:
            // Write an Error entry in the specified event log.
            myEventLog.WriteEntry(myMessage, EventLogEntryType.Error, myID);
            break;
        case 2:
            // Write a Warning entry in the specified event log.
            myEventLog.WriteEntry(myMessage, EventLogEntryType.Warning, myID);
            break;
        case 3:
            // Write an Information entry in the specified event log.
            myEventLog.WriteEntry(myMessage, EventLogEntryType.Information, myID);
            break;
        case 4:
            // Write a FailureAudit entry in the specified event log.
            myEventLog.WriteEntry(myMessage, EventLogEntryType.FailureAudit, myID);
            break;
        case 5:
            // Write a SuccessAudit entry in the specified event log.
            myEventLog.WriteEntry(myMessage, EventLogEntryType.SuccessAudit, myID);
            break;
        default:
            Console.WriteLine("Error: Failed to create an event in event log.");
            break;
    }
    Console.WriteLine($"A new event in log '{myEventLog.Log}' with ID '{myID}' is successfully written into event log.");
    // </Snippet2>
}
catch (Exception e)
{
    Console.WriteLine($"Exception: {e.Message}");
}
// </Snippet1>
