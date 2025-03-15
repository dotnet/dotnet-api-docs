// <Snippet1>
using System;
using System.Threading;

class Program
{
    [ThreadStatic]
    private static string? _requestId;

    static void Main()
    {
        Thread thread1 = new Thread(ProcessRequest);
        Thread thread2 = new Thread(ProcessRequest);

        thread1.Start("REQ-001");
        thread2.Start("REQ-002");

        thread1.Join();
        thread2.Join();

        Console.WriteLine("Main thread execution completed.");
    }

    static void ProcessRequest(object? requestId)
    {
        // Assign the request ID to the thread-static field
        _requestId = requestId as string;

        // Simulate request processing across multiple method calls
        PerformDatabaseOperation();
        PerformLogging();
    }

    static void PerformDatabaseOperation()
    {
        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId}: Processing DB operation for request {_requestId}");
    }

    static void PerformLogging()
    {
        Console.WriteLine($"Thread {Environment.CurrentManagedThreadId}: Logging request {_requestId}");
    }
}
// </Snippet1>
