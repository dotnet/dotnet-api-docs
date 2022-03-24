module class1

// <Snippet1>
open System

let maxGarbage = 1000

let makeSomeGarbage () =
    // Create objects and release them to fill up memory with unused objects.
    for _ = 1 to maxGarbage do 
        Version() |> ignore

// Put some objects in memory.
makeSomeGarbage()
printfn $"Memory used before collection:       {GC.GetTotalMemory false:N0}"

// Collect all generations of memory.
GC.Collect()
printfn $"Memory used after full collection:   {GC.GetTotalMemory true:N0}"

// The output from the example resembles the following:
//       Memory used before collection:       79,392
//       Memory used after full collection:   52,640
// </Snippet1>