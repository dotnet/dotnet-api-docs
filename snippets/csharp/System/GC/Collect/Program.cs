//<Snippet1>
using System;

class CollectGenerationExample
{
    public static void Run(string[] args) => GC.Collect(2, GCCollectionMode.Optimized);
}
// </Snippet1>

class Program
{
    static void Main(string[] args)
    {
        CollectGenerationExample.Run(args);
        MyGCCollectClass.Run();
        CollectMemoryExample.Run();
        LohCompactionModeExample.Run();
    }
}
