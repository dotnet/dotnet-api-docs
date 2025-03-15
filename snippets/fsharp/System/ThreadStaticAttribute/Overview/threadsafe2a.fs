// <Snippet1>
open System
open System.Threading

type ThreadLocal() =
    [<ThreadStatic; DefaultValue>]
    static val mutable private requestId: string option

    static member PerformLogging() =
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Logging request {ThreadLocal.requestId.Value}")

    static member PerformDatabaseOperation() =
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Processing DB operation for request {ThreadLocal.requestId.Value}")

    static member ProcessRequest(reqId: obj) =
        ThreadLocal.requestId <- Some(reqId :?> string)
        ThreadLocal.PerformDatabaseOperation()
        ThreadLocal.PerformLogging()

[<EntryPoint>]
let main _ =
    let thread1 = Thread(ThreadStart(fun () -> ThreadLocal.ProcessRequest("REQ-001")))
    let thread2 = Thread(ThreadStart(fun () -> ThreadLocal.ProcessRequest("REQ-002")))

    thread1.Start()
    thread2.Start()
    thread1.Join()
    thread2.Join()

    Console.WriteLine("Main thread execution completed.")
    0
// </Snippet1>