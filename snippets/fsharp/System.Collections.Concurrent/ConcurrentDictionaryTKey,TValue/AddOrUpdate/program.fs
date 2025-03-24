//<snippet1>
open System
open System.Collections.Concurrent

// Demonstrates:
//      ConcurrentDictionary<TKey, TValue> ctor(concurrencyLevel, initialCapacity)
//      ConcurrentDictionary<TKey, TValue>[TKey]

// We know how many items we want to insert into the ConcurrentDictionary.
// So set the initial capacity to some prime number above that, to ensure that
// the ConcurrentDictionary does not need to be resized while initializing it.
let HIGHNUMBER = 64
let initialCapacity = 101

// The higher the concurrencyLevel, the higher the theoretical number of operations
// that could be performed concurrently on the ConcurrentDictionary.  However, global
// operations like resizing the dictionary take longer as the concurrencyLevel rises.
// For the purposes of this example, we'll compromise at numCores * 2.
let numProcs = Environment.ProcessorCount
let concurrencyLevel = numProcs * 2

// Construct the dictionary with the desired concurrencyLevel and initialCapacity
let cd = ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity)

// Initialize the dictionary
for i = 1 to HIGHNUMBER do
    cd[i] <- i * i

printfn $"The square of 23 is {cd[23]} (should be {23 * 23})"

// Now iterate through, adding one to the end of the list. Existing items should be updated to be divided by their
// key  and a new item will be added that is the square of its key.
for i = 1 to HIGHNUMBER + 1 do
    cd.AddOrUpdate(i, i * i, (fun k v -> v / i)) |> ignore

printfn $"The square root of 529 is {cd[23]} (should be {529 / 23})"
printfn $"The square of 65 is {cd[HIGHNUMBER + 1]} (should be {(HIGHNUMBER + 1) * (HIGHNUMBER + 1)})"
//</snippet1>
