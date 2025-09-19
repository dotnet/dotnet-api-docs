module AsyncHanderEx
// <Snippet3>
open System
open System.Threading.Tasks
open System.Timers

let handleTimer () =
    printfn "\nHandler not implemented..."
    raise (NotImplementedException()): Task

let timer = new Timer 1000
timer.Elapsed.AddHandler(fun sender e -> task { do! handleTimer () } |> ignore)
timer.Start()
printf "Press any key to exit... "
Console.ReadKey() |> ignore

// The example displays output like the following:
//   Press any key to exit...
//   Handler not implemented...
//
//   Unhandled Exception: System.NotImplementedException: The method or operation is not implemented.
//      at Example.HandleTimer()
//      at Example.<<Main>b__0>d__2.MoveNext()
//   --- End of stack trace from previous location where exception was thrown ---
//      at System.Runtime.CompilerServices.AsyncMethodBuilderCore.<>c__DisplayClass2.<ThrowAsync>b__5(Object state)
//      at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
//      at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boolean preserveSyncCtx)
//      at System.Threading.QueueUserWorkItemCallback.System.Threading.IThreadPoolWorkItem.ExecuteWorkItem()
//      at System.Threading.ThreadPoolWorkQueue.Dispatch()
// </Snippet3>
