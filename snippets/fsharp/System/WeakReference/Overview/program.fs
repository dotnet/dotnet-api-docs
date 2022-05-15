// <Snippet1>
open System
open System.Collections.Generic

// This class creates byte arrays to simulate data.
type Data(size) =
    let _data = Array.zeroCreate<byte> (size * 1024)
    
    // Simple property.
    member _.Name = 
        string size

type Cache(count) =
    // Dictionary to contain the cache.
    static let mutable _cache = Dictionary<int, WeakReference>()

    // Track the number of times an object is regenerated.
    let mutable regenCount = 0

    do
        _cache <- Dictionary<int, WeakReference>()
        // <Snippet2>
        // Add objects with a short weak reference to the cache.
        for i = 0 to count - 1 do
            _cache.Add(i, WeakReference(Data i, false))
        // </Snippet2>

    // Number of items in the cache.
    member _.Count =
        _cache.Count

    // Number of times an object needs to be regenerated.
    member _.RegenerationCount =
        regenCount

    // Retrieve a data object from the cache.
    member _.Item
        with get (index) =
            // <Snippet3>
            match _cache[index].Target with
            | :? Data as d->
                // Object was obtained with the weak reference.
                printfn $"Regenerate object at {index}: No"
                d
            | _ ->
                // If the object was reclaimed, generate a new one.
                printfn $"Regenerate object at {index}: Yes"
                let d = Data index
                _cache[index].Target <- d
                regenCount <- regenCount + 1
                d 
            // </Snippet3>

// Create the cache.
let cacheSize = 50
let r = Random()
let c = Cache cacheSize

let mutable dataName = ""
GC.Collect 0

// Randomly access objects in the cache.
for _ = 0 to c.Count - 1 do
    let index = r.Next c.Count

    // Access the object by getting a property value.
    dataName <- c[index].Name

// Show results.
let regenPercent = double c.RegenerationCount / double c.Count
printfn $"Cache size: {c.Count}, Regenerated: {regenPercent:P2}%%"

// Example of the last lines of the output:
//
// ...
// Regenerate object at 36: Yes
// Regenerate object at 8: Yes
// Regenerate object at 21: Yes
// Regenerate object at 4: Yes
// Regenerate object at 38: No
// Regenerate object at 7: Yes
// Regenerate object at 2: Yes
// Regenerate object at 43: Yes
// Regenerate object at 38: No
// Cache size: 50, Regenerated: 94%
// </Snippet1>