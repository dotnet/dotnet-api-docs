module source
// <Snippet1>
open System
open System.Threading

let waitTime = TimeSpan(0, 0, 1)

let work () =
    Thread.Sleep waitTime

let newThread = Thread work
newThread.Start()

if waitTime + waitTime |> newThread.Join then
    printfn "New thread terminated."
else
    printfn "Join timed out."

// The example displays the following output:
//        New thread terminated.
// </Snippet1>