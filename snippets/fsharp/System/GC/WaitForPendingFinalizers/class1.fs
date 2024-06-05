//<snippet1>
open System

// You can increase this number to fill up more memory.
let numMfos = 1000

// You can increase this number to cause more
// post-finalization work to be done.
let maxIterations = 100

[<AllowNullLiteral>]
type MyFinalizeObject() =
    // Make this number very large to cause the finalizer todo more work.
    let maxIterations = 10000

    override _.Finalize() =
        printfn "Finalizing a MyFinalizeObject"
        
        // Do some work.
        for i = 1 to maxIterations do
            // This method performs no operation on i, but prevents
            // the JIT compiler from optimizing away the code inside
            // the loop.
            GC.KeepAlive i

let mutable mfo = null

// Create and release a large number of objects
// that require finalization.
for j = 1 to numMfos do
    mfo <- MyFinalizeObject()

//Release the last object created in the loop.
mfo <- null

//Force garbage collection.
GC.Collect()

// Wait for all finalizers to complete before continuing.
// Without this call to GC.WaitForPendingFinalizers,
// the worker loop below might execute at the same time
// as the finalizers.
// With this call, the worker loop executes only after
// all finalizers have been called.
GC.WaitForPendingFinalizers()

// Worker loop to perform post-finalization code.
for _ = 1 to maxIterations do
    printfn "Doing some post-finalize work"
//</snippet1>