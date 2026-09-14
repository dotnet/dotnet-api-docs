// <Snippet1>
using System;
using System.Diagnostics;

using EventLog myNewLog = new()
{
    Log = "MyCustomLog"
};

myNewLog.EntryWritten += MyOnEntryWritten;
myNewLog.EnableRaisingEvents = true;

Console.WriteLine("Press 'q' to quit.");
// Wait for the EntryWrittenEvent or a quit command.
while (Console.Read() != 'q')
{
    // Wait.
}

void MyOnEntryWritten(object source, EntryWrittenEventArgs e)
{
    Console.WriteLine($"Written: {e.Entry.Message}");
}

// </Snippet1>
