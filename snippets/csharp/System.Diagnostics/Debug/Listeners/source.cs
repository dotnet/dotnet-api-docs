using System;
using System.Data;
using System.Diagnostics;

// <Snippet1>
/* Create a listener that outputs to the console screen, and
  * add it to the debug listeners. */
var myWriter = new TextWriterTraceListener(System.Console.Out);
Debug.Listeners.Add(myWriter);
// </Snippet1>
