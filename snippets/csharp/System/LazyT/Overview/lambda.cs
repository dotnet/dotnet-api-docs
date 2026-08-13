using System;
using System.Threading;
using LargeObject = LargeObjectOverviewExample2;

class LazyOverviewExample2
{
    static Lazy<LargeObject> lazyLargeObject = null;

    public static void Run()
    {
        //<SnippetInitWithLambda>
        lazyLargeObject = new Lazy<LargeObject>(() =>
        {
            LargeObject large = new(Thread.CurrentThread.ManagedThreadId);
            // Perform additional initialization here.
            return large;
        });
        //</SnippetInitWithLambda>

        Console.WriteLine(
            "\r\nLargeObject is not created until you access the Value property of the lazy" +
            "\r\ninitializer. Press Enter to create LargeObject.");
        Console.ReadLine();

        // Create and start 3 threads, each of which uses LargeObject.
        Thread[] threads = new Thread[3];
        for (int i = 0; i < 3; i++)
        {
            threads[i] = new(ThreadProc);
            threads[i].Start();
        }

        // Wait for all 3 threads to finish.
        foreach (Thread t in threads)
        {
            t.Join();
        }

        Console.WriteLine("\r\nPress Enter to end the program");
        Console.ReadLine();
    }

    static void ThreadProc(object state)
    {
        LargeObject large = lazyLargeObject.Value;

        // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the
        //            object after creation. You must lock the object before accessing it,
        //            unless the type is thread safe. (LargeObject is not thread safe.)
        lock (large)
        {
            large.Data[0] = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Initialized by thread {0}; last used by thread {1}.",
                large.InitializedBy, large.Data[0]);
        }
    }
}

class LargeObjectOverviewExample2
{
    public int InitializedBy => initBy;

    int initBy = 0;
    public LargeObjectOverviewExample2(int initializedBy)
    {
        initBy = initializedBy;
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy);
    }

    public long[] Data = new long[100000000];
}
