// <Snippet1>
using System.Diagnostics;

class MySample1
{
    public static void Run()
    {
        // Create an EventLog instance and assign its source.
        using EventLog myLog = new("MyNewLog");
        myLog.Source = "MyNewLogSource";

        // Write a warning entry to the event log.
        myLog.WriteEntry("Writing warning to event log.", EventLogEntryType.Warning);
    }
}
// </Snippet1>
