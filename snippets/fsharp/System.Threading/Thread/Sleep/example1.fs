module example1
//<Snippet1>
open System
open System.Threading

let interval = TimeSpan(0, 0, 2)

for _ = 0 to 4 do
    printfn "Sleep for 2 seconds."
    Thread.Sleep interval

printfn "Main thread exits."

// This example produces the following output:
//     Sleep for 2 seconds.
//     Sleep for 2 seconds.
//     Sleep for 2 seconds.
//     Sleep for 2 seconds.
//     Sleep for 2 seconds.
//     Main thread exits.
//</Snippet1>