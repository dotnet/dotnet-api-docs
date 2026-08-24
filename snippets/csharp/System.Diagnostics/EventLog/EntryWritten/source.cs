// <Snippet1>
using System;
using System.Diagnostics;
using System.Threading;

// This object is used to wait for events.
using AutoResetEvent signal = new(false);
using EventLog myNewLog = new("Application", ".", "testEventLogEvent");

myNewLog.EntryWritten += MyOnEntryWritten;
myNewLog.EnableRaisingEvents = true;
myNewLog.WriteEntry("Test message", EventLogEntryType.Information);
signal.WaitOne();

void MyOnEntryWritten(object source, EntryWrittenEventArgs e)
{
    Console.WriteLine("In event handler");
    signal.Set();
}

// </Snippet1>
