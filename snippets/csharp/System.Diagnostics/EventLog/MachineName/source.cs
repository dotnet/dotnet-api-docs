// <Snippet1>
using System;
using System.Diagnostics;

using EventLog myNewLog = new()
{
    Log = "NewEventLog",
    MachineName = "MyServer"
};

foreach (EventLogEntry entry in myNewLog.Entries)
{
    Console.WriteLine($"\tEntry: {entry.Message}");
}

// </Snippet1>
