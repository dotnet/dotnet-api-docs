﻿//<Snippet1>
using System;
using System.Management;

// This example shows synchronous consumption of events.
// The client is blocked while waiting for events.

public class EventWatcherPolling
{
    public static int Main(string[] args)
    {
        // Create event query to be notified within 1 second of
        // a change in a service
        string query = "SELECT * FROM" +
            " __InstanceCreationEvent WITHIN 1 " +
            "WHERE TargetInstance isa \"Win32_Process\"";

        // Event options
        EventWatcherOptions eventOptions = new
            EventWatcherOptions();
        eventOptions.Timeout = System.TimeSpan.MaxValue;
        // return after 1 event is received
        eventOptions.BlockSize = 1;

        // Initialize an event watcher and subscribe to events
        // that match this query
        ManagementEventWatcher watcher =
            new ManagementEventWatcher("root\\CIMV2", query,
            eventOptions);

        // Block until the next event occurs
        // Note: this can be done in a loop if waiting for
        //        more than one occurrence
        Console.WriteLine(
            "Open an application (notepad.exe) to trigger an event.");
        ManagementBaseObject e = watcher.WaitForNextEvent();

        //Display information from the event
        Console.WriteLine(
            "Process {0} has been created, path is: {1}",
            ((ManagementBaseObject)e
            ["TargetInstance"])["Name"],
            ((ManagementBaseObject)e
            ["TargetInstance"])["ExecutablePath"]);

        //Cancel the subscription
        watcher.Stop();
        return 0;
    }
}
//</Snippet1>