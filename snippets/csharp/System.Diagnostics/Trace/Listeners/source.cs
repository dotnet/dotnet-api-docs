using System;
using System.Data;
using System.Diagnostics;

// <Snippet1>
/* Create a ConsoleTraceListener and add it to the trace listeners. */
var myWriter = new ConsoleTraceListener();
Trace.Listeners.Add(myWriter);

// </Snippet1>
