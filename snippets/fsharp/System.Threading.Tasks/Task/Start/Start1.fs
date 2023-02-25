module Start1
// <Snippet1>
open System.Threading
open System.Threading.Tasks

let t =
    new Task(fun () ->
        printfn $"Task {Task.CurrentId} running on thread {Thread.CurrentThread.ManagedThreadId}"

        for i = 1 to 10 do
            printfn $"   Iteration {i}")

t.Start()
t.Wait() |> ignore

// The example displays output like the following:
//     Task 1 running on thread 3
//        Iteration 1
//        Iteration 2
//        Iteration 3
//        Iteration 4
//        Iteration 5
//        Iteration 6
//        Iteration 7
//        Iteration 8
//        Iteration 9
//        Iteration 10
// </Snippet1>
