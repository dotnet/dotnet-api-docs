// <Snippet1>
using System;
using System.Diagnostics;

using EventLog myLog = new()
{
    Log = "MyNewLog"
};

foreach (EventLogEntry entry in myLog.Entries)
{
    Console.WriteLine($"\tEntry: {entry.Message}");
}

// </Snippet1>
