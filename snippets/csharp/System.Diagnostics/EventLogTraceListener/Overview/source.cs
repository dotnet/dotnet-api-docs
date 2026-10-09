using System.Diagnostics;

// <Snippet1>
// Create a trace listener for the event log.
using EventLogTraceListener myTraceListener = new("myEventLogSource");

// Add the event log trace listener to the collection.
Trace.Listeners.Add(myTraceListener);

// Write output to the event log.
Trace.WriteLine("Test output");
// </Snippet1>
