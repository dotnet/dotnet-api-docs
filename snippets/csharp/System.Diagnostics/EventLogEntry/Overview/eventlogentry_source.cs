// System.Diagnostics.EventLogEntry.EntryType
// System.Diagnostics.EventLogEntry.Source

/*
The following example demonstrates the properties 'EntryType' and 'Source'
of the class 'EventLogEntry'.
A new instance of 'EventLog' class is created and is associated to existing
System Log file of local machine. User selects the event type and the latest
entry in the log file of that type and its source is displayed.
*/
// <Snippet1>
// <Snippet2>
using System;
using System.Diagnostics;

using EventLog myEventLog = new("System", ".");
Console.WriteLine("1:Error");
Console.WriteLine("2:Information");
Console.WriteLine("3:Warning");
Console.WriteLine("Select the Event Type");
int myOption = Convert.ToInt32(Console.ReadLine());
EventLogEntryType? myEventType = myOption switch
{
    1 => EventLogEntryType.Error,
    2 => EventLogEntryType.Information,
    3 => EventLogEntryType.Warning,
    _ => null
};

EventLogEntryCollection myLogEntryCollection = myEventLog.Entries;
int myCount = myLogEntryCollection.Count;
// Iterate through all EventLogEntry instances in EventLog.
for (int i = myCount - 1; i > -1; i--)
{
    EventLogEntry myLogEntry = myLogEntryCollection[i];
    // Select the entry that has the desired EventType.
    if (myLogEntry.EntryType == myEventType)
    {
        // Display the source of the event.
        Console.WriteLine($"{myLogEntry.Source} was the source of last event of type {myLogEntry.EntryType}");
        return;
    }
}
// </Snippet2>
// </Snippet1>
