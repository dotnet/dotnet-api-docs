module concstack_single
//<snippet1>
open System
open System.Collections.Concurrent
open System.Threading.Tasks

// Demonstrates:
//      ConcurrentStack<T>.Push();
//      ConcurrentStack<T>.TryPeek();
//      ConcurrentStack<T>.TryPop();
//      ConcurrentStack<T>.Clear();
//      ConcurrentStack<T>.IsEmpty;

let main =
    task {
        let items = 10000
        let stack = ConcurrentStack<int>()

        // Create an action to push items onto the stack
        let pusher =
            Action(fun () ->
                for i = 0 to items - 1 do
                    stack.Push i)

        // Run the action once
        pusher.Invoke()
        let mutable result = 0

        if stack.TryPeek &result then
            printfn $"TryPeek() saw {result} on top of the stack."
        else
            printfn "Could not peek most recently added number."

        // Empty the stack
        stack.Clear()

        if stack.IsEmpty then
            printfn "Cleared the stack."

        // Create an action to push and pop items
        let pushAndPop =
            Action(fun () ->
                printfn $"Task started on {Task.CurrentId}"

                let mutable item = 0

                for i = 0 to items - 1 do
                    stack.Push i

                for i = 0 to items - 1 do
                    stack.TryPop &item |> ignore

                printfn $"Task ended on {Task.CurrentId}")
        // Spin up five concurrent tasks of the action
        let tasks =
            [| for i = 0 to 4 do
                   Task.Run pushAndPop |]

        // Wait for all the tasks to finish up
        do! Task.WhenAll tasks

        if not stack.IsEmpty then
            printfn "Did not take all the items off the stack"
    }

main.Wait()
//</snippet1>
