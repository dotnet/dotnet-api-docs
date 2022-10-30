// <snippetUsage>
using System;
using System.Threading;
using System.Threading.Tasks;

class Example
{
    static async Task Main()
    {
        // Run asynchronous method and await its result
        Console.WriteLine("Running asynchronous method");
        await DoSomethingAsync(1);
        Console.WriteLine("Finished waiting for asynchronous method");

        Console.WriteLine();

        // Run something in a separate thread pool thread
        Console.WriteLine("Starting thread pool thread from main thread {0}", Thread.CurrentThread.ManagedThreadId);
        await Task.Run(async () =>
        {
            Console.WriteLine("Running in thread pool thread {0}", Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
        });
        Console.WriteLine("Thread pool thread completed");

        Console.WriteLine();

        // Run multiple tasks in parallel
        Console.WriteLine("Starting t2");
        Task t2 = DoSomethingAsync(2);
        await Task.Delay(500);
        Console.WriteLine("Starting t3");
        Task t3 = DoSomethingAsync(3);

        await Task.WhenAll(t2, t3);
        Console.WriteLine("t2 and t3 completed");

        Console.WriteLine();

        // Run blocking/synchronous work on a thread pool in order to keep the main thread unblocked
        Console.WriteLine("Starting blocking work on a different thread");
        Task t4 = Task.Run(() => DoSomethingBlocking());
        Console.WriteLine("Continue doing something else on the main thread");
        await t4;
        Console.WriteLine("Blocking work completed");
    }

    private static async Task DoSomethingAsync(int number)
    {
        Console.WriteLine("DoSomethingAsync({0}) started", number);
        await Task.Delay(2000);
        Console.WriteLine("DoSomethingAsync({0}) completed", number);
    }

    private static void DoSomethingBlocking()
    {
        Console.WriteLine("DoSomethingBlocking started");
        Thread.Sleep(2000);
        Console.WriteLine("DoSomethingBlocking completed");
    }
}
// This example displays output like the following:
//     Running asynchronous method
//     DoSomethingAsync(1) started
//     DoSomethingAsync(1) completed
//     Finished waiting for asynchronous method
//
//     Starting thread pool thread from main thread 21
//     Running in thread pool thread 13
//     Thread pool thread completed
//
//     Starting t2
//     DoSomethingAsync(2) started
//     Starting t3
//     DoSomethingAsync(3) started
//     DoSomethingAsync(2) completed
//     DoSomethingAsync(3) completed
//     t2 and t3 completed
//
//     Starting blocking work on a different thread
//     Continue doing something else on the main thread
//     DoSomethingBlocking started
//     DoSomethingBlocking completed
//     Blocking work completed
// </snippetUsage>
