using System;
using System.Diagnostics;

public class Sample
{
    protected void Method()
    {
        // <Snippet1>

        TextWriterTraceListener myWriter = new()
        {
            Writer = System.Console.Out
        };
        Trace.Listeners.Add(myWriter);

        // </Snippet1>
    }
}
