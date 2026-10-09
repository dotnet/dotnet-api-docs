// <Snippet1>
using System;
using System.Diagnostics;

// Create the source if it doesn't already exist.
if (!EventLog.SourceExists("MySource"))
{
    // An event log source shouldn't be created and immediately used.
    // The source takes time to become enabled.
    // Create it before executing the application that uses it.
    // Execute this sample a second time to use the new source.
    EventLog.CreateEventSource("MySource", "MyNewLog");
    Console.WriteLine("CreatingEventSource");
    Console.WriteLine("Exiting, execute the application a second time to use the source.");
    // The source is created. Exit the application to allow it to be registered.
    return;
}

// Create an EventLog instance and assign its source.
using EventLog myLog = new();
myLog.Source = "MySource";

// Write an informational entry to the event log.
myLog.WriteEntry("Writing to event log.");
Console.WriteLine("Message written to event log.");
// </Snippet1>
