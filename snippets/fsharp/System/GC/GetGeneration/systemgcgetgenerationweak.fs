//<snippet1>
open System

let maxGarbage = 1000

[<AllowNullLiteral>]
type MyGCCollectClass() =
    member _.MakeSomeGarbage() =
        for i = 1 to maxGarbage do
            // Create objects and release them to fill up memory
            // with unused objects.
            Version() |> ignore

// Create a strong reference to an object.
let mutable myGCCol = MyGCCollectClass()

// Put some objects in memory.
myGCCol.MakeSomeGarbage()

// Get the generation of managed memory where myGCCol is stored.
printfn $"The object is in generation: {GC.GetGeneration myGCCol}"
            
// Perform a full garbage collection.
// Because there is a strong reference to myGCCol, it will
// not be garbage collected.
GC.Collect()

// Get the generation of managed memory where myGCCol is stored.
printfn $"The object is in generation: {GC.GetGeneration myGCCol}"

// Create a WeakReference to myGCCol.
let wkref = WeakReference myGCCol
// Remove the strong reference to myGCCol.
myGCCol <- null

// Get the generation of managed memory where wkref is stored.
printfn $"The WeakReference to the object is in generation: {GC.GetGeneration wkref}"

// Perform another full garbage collection.
// A WeakReference will not survive a garbage collection.
GC.Collect()

// Try to get the generation of managed memory where wkref is stored.
// Because it has been collected, an exception will be thrown.
try
    printfn $"The WeakReference to the object is in generation: {GC.GetGeneration wkref}"
    stdin.Read() |> ignore
with e ->
    printfn $"The WeakReference to the object has been garbage collected: '{e}'"
    stdin.Read() |> ignore

//</snippet1>