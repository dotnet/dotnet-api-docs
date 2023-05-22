module runsynchronously1
// <Snippet1>
open System
open System.Threading
open System.Threading.Tasks

printfn $"Application executing on thread {Thread.CurrentThread.ManagedThreadId}"

let asyncTask =
    Task.Run(fun () ->
        printfn $"Task {Task.CurrentId} (asyncTask) executing on Thread {Thread.CurrentThread.ManagedThreadId}"
        let mutable sum = 0L

        for i = 1 to 1000000 do
            sum <- sum + int64 i

        sum)

let syncTask =
    new Task<int64>(fun () ->
        printfn $"Task {Task.CurrentId} (syncTask) executing on Thread {Thread.CurrentThread.ManagedThreadId}"
        let mutable sum = 0L

        for i = 1 to 1000000 do
            sum <- sum + int64 i

        sum)

syncTask.RunSynchronously()
printfn $"\nTask {syncTask.Id} returned {syncTask.Result:N0}"
printfn $"Task {asyncTask.Id} returned {asyncTask.Result:N0}"

// The example displays the following output:
//       Application executing on thread 1
//       Task 1 (syncTask) executing on Thread 1
//       Task 2 (asyncTask) executing on Thread 3
//       1 status: RanToCompletion
//       2 status: RanToCompletion
//
//       Task 2 returned 500,000,500,000
//       Task 1 returned 500,000,500,000
// </Snippet1>
