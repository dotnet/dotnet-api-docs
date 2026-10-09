using System;
using System.Runtime;

public class LohCompactionModeExample
{
    public static void Run()
    {
        // <Snippet1>
        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
        GC.Collect();
        // </Snippet1>
    }
}
