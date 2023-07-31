open System
open System.Collections.Concurrent
open System.Threading.Tasks
//<snippet1>
// Demonstrates:
//      ConcurrentDictionary<TKey, TValue> ctor(concurrencyLevel, initialCapacity)
//      ConcurrentDictionary<TKey, TValue>[TKey]

// We know how many items we want to insert into the ConcurrentDictionary.
// So set the initial capacity to some prime number above that, to ensure that
// the ConcurrentDictionary does not need to be resized while initializing it.
let NUMITEMS = 64
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
for i = 0 to NUMITEMS - 1 do
    cd[i] <- i * i

printfn $"The square of 23 is {cd[23]} (should be {23 * 23})"
//</snippet1>

do
    //<snippet2>
    // Demonstrates:
    //      ConcurrentDictionary<TKey, TValue>.TryAdd()
    //      ConcurrentDictionary<TKey, TValue>.TryUpdate()
    //      ConcurrentDictionary<TKey, TValue>.TryRemove()

    let mutable numFailures = 0 // for bookkeeping

    // Construct an empty dictionary
    let cd = ConcurrentDictionary<int, string>()

    // This should work
    if cd.TryAdd(1, "one") |> not then
        printfn "CD.TryAdd() failed when it should have succeeded"
        numFailures <- numFailures + 1

    // This shouldn't work -- key 1 is already in use
    if cd.TryAdd(1, "uno") then
        printfn "CD.TryAdd() succeeded when it should have failed"
        numFailures <- numFailures + 1

    // Now change the value for key 1 from "one" to "uno" -- should work
    if cd.TryUpdate(1, "uno", "one") |> not then
        printfn "CD.TryUpdate() failed when it should have succeeded"
        numFailures <- numFailures + 1

    // Try to change the value for key 1 from "eine" to "one"
    //    -- this shouldn't work, because the current value isn't "eine"
    if cd.TryUpdate(1, "one", "eine") then
        printfn "CD.TryUpdate() succeeded when it should have failed"
        numFailures <- numFailures + 1

    // Remove key/value for key 1.  Should work.
    let mutable value1 = ""

    if cd.TryRemove(1, &value1) |> not then
        printfn "CD.TryRemove() failed when it should have succeeded"
        numFailures <- numFailures + 1

    // Remove key/value for key 1.  Shouldn't work, because I already removed it
    let mutable value2 = ""

    if cd.TryRemove(1, &value2) then
        printfn "CD.TryRemove() succeeded when it should have failed"
        numFailures <- numFailures + 1

    // If nothing went wrong, say so
    if numFailures = 0 then
        printfn "  OK!"
//</snippet2>

do
    //<snippet3>
    // Demonstrates:
    //      ConcurrentDictionary<TKey, TValue>.AddOrUpdate()
    //      ConcurrentDictionary<TKey, TValue>.GetOrAdd()
    //      ConcurrentDictionary<TKey, TValue>[]

    // Construct a ConcurrentDictionary
    let cd = ConcurrentDictionary<int, int>()

    // Bombard the ConcurrentDictionary with 10000 competing AddOrUpdates
    Parallel.For(
        0,
        10000,
        fun i ->

            // Initial call will set cd[1] = 1.
            // Ensuing calls will set cd[1] = cd[1] + 1
            cd.AddOrUpdate(1, 1, (fun key oldValue -> oldValue + 1)) |> ignore
    )
    |> ignore

    printfn $"After 10000 AddOrUpdates, cd[1] = {cd[1]}, should be 10000"

    // Should return 100, as key 2 is not yet in the dictionary
    let value = cd.GetOrAdd(2, (fun key -> 100))
    printfn $"After initial GetOrAdd, cd[2] = {value} (should be 100)"

    // Should return 100, as key 2 is already set to that value2
    let value2 = cd.GetOrAdd(2, 10000)
    printfn $"After second GetOrAdd, cd[2] = {value2} (should be 100)"
//</snippet3>
