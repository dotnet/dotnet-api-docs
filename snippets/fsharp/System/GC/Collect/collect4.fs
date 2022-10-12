module collect4

open System
open System.Runtime

let createObjects () =
    Array.init 10000 (fun i -> 
        let s1= "word1"
        let s2 = "word2"
        s1 + " " + s2 )
    |> ignore

createObjects ()
printfn $"Memory allocated before GC: {GC.GetTotalMemory false:N0}"
// <Snippet1>
GCSettings.LargeObjectHeapCompactionMode <- GCLargeObjectHeapCompactionMode.CompactOnce
GC.Collect(2, GCCollectionMode.Forced, true, true)
// </Snippet1>
printfn $"Memory allocated after GC: {GC.GetTotalMemory false:N0}"