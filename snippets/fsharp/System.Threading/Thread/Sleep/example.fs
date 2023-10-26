module example
//<Snippet1>
open System.Threading

for _ = 0 to 4 do
    printfn "Sleep for 2 seconds."
    Thread.Sleep 2000

printfn "Main thread exits."

// This example produces the following output:
//     Sleep for 2 seconds.
//     Sleep for 2 seconds.
//     Sleep for 2 seconds.
//     Sleep for 2 seconds.
//     Sleep for 2 seconds.
//     Main thread exits.
//</Snippet1>