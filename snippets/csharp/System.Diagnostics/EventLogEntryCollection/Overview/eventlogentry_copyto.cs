// System.Diagnostics.EventLogEntryCollection
// System.Diagnostics.EventLogEntryCollection.CopyTo(EventLogEntry[],int)

/*
   The following example demonstrates the EventLogEntryCollection class and the
   CopyTo method of EventLogEntryCollection class. A new source for event log 'MyNewLog'
   is created. A new entry is created for 'MyNewLog'. The entries of EventLog are copied
   to an array.
*/

// <Snippet1>
using System;
using System.Collections;
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
    using (EventLog myEventLog2 = new())
    {
        myEventLog2.Source = "MySource";
        // Write an informational entry to the event log.
        myEventLog2.WriteEntry("Successfully created a new Entry in the Log");
    }

    // Create a new EventLog object.
    using EventLog myEventLog1 = new();
    myEventLog1.Log = myLogName;

    // Obtain the log entries of MyNewLog.
    EventLogEntryCollection myEventLogEntryCollection = myEventLog1.Entries;
    Console.WriteLine($"The number of entries in 'MyNewLog' = {myEventLogEntryCollection.Count}");

    // Display the Message property of EventLogEntry.
    for (int i = 0; i < myEventLogEntryCollection.Count; i++)
    {
        Console.WriteLine($"The Message of the EventLog is :{myEventLogEntryCollection[i].Message}");
    }
    // <Snippet2>

    // Copy the EventLog entries to an array of type EventLogEntry.
    EventLogEntry[] myEventLogEntryArray = new EventLogEntry[myEventLogEntryCollection.Count];
    myEventLogEntryCollection.CopyTo(myEventLogEntryArray, 0);
    IEnumerator myEnumerator = myEventLogEntryArray.GetEnumerator();
    while (myEnumerator.MoveNext())
    {
        EventLogEntry myEventLogEntry = (EventLogEntry)myEnumerator.Current;
        Console.WriteLine($"The LocalTime the Event is generated is {myEventLogEntry.TimeGenerated}");
    }
    // </Snippet2>
}
catch (Exception e)
{
    Console.WriteLine($"Exception:{e.Message}");
}
// </Snippet1>
