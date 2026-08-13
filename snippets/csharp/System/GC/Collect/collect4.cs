using System;
using System.Runtime;

public class CollectMemoryExample
{
    public static void Run()
    {
        CreateObjects();
        Console.WriteLine($"Memory allocated before GC: {GC.GetTotalMemory(false):N0}");
        // <Snippet1>
        GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
        GC.Collect(2, GCCollectionMode.Forced, true, true);
        // </Snippet1>
        Console.WriteLine($"Memory allocated after GC: {GC.GetTotalMemory(false):N0}");
    }

    private static void CreateObjects()
    {
        string[] str = new string[10000];
        for (int ctr = 0; ctr < str.Length; ctr++)
        {
            string s1 = "word1";
            string s2 = "word2";
            str[ctr] = s1 + " " + s2;
        }
    }
}
