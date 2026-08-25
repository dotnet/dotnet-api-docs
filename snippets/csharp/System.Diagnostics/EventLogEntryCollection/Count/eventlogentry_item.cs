// System.Diagnostics.EventLogEntryCollection.Count
// System.Diagnostics.EventLogEntryCollection.Item

/*
   The following example demonstrates 'Item' and 'Count' properties of the
   EventLogEntryCollection class. A new source for event log 'MyNewLog' is created.
   The program checks whether an event source exists. If the source already exists,
   it gets the log name associated with it. Otherwise, it creates a new event source.
   A new entry is created for 'MyNewLog'. Entries of 'MyNewLog' are obtained, and
   the count and messages are displayed.
*/

using System;
using System.Diagnostics;

try
{
    string myLogName = "MyNewLog";
    // Check whether the source exists.
    if (!EventLog.SourceExists("MySource"))
    {
        // Create the source.
        // An event log source shouldn't be created and immediately used.
        // The source takes time to become enabled.
    // Create it before executing the application that uses it.
        // Execute this sample a second time to use the new source.
        EventLog.CreateEventSource("MySource", myLogName);
        Console.WriteLine("Creating EventSource");
        Console.WriteLine("Exiting, execute the application a second time to use the source.");
        // The source is created. Exit the application to allow it to be registered.
        return;
    }

    // Get the EventLog associated with the source.
    myLogName = EventLog.LogNameFromSourceName("MySource", ".");

    // Create an EventLog instance and assign its source.
    using EventLog myEventLog2 = new();
    myEventLog2.Source = "MySource";
    // Write an entry to the event log.
    myEventLog2.WriteEntry("Successfully created a new Entry in the Log. ");

    // <Snippet1>
    // <Snippet2>
    // Create a new EventLog object.
    using EventLog myEventLog1 = new();
    myEventLog1.Log = myLogName;
    // Obtain the log entries of the event log.
    EventLogEntryCollection myEventLogEntryCollection = myEventLog1.Entries;
    Console.WriteLine($"The number of entries in 'MyNewLog' = {myEventLogEntryCollection.Count}");
    // Display the Message property of EventLogEntry.
    for (int i = 0; i < myEventLogEntryCollection.Count; i++)
    {
        Console.WriteLine($"The Message of the EventLog is :{myEventLogEntryCollection[i].Message}");
    }
    // </Snippet2>
    // </Snippet1>
}
catch (Exception e)
{
    Console.WriteLine($"Exception Caught!{e.Message}");
}
