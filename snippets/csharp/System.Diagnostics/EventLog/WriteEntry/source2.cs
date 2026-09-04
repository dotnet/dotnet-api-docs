// <Snippet1>
using System.Diagnostics;

class MySample2
{
    public static void Run()
    {
        // Write a warning entry to the event log.
        EventLog.WriteEntry(
            "MySource",
            "Writing warning to event log.",
            EventLogEntryType.Warning);
    }
}
// </Snippet1>
