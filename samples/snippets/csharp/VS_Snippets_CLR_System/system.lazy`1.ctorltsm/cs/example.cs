﻿//<SnippetAll>
using System;
using System.Threading;

class Program
{
    static Lazy<LargeObject> lazyLargeObject = null;

    static void Main()
    {
        // The lazy initializer is created here. LargeObject is not created until the
        // ThreadProc method executes.
        //<SnippetNewLazy>
        lazyLargeObject = new Lazy<LargeObject>(LazyThreadSafetyMode.PublicationOnly);
        //</SnippetNewLazy>

        // Create and start 3 threads, passing the same blocking event to all of them.
        ManualResetEvent startingGate = new ManualResetEvent(false);
        Thread[] threads = { new Thread(ThreadProc), new Thread(ThreadProc), new Thread(ThreadProc) };
        foreach (Thread t in threads)
        {
            t.Start(startingGate);
        }

        // Give all 3 threads time to start and wait, then release them all at once.
        Thread.Sleep(50);
        startingGate.Set();

        // Wait for all 3 threads to finish. (The order doesn't matter.)
        foreach (Thread t in threads)
        {
            t.Join();
        }

        Console.WriteLine(
            "\r\nThreads are complete. Running GC.Collect() to reclaim the extra instances.");

        GC.Collect();

        // Allow time for garbage collection, which happens asynchronously.
        Thread.Sleep(100);

        Console.WriteLine(
            "\r\nNote that all three threads used the instance that was not collected.");
        Console.WriteLine("Press Enter to end the program");
        Console.ReadLine();
    }

    static void ThreadProc(object state)
    {
        // Wait for the signal.
        ManualResetEvent waitForStart = (ManualResetEvent) state;
        waitForStart.WaitOne();

        //<SnippetValueProp>
        LargeObject large = lazyLargeObject.Value;
        //</SnippetValueProp>

        // The following line introduces an artificial delay, to exaggerate the race
        // condition.
        Thread.Sleep(5);

        // IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the
        //            object after creation. You must lock the object before accessing it,
        //            unless the type is thread safe. (LargeObject is not thread safe.)
        lock(large)
        {
            large.Data[0] = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("LargeObject was initialized by thread {0}; last used by thread {1}.",
                large.InitializedBy, large.Data[0]);
        }
    }
}

class LargeObject
{
    int initBy = -1;
    public int InitializedBy { get { return initBy; } }

    //<SnippetCtorFinalizer>
    public LargeObject()
    {
        initBy = Thread.CurrentThread.ManagedThreadId;
        Console.WriteLine("Constructor: Instance initializing on thread {0}", initBy);
    }

    ~LargeObject()
    {
        Console.WriteLine("Finalizer: Instance was initialized on {0}", initBy);
    }
    //</SnippetCtorFinalizer>

    public long[] Data = new long[100000000];
}

/* This example produces output similar to the following:

Constructor: Instance initializing on thread 4
Constructor: Instance initializing on thread 3
Constructor: Instance initializing on thread 5
LargeObject was initialized by thread 4; last used by thread 4.
LargeObject was initialized by thread 4; last used by thread 5.
LargeObject was initialized by thread 4; last used by thread 3.

Threads are complete. Running GC.Collect() to reclaim the extra instances.
Finalizer: Instance was initialized on 3
Finalizer: Instance was initialized on 5

Note that all three threads used the instance that was not collected.
Press Enter to end the program

Instance finalizing; initialized on 4
 */
//</SnippetAll>
