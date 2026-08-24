// <Snippet1>
using System;
using System.Diagnostics;

// Create the source, if it doesn't already exist.
if (!EventLog.SourceExists("MySource", "MyServer"))
{
    // An event log source shouldn't be created and immediately used.
    // There is a latency time to enable the source, so it should be created
    // before the application that uses the source runs.
    // Execute this sample a second time to use the new source.
    EventLog.CreateEventSource("MySource", "MyNewLog", "MyServer");
    Console.WriteLine("CreatingEventSource");
    Console.WriteLine("Exiting, execute the application a second time to use the source.");
    // The source is created. Exit the application to allow it to be registered.
    return;
}

// Create an EventLog instance and assign its source.
using EventLog myLog = new()
{
    Source = "MySource"
};

// Write an informational entry to the event log.
myLog.WriteEntry("Writing to event log.");

Console.WriteLine("Message written to event log.");

// </Snippet1>
