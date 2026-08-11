
using System;
using System.Runtime;

public class Example
{
    public static void Main()
    {
        // <Snippet1>
        if (GCSettings.LatencyMode == GCLatencyMode.NoGCRegion)
            GC.EndNoGCRegion();
        // </Snippet1>
    }
}
