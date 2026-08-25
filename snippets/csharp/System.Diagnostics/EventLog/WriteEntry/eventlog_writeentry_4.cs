// System.Diagnostics.EventLog.WriteEntry(String,String,EventLogEntryType,Int32)

/*
 The following sample demonstrates the
 'WriteEntry(String,String,EventLogEntryType,Int32)' method of
 'EventLog' class. It writes an entry to a custom event log, "MyNewLog".
 It creates the source "MySource" if the source does not already exist.
*/

using System;
using System.Diagnostics;

class EventLog_WriteEntry_4
{
    public static void Run()
    {
        try
        {
            // <Snippet1>
            // Create the source if it doesn't already exist.
            if (!EventLog.SourceExists("MySource"))
            {
                // An event log source shouldn't be created and immediately used.
                // The source takes time to become enabled.
    // Create it before executing the application that uses it.
                // Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("MySource", "myNewLog");
                Console.WriteLine("Creating EventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created. Exit the application to allow it to be registered.
                return;
            }

            // Set the description for the event.
            string myMessage = "This is my event.";
            EventLogEntryType myEventLogEntryType = EventLogEntryType.Warning;
            int myApplicationEventId = 100;

            // Write the entry in the event log.
            Console.WriteLine("Writing to EventLog.. ");
            EventLog.WriteEntry(
                "MySource",
                myMessage,
                myEventLogEntryType,
                myApplicationEventId);
            // </Snippet1>
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception:{e.Message}");
        }
    }
}
