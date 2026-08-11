// <Snippet1>
using System;

class MyGCCollectClass
{
    private const int maxGarbage = 1000;

    public static void Run()
    {
        // Put some objects in memory.
        MyGCCollectClass.MakeSomeGarbage();
        Console.WriteLine($"Memory used before collection:       {GC.GetTotalMemory(false):N0}");

        // Collect all generations of memory.
        GC.Collect();
        Console.WriteLine($"Memory used after full collection:   {GC.GetTotalMemory(true):N0}");
    }

    static void MakeSomeGarbage()
    {
        Version vt;

        // Create objects and release them to fill up memory with unused objects.
        for (int i = 0; i < maxGarbage; i++)
        {
            vt = new();
        }
    }
}
// The output from the example resembles the following:
//       Memory used before collection:       79,392
//       Memory used after full collection:   52,640
// </Snippet1>
