// System.Diagnostics.EntryWrittenEventArgs.ctor()

/*
The following example demonstrates 'EntryWrittenEventArgs ()'
constructor of the 'EntryWrittenEventArgs' class. It creates a custom 'EventLog'
and writes an entry into it. Then creates an 'EntryWrittenEventArgs' object
using the first entry in the custom eventlog. This object is used to notify a message
 */

// <Snippet1>
using System;
using System.Diagnostics;

class MySample
{
    public static void Main()
    {
        try
        {
            using EventLog myNewLog = new()
            {
                Log = "MyNewLog",
                Source = "MySource"
            };
            // Create the source if it does not exist already.
            if (!EventLog.SourceExists("MySource"))
            {
                // An event log source should not be created and immediately used.
                // There is a latency time to enable the source, it should be created
                // prior to executing the application that uses the source.
                // Execute this sample a second time to use the new source.
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatingEventSource");
                Console.WriteLine("Exiting, execute the application a second time to use the source.");
                // The source is created.  Exit the application to allow it to be registered.
                return;
            }
            // Write an entry to the EventLog.
            myNewLog.WriteEntry("The Latest entry in the Event Log");
            int myEntries = myNewLog.Entries.Count;
            EventLogEntry entry = myNewLog.Entries[myEntries - 1];
            EntryWrittenEventArgs myEntryEventArgs = new();
            MyOnEntry(myNewLog, myEntryEventArgs);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception Raised{e.Message}");
        }
    }
    protected static void MyOnEntry(object source, EntryWrittenEventArgs e)
    {
        if (e.Entry is null)
        {
            Console.WriteLine("A new entry is written in MyNewLog.");
        }
    }
}
// </Snippet1>
