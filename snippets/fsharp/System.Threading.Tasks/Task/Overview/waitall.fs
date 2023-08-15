module waitall
//<snippet02>
open System
open System.Threading
open System.Threading.Tasks

// Define a delegate that prints and returns the system tick count
let action =
    fun (obj: obj) ->
        let i = obj :?> int

        // Make each thread sleep a different time in order to return a different tick count
        Thread.Sleep(i * 100)

        // The tasks that receive an argument between 2 and 5 throw exceptions
        if 2 <= i && i <= 5 then
            raise (InvalidOperationException "SIMULATED EXCEPTION")


        let tickCount = Environment.TickCount
        printfn $"Task={Task.CurrentId}, i={i}, TickCount={tickCount}, Thread={Thread.CurrentThread.ManagedThreadId}"
        tickCount

// Construct started tasks
let tasks =
    [| for i = 0 to 9 do
           Task<int>.Factory.StartNew (action, i) |]

try

    // Wait for all the tasks to finish.
    Seq.cast tasks |> Seq.toArray |> Task.WaitAll

    // We should never get to this point
    printfn "WaitAll() has not thrown exceptions. THIS WAS NOT EXPECTED."

with :? AggregateException as e ->
    printfn "\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)"

    for ex in e.InnerExceptions do
        printfn $"\n-------------------------------------------------\n{ex}"

// The example displays output like the following:
//     Task=1, i=0, TickCount=1203822250, Thread=3
//     Task=2, i=1, TickCount=1203822359, Thread=4
//     Task=7, i=6, TickCount=1203823484, Thread=3
//     Task=8, i=7, TickCount=1203823890, Thread=4
//     Task=9, i=8, TickCount=1203824296, Thread=3
//     Task=10, i=9, TickCount=1203824796, Thread=4
//
//     The following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)
//
//     -------------------------------------------------
//     System.InvalidOperationException: SIMULATED EXCEPTION
//        at Example.<Main>b__0(Object obj)
//        at System.Threading.Tasks.Task`1.InnerInvoke()
//        at System.Threading.Tasks.Task.Execute()
//
//     -------------------------------------------------
//     System.InvalidOperationException: SIMULATED EXCEPTION
//        at Example.<Main>b__0(Object obj)
//        at System.Threading.Tasks.Task`1.InnerInvoke()
//        at System.Threading.Tasks.Task.Execute()
//
//     -------------------------------------------------
//     System.InvalidOperationException: SIMULATED EXCEPTION
//        at Example.<Main>b__0(Object obj)
//        at System.Threading.Tasks.Task`1.InnerInvoke()
//        at System.Threading.Tasks.Task.Execute()
//
//     -------------------------------------------------
//     System.InvalidOperationException: SIMULATED EXCEPTION
//        at Example.<Main>b__0(Object obj)
//        at System.Threading.Tasks.Task`1.InnerInvoke()
//        at System.Threading.Tasks.Task.Execute()
//</snippet02>
