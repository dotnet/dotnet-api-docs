module WaitAny1
// <Snippet1>
open System.Threading
open System.Threading.Tasks

let tasks =
    [| for factor = 0 to 4 do
           Task.Run(fun () -> Thread.Sleep(factor * 250 + 50)) |]

let index = Task.WaitAny tasks
printfn $"Wait ended because task #{tasks[index].Id} completed."
printfn "\nCurrent Status of Tasks:"

for t in tasks do
    printfn $"   Task {t.Id}: {t.Status}"


// The example displays output like the following:
//       Wait ended because task #1 completed.
//
//       Current Status of Tasks:
//          Task 1: RanToCompletion
//          Task 2: Running
//          Task 3: Running
//          Task 4: Running
//          Task 5: Running
// </Snippet1>
