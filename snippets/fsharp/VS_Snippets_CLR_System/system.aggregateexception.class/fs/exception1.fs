// <Snippet1>
open System
open System.IO
open System.Threading.Tasks

let getAllFiles str =
    // Should throw an UnauthorizedAccessException exception.
    System.IO.Directory.GetFiles(str, "*.txt", System.IO.SearchOption.AllDirectories)

// Get a folder path whose directories should throw an UnauthorizedAccessException.
let path =
    let directory =
        Environment.SpecialFolder.UserProfile
        |> Environment.GetFolderPath
        |> Directory.GetParent
    directory.FullName

// Use this line to throw an exception that is not handled.
// let task1 = Task<string []>.Factory.StartNew(fun () -> raise (IndexOutOfRangeException()) )
let task1 = Task.Factory.StartNew(fun () -> getAllFiles (path))

let execute () =
    try
        task1.Wait()
    with
    | :? UnauthorizedAccessException -> printfn "Caught unauthorized access exception-await behavior"
    | :? AggregateException as ae ->
        printfn "Caught aggregate exception-Task.Wait behavior"

        ae.Handle (fun x ->
            match x with
            | :? UnauthorizedAccessException ->
                printfn "You do not have permission to access all folders in this path."
                printfn "See your network administrator or try another path."
                true
            | _ -> false)
    printfn $"""task1 Status: {if task1.IsCompleted then "Completed," else ""}{task1.Status}"""

execute ()

// The example displays the following output if the file access task is run:
//       You do not have permission to access all folders in this path.
//       See your network administrator or try another path.
//       task1 Status: Completed,Faulted
// It displays the following output if the second task is run:
//       Unhandled exception. System.AggregateException: One or more errors occurred. (Index was outside the bounds of the array.) (Index was outside the bounds of the array.)
//        ---> System.IndexOutOfRangeException: Index was outside the bounds of the array.
//          at Exception1.task1@19.Invoke()
//          at System.Threading.Tasks.Task`1.InnerInvoke()
//          at System.Threading.Tasks.Task.<>c.<.cctor>b__277_0(Object obj)
//          at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)   
//       --- End of stack trace from previous location ---
//          at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)   
//          at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot, Thread threadPoolThread)
//          --- End of inner exception stack trace ---
//          at System.AggregateException.Handle(Func`2 predicate)
//          at <StartupCode$exception1>.$Exception1.main@()
// </Snippet1>
