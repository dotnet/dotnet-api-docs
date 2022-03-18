﻿using System.Diagnostics;

// <Snippet1>
// Create a trace listener for the event log.
EventLogTraceListener myTraceListener = new EventLogTraceListener("myEventLogSource");

// Add the event log trace listener to the collection.
Trace.Listeners.Add(myTraceListener);

// Write output to the event log.
Trace.WriteLine("Test output");
// </Snippet1>
