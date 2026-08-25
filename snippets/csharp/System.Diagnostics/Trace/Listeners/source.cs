using System.Diagnostics;

// <Snippet1>
/* Create a ConsoleTraceListener and add it to the trace listeners. */
ConsoleTraceListener myWriter = new();
Trace.Listeners.Add(myWriter);

// </Snippet1>
