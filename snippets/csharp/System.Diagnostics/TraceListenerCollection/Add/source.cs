using System;
using System.Diagnostics;

// <Snippet1>
/* Create a listener, which outputs to the console screen, and
  * add it to the trace listeners. */
TextWriterTraceListener myWriter = new()
{
    Writer = System.Console.Out
};
Trace.Listeners.Add(myWriter);

// </Snippet1>
